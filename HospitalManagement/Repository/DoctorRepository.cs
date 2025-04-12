﻿using System.Text.Json;
using HospitalManagement.DataAccess;
using HospitalManagement.DataAccess.Entities;
using HospitalManagement.Repository.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Sats.PostgresDistributedCache;

namespace HospitalManagement.Repository;

public class DoctorRepository : Repository<Doctor>, IDoctorRepository
{
    private readonly IMemoryCache _memoryCache;
//    private readonly IPostgreSqlDistributedCache _postgreSqlCache;
    private readonly IDistributedCache _distributedCache;

    public DoctorRepository(
        HospitalContext context,
        IMemoryCache memoryCache,
        IDistributedCache distributedCache
     //   IPostgreSqlDistributedCache postgreSqlCache
        ) : base(context)
    {
        _memoryCache = memoryCache;
        _distributedCache = distributedCache;

        // _postgreSqlCache = postgreSqlCache;
    }

    public async Task<Doctor> GetByIdAsync(int id)
    {
        _memoryCache.TryGetValue<Doctor>(id, out var cachedDoctor);
        if (cachedDoctor is not null)
        {
            return cachedDoctor;
        }

        var doctor = await Context.Doctors.FindAsync(id);

        _memoryCache.Set(id, doctor, TimeSpan.FromSeconds(10));

        return doctor;
    }

    public async Task<Doctor> GetByIdCachedAsync(int id)
    {
        var cachedDoctor = await _distributedCache.GetStringAsync(id.ToString());

        if (cachedDoctor is not null)
        {
            return JsonSerializer.Deserialize<Doctor>(cachedDoctor);
        }

        var doctor = await Context.Doctors.FindAsync(id);

        if (doctor is not null)
        {
            var serialized = JsonSerializer.Serialize(doctor);

            await _distributedCache.SetStringAsync(
                id.ToString(),
                serialized);
        }

        return doctor;
    }
}
