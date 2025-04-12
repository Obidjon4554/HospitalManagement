using System.Text.Json;
using HospitalManagement.DataAccess;
using HospitalManagement.DataAccess.Entities;
using HospitalManagement.Dtos;
using HospitalManagement.Repository;
using HospitalManagement.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Sats.PostgresDistributedCache;
using Serilog.Context;

namespace HospitalManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly ILogger<PatientsController> _logger;
    private readonly IPostgreSqlDistributedCache _distrCache;
    private readonly DoctorsSettings _doctorsSettings;
    private readonly HospitalContext _context;
    private readonly IPatientRepository _patientRepository;

    public PatientsController(
        IOptions<DoctorsSettings> doctorsSettings,
        IConfiguration configuration,
        ILogger<PatientsController> logger,
        IMemoryCache memoryCache,
        IPostgreSqlDistributedCache distrCache,
        IPatientRepository patientRepository,
        HospitalContext context
    )
    {
        _logger = logger;
        _distrCache = distrCache;
        _doctorsSettings = doctorsSettings.Value;
        _patientRepository = patientRepository;
        _context = context;
    }

    [HttpPost("arrange-appointment")]
    public async Task<IActionResult> ArrangeAppointment([FromBody] ArrangeAppointmentDto requestDto)
    {
        using (LogContext.PushProperty("PatientId", requestDto.PatientId))
        {
            var time = TimeOnly.FromDateTime(requestDto.AppointmentDate);

            if (!time.IsBetween(_doctorsSettings.WorkTime.Start, _doctorsSettings.WorkTime.End))
            {
                _logger.LogWarning("Doctor is not available at this time");
                return BadRequest("Doctor is not available at this time");
            }

            _logger.LogWarning("{@Request}, Patient with PassportSerial {PassportSerial}", requestDto, requestDto.PassportSerial);
        }

        return Ok("Your appointment is arranged");
    }

    [HttpGet("get-doctors")]
    public async Task<Doctor> GetByIdAsync(int id)
    {
        var cachedDoctor = await _distrCache.GetAsync(id.ToString());

        if (cachedDoctor is not null)
        {
            return JsonSerializer.Deserialize<Doctor>(cachedDoctor);
        }

        var doctor = await _context.Doctors.FindAsync(id);

        if (doctor is not null)
        {
            var serialized = JsonSerializer.SerializeToUtf8Bytes(doctor);

            await _distrCache.SetAsync(
                id.ToString(),
                serialized,
                TimeSpan.FromMinutes(1));
        }

        return doctor;
    }
    
    [HttpGet]
    public ActionResult<IQueryable<Patient>> GetAllPatients()
    {
        return Ok(_patientRepository.GetAll());
    }

    [HttpGet("severity/{severity}")]
    public async Task<ActionResult<IList<Patient>>> GetBySeverity(int severity)
    {
        var patients = await _patientRepository.GetPatientsBySeverity(severity);
        return Ok(patients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatientById(int id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);
        if (patient == null)
        {
            return NotFound();
        }
        return Ok(patient);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatient(Patient patient)
    {
        await _patientRepository.AddAsync(patient);
        return CreatedAtAction(nameof(GetPatientById), new { id = patient.PatientId }, patient);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatient(int id, Patient patient)
    {
        if (id != patient.PatientId)
        {
            return BadRequest("ID mismatch");
        }

        await _patientRepository.UpdateAsync(patient);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        await _patientRepository.DeleteAsync(id);
        return NoContent();
    }
}
