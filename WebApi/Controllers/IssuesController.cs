using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
public class IssuesController:ControllerBase
{
    private readonly IssuesService _service;
    public IssuesController(IssuesService service)=>_service = service;

    [HttpGet("GetIssuesesAsync")]
    public async Task<Response<List<GetIssuesesDto>>> GetIssuesesAsync()=>await _service.GetIssuesesAsync();

    [HttpGet("GetIssuesByIdAsync")]
    public async Task<Response<GetIssuesesDto>> GetIssuesByIdAsync(int id)=>await _service.GetIssuesByIdAsync(id);

    [HttpPost("AddIssuesAsync")]
    public async Task<Response<BaseIssuesDto>> AddIssuesAsync(AddIssuesDto model)=>await _service.AddIssuesAsync(model);

    [HttpPut("UpdateIssuesAsync")]
    public async Task<Response<BaseIssuesDto>> UpdateIssuesAsync(AddIssuesDto model)=>await _service.UpdateIssuesAsync(model);

    [HttpDelete("DeleteIssuesAsync")]
    public async Task<Response<string>> DeleteIssuesAsync(int id)=>await _service.DeleteIssuesAsync(id);
}
