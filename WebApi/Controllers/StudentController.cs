using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
public class StudentController:ControllerBase
{
    private readonly IStudentService _service;
    public StudentController(IStudentService service)=>_service = service;

    [HttpGet("GetStudentsAsync")]
    public async Task<Response<List<GetStudentDto>>> GetStudentsAsync()=>await _service.GetStudentsAsync();

    [HttpGet("GetStudentByIdAsync")]
    public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int id)=>await _service.GetStudentByIdAsync(id);

    [HttpPost("AddStudentAsync")]
    public async Task<Response<BaseStudentDto>> AddStudentAsync([FromBody]AddStudentDto model)=>await _service.AddStudentAsync(model);

    [HttpPut("UpdateStudentAsync")]
    public async Task<Response<BaseStudentDto>> UpdateStudentAsync(AddStudentDto model)=>await _service.UpdateStudentAsync(model);
    
    [HttpDelete("DeleteStudentAsync")]
    public async Task<Response<string>> DeleteStudentAsync(int id)=>await _service.DeleteStudentAsync(id);

    [HttpPost("AddResultExamToStudent")]
    public async Task<Response<StudentResultExamDto>> AddResultExamToStudent(StudentResultExamDto model)=>await _service.AddResultExamToStudent(model);

    [HttpDelete("DeleteResultExamToStudent")]
    public async Task<Response<string>> DeleteResultExamToStudent(StudentResultExamDto model) => await _service.DeleteResultExamToStudent(model);
}
