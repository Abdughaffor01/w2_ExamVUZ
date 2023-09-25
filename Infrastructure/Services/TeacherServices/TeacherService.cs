using AutoMapper;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure;
public class TeacherService : ITeacherService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public TeacherService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<BaseTeacherDto>> AddTeacherAsync(AddTeacherDto model)
    {
        try
        {
            var teacher = _mapper.Map<Teacher>(model);
            teacher.Date_Of_Join = DateTime.Now.ToShortDateString();
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return new Response<BaseTeacherDto>(_mapper.Map<BaseTeacherDto>(teacher));
        }
        catch (Exception ex)
        {
            return new Response<BaseTeacherDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<string>> DeleteTeacherAsync(int id)
    {
        try
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return new Response<string>(HttpStatusCode.NoContent);
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted teacher");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<GetTeacherDto>> GetTeacherByIdAsync(int id)
    {
        try
        {
            var teacher = await _context.Teachers.Select(t=>new GetTeacherDto() { 
                Id = t.Id,
                Name = t.Name,
                Address = t.Address,
                Email = t.Email,
                Password = t.Password,
                Phone = t.Phone,
                DOB = t.DOB,
                Date_Of_Join=t.Date_Of_Join,
                Attendance= t.Attendance,
                Classrooms= t.Classrooms
            }).FirstOrDefaultAsync(t=>t.Id==id);
            if (teacher == null) return new Response<GetTeacherDto>(HttpStatusCode.NoContent);
            return new Response<GetTeacherDto>(teacher);
        }
        catch (Exception ex)
        {
            return new Response<GetTeacherDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<GetTeacherDto>>> GetTeachersAsync()
    {
        try
        {
            var teachers = await _context.Teachers.Select(t => new GetTeacherDto()
            {
                Id = t.Id,
                Name = t.Name,
                Address = t.Address,
                Email = t.Email,
                Password = t.Password,
                Phone = t.Phone,
                DOB = t.DOB,
                Date_Of_Join = t.Date_Of_Join,
                Attendance = t.Attendance,
                Classrooms = t.Classrooms
            }).ToListAsync();
            if (teachers.Count == 0) return new Response<List<GetTeacherDto>>(HttpStatusCode.NoContent);
            return new Response<List<GetTeacherDto>>(teachers);
        }
        catch (Exception ex)
        {
            return new Response<List<GetTeacherDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<BaseTeacherDto>> UpdateTeacherAsync(AddTeacherDto model)
    {
        try
        {
            var teacher=await _context.Teachers.FindAsync(model.Id);
            if (teacher == null) return new Response<BaseTeacherDto>(HttpStatusCode.NoContent);
            var mapping = _mapper.Map(model,teacher);
            await _context.SaveChangesAsync();
            return new Response<BaseTeacherDto>(_mapper.Map<BaseTeacherDto>(teacher));
        }
        catch (Exception ex)
        {
            return new Response<BaseTeacherDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}
