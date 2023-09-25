using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
public class SubjectController:ControllerBase
{
    private readonly ISubjectService _service;
    public SubjectController(ISubjectService service)=>_service=service;


    [HttpGet("GetSubjectsAsync")]
    public async Task<Response<List<GetSubjectDto>>> GetSubjectsAsync()=>await _service.GetSubjectsAsync();

    [HttpGet("GetSubjectByIdAsync")]
    public async Task<Response<GetSubjectDto>> GetSubjectByIdAsync(int id)=>await _service.GetSubjectByIdAsync(id);

    [HttpPost("AddSubjectAsync")]
    public async Task<Response<BaseSubjectDto>> AddSubjectAsync([FromBody]AddSubjectDto model)=>await _service.AddSubjectAsync(model);

    [HttpPut("UpdateSubjectAsync")]
    public async Task<Response<BaseSubjectDto>> UpdateSubjectAsync([FromBody]AddSubjectDto model)=>await _service.UpdateSubjectAsync(model);

    [HttpDelete("UpdateSubjectAsync")]
    public async Task<Response<string>> UpdateSubjectAsync(int id)=>await _service.UpdateSubjectAsync(id);
}
