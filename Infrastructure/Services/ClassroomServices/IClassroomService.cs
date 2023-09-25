using Domain;

namespace Infrastructure;
public interface IClassroomService
{
    Task<Response<List<GetClassroomDto>>> GetClassroomsAsync();
    Task<Response<GetClassroomDto>> GetClassroomByIdAsync(int  id);
    Task<Response<BaseClassroomDto>> AddClassroomAsync(AddClassroomDto model);
    Task<Response<BaseClassroomDto>> UpdateClassroomAsync(AddClassroomDto model);
    Task<Response<string>> DeleteClassroomAsync(int id);
    Task<Response<ClassroomStudentDto>> AddStudentToClassromAsync(ClassroomStudentDto model);
    Task<Response<string>> DeleteStudentFromClassromAsync(int id);
}
