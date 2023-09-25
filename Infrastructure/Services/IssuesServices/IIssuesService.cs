using Domain;

namespace Infrastructure;
public interface IIssuesService
{
    Task<Response<List<GetIssuesesDto>>> GetIssuesesAsync();
    Task<Response<GetIssuesesDto>> GetIssuesByIdAsync(int id);
    Task<Response<BaseIssuesDto>> AddIssuesAsync(AddIssuesDto model);
    Task<Response<BaseIssuesDto>> UpdateIssuesAsync(AddIssuesDto model);
    Task<Response<string>> DeleteIssuesAsync(int id);
}
