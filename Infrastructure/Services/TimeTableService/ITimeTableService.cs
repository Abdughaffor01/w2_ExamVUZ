using Domain;

namespace Infrastructure;
public interface ITimeTableService
{
    Task<Response<List<GetTimeTableDto>>> GetTimeTablesAsync();
    Task<Response<GetTimeTableDto>> GetTimeTableByIdAsync(int id);
    Task<Response<BaseTimeTableDto>> AddTimeTableAsync(AddTimeTableDto model);
    Task<Response<BaseTimeTableDto>> UpdateTimeTableAsync(AddTimeTableDto model);
    Task<Response<string>> DeleteTimeTableAsync(int id);
}
