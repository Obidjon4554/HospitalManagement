﻿using System.Text.Json;
using HospitalManagement.Dtos;
using HospitalManagement.Filters;
using HospitalManagement.Services;
using HospitalManagement.Services.Doctors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorService _doctorService;
    private readonly PdpService _pdpService;

    public DoctorsController(
        IDoctorService doctorService,
        PdpService pdpService)
    {
        _doctorService = doctorService;
        _pdpService = pdpService;
    }

    [LogActionFilter]
    [HttpPost]
    public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDto doctorDto)
    {
        await _doctorService.CreateDoctor(doctorDto);

        return Created();
    }

    [HttpGet]
    public async Task<IActionResult> GetDoctors()
    {
        return Ok(_doctorService.GetAllDoctors());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDoctor([FromRoute] int id)
    {
        return Ok(await _doctorService.GetDoctor(id));
    }

    [HttpGet("pdp-data")]
    public async Task<IActionResult> GetSettings()
    {
        return Ok(await _pdpService.GetPdpData());
    }

    [HttpPost("notify")]
    public async Task<IActionResult> NotifyDoctors()
    {
        await _doctorService.SendPatientsStatus();
        return Ok();
    }
}
