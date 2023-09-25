using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
public class TeacherController:ControllerBase
{
    private readonly ITeacherService _service;
    public TeacherController(ITeacherService service)=>_service = service;

    [HttpGet("GetTeachersAsync")]
    public async Task<Response<List<GetTeacherDto>>> GetTeachersAsync()=>await _service.GetTeachersAsync();

    [HttpGet("GetTeacherByIdAsync")]
    public async Task<Response<GetTeacherDto>> GetTeacherByIdAsync(int id)=>await _service.GetTeacherByIdAsync(id);

    [HttpPost("AddTeacherAsync")]
    public async Task<Response<BaseTeacherDto>> AddTeacherAsync([FromBody]AddTeacherDto model)=>await _service.AddTeacherAsync(model);

    [HttpPut("UpdateTeacherAsync")]
    public async Task<Response<BaseTeacherDto>> UpdateTeacherAsync([FromBody]AddTeacherDto model) => await _service.UpdateTeacherAsync(model);

    [HttpDelete("DeleteTeacherAsync")]
    public async Task<Response<string>> DeleteTeacherAsync(int id) => await _service.DeleteTeacherAsync(id);
}
