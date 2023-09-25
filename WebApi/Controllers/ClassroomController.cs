using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
public class ClassroomController:ControllerBase
{
    private readonly IClassroomService _service;
    public ClassroomController(IClassroomService service)=>_service = service;

    [HttpGet("GetClassroomsAsync")]
    public async Task<Response<List<GetClassroomDto>>> GetClassroomsAsync()=>await _service.GetClassroomsAsync();

    [HttpGet("GetClassroomByIdAsync")]
    public async Task<Response<GetClassroomDto>> GetClassroomByIdAsync(int id)=>await _service.GetClassroomByIdAsync(id);

    [HttpPost("AddClassroomAsync")]
    public async Task<Response<BaseClassroomDto>> AddClassroomAsync(AddClassroomDto model)=>await _service.AddClassroomAsync(model);

    [HttpPut("UpdateClassroomAsync")]
    public async Task<Response<BaseClassroomDto>> UpdateClassroomAsync(AddClassroomDto model)=>await _service.UpdateClassroomAsync(model);

    [HttpDelete("DeleteClassroomAsync")]
    public async Task<Response<string>> DeleteClassroomAsync(int id)=>await _service.DeleteClassroomAsync(id);

    [HttpPost("AddStudentToClassromAsync")]
    public async Task<Response<ClassroomStudentDto>> AddStudentToClassrom(ClassroomStudentDto model)=>await _service.AddStudentToClassromAsync(model);

    [HttpDelete("DeleteStudentFromClassromAsync")]
    public async Task<Response<string>> DeleteStudentFromClassromAsync(int id) => await _service.DeleteStudentFromClassromAsync(id);
}
