using HospitalManagement.DataAccess.Entities;
using HospitalManagement.DataAccess;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace HospitalManagement.Repository;

public interface IPatientRepository
{
    Task<IList<Patient>> GetPatientsBySeverity(int severity);
    IQueryable<Patient> GetAll();

    Task<Patient> GetByIdAsync(int id);

    Task AddAsync(Patient patient);

    Task UpdateAsync(Patient patient);

    Task DeleteAsync(int id);
}

public class PatientRepository : IPatientRepository
{
    private readonly HospitalContext _context;
    private readonly IMemoryCache _memoryCache;
    private readonly IDistributedCache _cache;

    private const string PatientsCacheKey = "Patients";

    public PatientRepository(HospitalContext context, IDistributedCache cache, IMemoryCache memoryCache)
    {
        _context = context;
        _cache = cache;
        _memoryCache = memoryCache;
    }

    public async Task<IList<Patient>> GetPatientsBySeverity(int severity)
    {
        if (_memoryCache.TryGetValue(PatientsCacheKey, out IList<Patient> patients))
        {
            return patients;
        }

        var patientsAll = await _context.Patients
            .Include(r => r.PatientBlank)
            .Where(r => r.PatientBlank.Severity > severity)
            .ToListAsync();

        _memoryCache.Set(PatientsCacheKey, patientsAll);

        return patientsAll;
    }

    public IQueryable<Patient> GetAll()
    {
        return _context.Patients
            .AsQueryable();
    }

    public async Task<Patient> GetByIdAsync(int id)
    {
        var cacheDoctor = await _cache.GetStringAsync(id.ToString());
        if (cacheDoctor is not null)
        {
            return JsonSerializer.Deserialize<Patient>(cacheDoctor);
        }

        var doctor = await _context.Patients.FindAsync(id);

        if (doctor is not null)
        {
            var serialized = JsonSerializer.Serialize(doctor);

            await _cache.SetStringAsync(id.ToString(), serialized);
        }

        return doctor;
    }

    public async Task AddAsync(Patient patient)
    {
        await _context.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Patient patient)
    {
        _context.Update(patient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var patient = _context.Patients.FindAsync(id);
        if (patient != null)
        {
            _context.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }
}
