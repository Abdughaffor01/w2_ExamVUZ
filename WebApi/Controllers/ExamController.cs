using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
public class ExamController:ControllerBase
{
    private readonly IExamService _service;
    public ExamController(IExamService service)=>_service = service;

    [HttpGet("GetExamsAsync")]
    public async Task<Response<List<GetExamDto>>> GetExamsAsync()=>await _service.GetExamsAsync();

    [HttpGet("GetExamByIdAsync")]
    public async Task<Response<GetExamDto>> GetExamByIdAsync(int id)=>await _service.GetExamByIdAsync(id);

    [HttpPost("AddExamAsync")]
    public async Task<Response<BaseExamDto>> AddExamAsync(AddExamDto model)=>await _service.AddExamAsync(model);

    [HttpPut("UpdateExamAsync")]
    public async Task<Response<BaseExamDto>> UpdateExamAsync(AddExamDto model)=>await _service.UpdateExamAsync(model);

    [HttpDelete("DeleteExamAsync")]
    public async Task<Response<string>> DeleteExamAsync(int id)=>await _service.DeleteExamAsync(id);
}
