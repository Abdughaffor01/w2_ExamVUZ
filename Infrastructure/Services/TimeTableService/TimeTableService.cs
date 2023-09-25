using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace Infrastructure;
public class TimeTableService : ITimeTableService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public TimeTableService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<BaseTimeTableDto>> AddTimeTableAsync(AddTimeTableDto model)
    {
        try
        {
            var timetable = new TimeTable()
            {
                Day = model.Day,
                Time = model.Time,
                SubjectId = model.SubjectId,
            };
            await _context.TimeTables.AddAsync(timetable);
            await _context.SaveChangesAsync();
            return new Response<BaseTimeTableDto>(_mapper.Map<BaseTimeTableDto>(timetable));
        }
        catch (Exception ex)
        {
            return new Response<BaseTimeTableDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<string>> DeleteTimeTableAsync(int id)
    {
        try
        {
            var timeTable = await _context.TimeTables.FirstOrDefaultAsync(tt=>tt.TT_Id==id);
            if (timeTable == null) return new Response<string>(HttpStatusCode.NoContent);
            _context.TimeTables.Remove(timeTable);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted time table");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<GetTimeTableDto>> GetTimeTableByIdAsync(int id)
    {
        var timeTable=await _context.TimeTables.FirstOrDefaultAsync(t=>t.TT_Id==id);
        if (timeTable == null) return new Response<GetTimeTableDto>(HttpStatusCode.NoContent);
        var timeTableDto = new GetTimeTableDto() { 
            TT_Id=timeTable.TT_Id,
            Time=timeTable.Time,
            Day=timeTable.Day,
            SubjectName=timeTable.Subject.Name,
            Classrooms = timeTable.Classrooms
        };
        return new Response<GetTimeTableDto>(timeTableDto);
        
    }

    public async Task<Response<List<GetTimeTableDto>>> GetTimeTablesAsync()
    {
        try
        {
            var timeTables=await _context.TimeTables.Select(tT=>new GetTimeTableDto() {
                TT_Id = tT.TT_Id,
                Time = tT.Time,
                Day = tT.Day,
                SubjectName = tT.Subject.Name,
                Classrooms = tT.Classrooms
            }).ToListAsync();
            if (timeTables == null) return new Response<List<GetTimeTableDto>>(HttpStatusCode.NoContent);
            return new Response<List<GetTimeTableDto>>(timeTables);
        }
        catch (Exception ex)
        {
            return new Response<List<GetTimeTableDto>>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<BaseTimeTableDto>> UpdateTimeTableAsync(AddTimeTableDto model)
    {
        try
        {
            var timeTable=await _context.TimeTables.FirstOrDefaultAsync(tt=>tt.TT_Id==model.TT_Id);
            if (timeTable == null) return new Response<BaseTimeTableDto>(HttpStatusCode.NoContent);
            timeTable.Time=model.Time;
            timeTable.Day=model.Day;
            timeTable.SubjectId=model.SubjectId;
            await _context.SaveChangesAsync();
            return new Response<BaseTimeTableDto>(_mapper.Map<BaseTimeTableDto>(timeTable));
        }
        catch (Exception ex)
        {
            return new Response<BaseTimeTableDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}
