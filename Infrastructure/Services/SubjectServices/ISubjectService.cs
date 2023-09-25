using Domain;

namespace Infrastructure;
public interface ISubjectService
{
    Task<Response<List<GetSubjectDto>>> GetSubjectsAsync();
    Task<Response<GetSubjectDto>> GetSubjectByIdAsync(int id);
    Task<Response<BaseSubjectDto>> AddSubjectAsync(AddSubjectDto model);
    Task<Response<BaseSubjectDto>> UpdateSubjectAsync(AddSubjectDto model);
    Task<Response<string>> UpdateSubjectAsync(int id);
}
