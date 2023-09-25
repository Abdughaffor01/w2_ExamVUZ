using Domain;

namespace Infrastructure;
public interface IAttendanceService
{
    Task<Response<List<GetAttendanceDto>>> GetAttendancesAsync();
    Task<Response<GetAttendanceDto>> GetAttendanceByIdAsync(int id);
    Task<Response<BaseAttendanceDto>> AddAttendanceAsync(AddAttendanceDto model);
    Task<Response<BaseAttendanceDto>> UpdateAttendanceAsync(AddAttendanceDto model);
    Task<Response<string>> DeleteAttendanceAsync(int id);
}
