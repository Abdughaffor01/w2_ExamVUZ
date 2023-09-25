using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure;
public class ClassroomService : IClassroomService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ClassroomService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<BaseClassroomDto>> AddClassroomAsync(AddClassroomDto model)
    {
        try
        {
            var classroom = new Classroom() { 
                Grade = model.Grade,
                TeacherId = model.TeacherId,
            };
            await _context.Classrooms.AddAsync(classroom);
            await _context.SaveChangesAsync();
            return new Response<BaseClassroomDto>(_mapper.Map<BaseClassroomDto>(classroom));
        }
        catch (Exception ex)
        {
            return new Response<BaseClassroomDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<ClassroomStudentDto>> AddStudentToClassromAsync(ClassroomStudentDto model)
    {
        try
        {
            var studentClass = _mapper.Map<ClassroomStudent>(model);
            await _context.ClassroomStudents.AddAsync(studentClass);
            await _context.SaveChangesAsync();
            return new Response<ClassroomStudentDto>(_mapper.Map<ClassroomStudentDto>(studentClass));
        }
        catch (Exception ex)
        {
            return new Response<ClassroomStudentDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<string>> DeleteClassroomAsync(int id)
    {
        try
        {
            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom == null) return new Response<string>(HttpStatusCode.NoContent);
            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted classroom");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<string>> DeleteStudentFromClassromAsync(int id)
    {
        try
        {
            var studentClassroom = await _context.ClassroomStudents.FirstOrDefaultAsync(sc=>sc.StudentId==id);
            if (studentClassroom == null) return new Response<string>(HttpStatusCode.NoContent);
            _context.ClassroomStudents.Remove(studentClassroom);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted student in classroom");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<GetClassroomDto>> GetClassroomByIdAsync(int id)
    {
        try
        {
            var classroom=await _context.Classrooms.Select(c=>new GetClassroomDto() { 
                ClassroomId=c.ClassroomId,
                TeacherId=c.TeacherId,
                Grade=c.Grade,
                Subjects=c.Subjects,
                ClassroomStudents = c.ClassroomStudents
            }).FirstOrDefaultAsync(c=>c.ClassroomId==id);
            if (classroom == null) return new Response<GetClassroomDto>(HttpStatusCode.NoContent);
            return new Response<GetClassroomDto>(classroom);
        }
        catch (Exception ex)
        {
            return new Response<GetClassroomDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<GetClassroomDto>>> GetClassroomsAsync()
    {
        try
        {
            var classrooms = await _context.Classrooms.Select(c => new GetClassroomDto()
            {
                ClassroomId = c.ClassroomId,
                TeacherId = c.TeacherId,
                Grade = c.Grade,
                Subjects = c.Subjects,
                ClassroomStudents = c.ClassroomStudents
            }).ToListAsync();
            if (classrooms == null) return new Response<List<GetClassroomDto>>(HttpStatusCode.NoContent);
            return new Response<List<GetClassroomDto>>(classrooms);
        }
        catch (Exception ex)
        {
            return new Response<List<GetClassroomDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<BaseClassroomDto>> UpdateClassroomAsync(AddClassroomDto model)
    {
        try
        {
            var classroom = await _context.Classrooms.FindAsync(model.ClassroomId);
            if (classroom == null) return new Response<BaseClassroomDto>(HttpStatusCode.NoContent);
            classroom.TeacherId = model.TeacherId;
            classroom.Grade = model.Grade;
            await _context.SaveChangesAsync();
            return new Response<BaseClassroomDto>(_mapper.Map<BaseClassroomDto>(classroom));
        }
        catch (Exception ex)
        {
            return new Response<BaseClassroomDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}
