using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
public class TimeTableController:ControllerBase
{
    private readonly ITimeTableService _service;
    public TimeTableController(ITimeTableService service)=>_service = service;

    [HttpGet("GetTimeTablesAsync")]
    public async Task<Response<List<GetTimeTableDto>>> GetTimeTablesAsync()=>await _service.GetTimeTablesAsync();

    [HttpGet("GetTimeTableByIdAsync")]
    public async Task<Response<GetTimeTableDto>> GetTimeTableByIdAsync(int id)=>await _service.GetTimeTableByIdAsync(id);

    [HttpPost("AddTimeTableAsync")]
    public async Task<Response<BaseTimeTableDto>> AddTimeTableAsync(AddTimeTableDto model)=>await _service.AddTimeTableAsync(model);
    
    [HttpPut("UpdateTimeTableAsync")]
    public async Task<Response<BaseTimeTableDto>> UpdateTimeTableAsync(AddTimeTableDto model)=>await _service.UpdateTimeTableAsync(model);

    [HttpDelete("DeleteTimeTableAsync")]
    public async Task<Response<string>> DeleteTimeTableAsync(int id)=>await _service.DeleteTimeTableAsync(id);

}
