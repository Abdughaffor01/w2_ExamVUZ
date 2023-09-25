using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure;
public class AttendanceService : IAttendanceService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public AttendanceService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<BaseAttendanceDto>> AddAttendanceAsync(AddAttendanceDto model)
    {
        try
        {
            var attendance=new Attendance() {
                TeacherId = model.TeacherId,
                Date=model.Date,
                Status = model.Status,
            };
            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
            return new Response<BaseAttendanceDto>(_mapper.Map<BaseAttendanceDto>(attendance));
        }
        catch (Exception ex)
        {
            return new Response<BaseAttendanceDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<string>> DeleteAttendanceAsync(int id) 
    {
        try
        {
            var attendance = await _context.Attendances.Where(a => a.TeacherId == id).ToListAsync();
            if (attendance == null) return new Response<string>(HttpStatusCode.NoContent);
            _context.Attendances.RemoveRange(attendance);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted attendance from teacher");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<GetAttendanceDto>> GetAttendanceByIdAsync(int id)
    {
        try
        {
            var attendance = await _context.Attendances.Select(a=>new GetAttendanceDto() { 
                NameTeacher = a.Teacher.Name,
                Date = a.Date,
                Status=a.Status
            }).FirstOrDefaultAsync(a=>a.TeacherId==id);
            if (attendance == null) return new Response<GetAttendanceDto>(HttpStatusCode.NoContent);
            return new Response<GetAttendanceDto>(attendance);
        }
        catch (Exception ex)
        {
            return new Response<GetAttendanceDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<GetAttendanceDto>>> GetAttendancesAsync()
    {
        try
        {
            var attendes = await _context.Attendances.Select(a => new GetAttendanceDto()
            {
                NameTeacher = a.Teacher.Name,
                Date = a.Date,
                Status = a.Status
            }).ToListAsync();
            return new Response<List<GetAttendanceDto>>(attendes);
        }
        catch (Exception ex)
        {
            return new Response<List<GetAttendanceDto>>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<BaseAttendanceDto>> UpdateAttendanceAsync(AddAttendanceDto model)
    {
        try
        {
            var attendance = await _context.Attendances.FindAsync(model.TeacherId);
            if (attendance == null) return new Response<BaseAttendanceDto>(HttpStatusCode.NoContent);
            _mapper.Map(model,attendance);
            return new Response<BaseAttendanceDto>(_mapper.Map<BaseAttendanceDto>(attendance));
        }
        catch (Exception ex)
        {
            return new Response<BaseAttendanceDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
