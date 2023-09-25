using Domain;

namespace Infrastructure;
public interface IStudentService
{
    Task<Response<List<GetStudentDto>>> GetStudentsAsync();
    Task<Response<GetStudentDto>> GetStudentByIdAsync(int id);
    Task<Response<BaseStudentDto>> AddStudentAsync(AddStudentDto model);
    Task<Response<BaseStudentDto>> UpdateStudentAsync(AddStudentDto model);
    Task<Response<string>> DeleteStudentAsync(int id);
    Task<Response<StudentResultExamDto>> AddResultExamToStudent(StudentResultExamDto model);
    Task<Response<string>> DeleteResultExamToStudent(StudentResultExamDto model);
}
