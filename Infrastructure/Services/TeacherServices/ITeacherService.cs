using Domain;

namespace Infrastructure;
public interface ITeacherService
{
    Task<Response<List<GetTeacherDto>>> GetTeachersAsync();
    Task<Response<GetTeacherDto>> GetTeacherByIdAsync(int id);
    Task<Response<BaseTeacherDto>> AddTeacherAsync(AddTeacherDto model);
    Task<Response<BaseTeacherDto>> UpdateTeacherAsync(AddTeacherDto model);
    Task<Response<string>> DeleteTeacherAsync(int id);
}
