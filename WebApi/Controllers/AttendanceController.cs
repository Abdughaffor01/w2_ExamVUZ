using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]

public class AttendanceController:ControllerBase
{
    private readonly IAttendanceService _service;
    public AttendanceController(IAttendanceService service)=>_service = service;


    [HttpGet("GetAttendancesAsync")]
    public async Task<Response<List<GetAttendanceDto>>> GetAttendancesAsync()=>await _service.GetAttendancesAsync();

    [HttpGet("GetAttendanceByIdAsync")]
    public async Task<Response<GetAttendanceDto>> GetAttendanceByIdAsync(int id)=>await _service.GetAttendanceByIdAsync(id);

    [HttpPost("AddAttendanceAsync")]
    public async Task<Response<BaseAttendanceDto>> AddAttendanceAsync(AddAttendanceDto model)=>await _service.AddAttendanceAsync(model);

    [HttpPut("UpdateAttendanceAsync")]
    public async Task<Response<BaseAttendanceDto>> UpdateAttendanceAsync(AddAttendanceDto model)=>await _service.UpdateAttendanceAsync(model);

    [HttpDelete("DeleteAttendanceAsync")]
    public async Task<Response<string>> DeleteAttendanceAsync(int id)=>await _service.DeleteAttendanceAsync(id);
}
