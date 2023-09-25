using Domain;

namespace Infrastructure;
public interface IExamService
{
    Task<Response<List<GetExamDto>>> GetExamsAsync();
    Task<Response<GetExamDto>> GetExamByIdAsync(int id);
    Task<Response<BaseExamDto>> AddExamAsync(AddExamDto model);
    Task<Response<BaseExamDto>> UpdateExamAsync(AddExamDto model);
    Task<Response<string>> DeleteExamAsync(int id);
}
