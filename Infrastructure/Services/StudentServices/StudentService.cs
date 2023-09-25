using AutoMapper;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure;
public class StudentService : IStudentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public StudentService(DataContext context,IMapper mapper)
    {
        _mapper=mapper;
        _context = context;
    }

    public async Task<Response<StudentResultExamDto>> AddResultExamToStudent(StudentResultExamDto model)
    {
        try
        {
            var resultExam=_mapper.Map<Result>(model);
            await _context.Results.AddAsync(resultExam);
            await _context.SaveChangesAsync();
            return new Response<StudentResultExamDto>(_mapper.Map<StudentResultExamDto>(resultExam));
        }
        catch (Exception ex)
        {
            return new Response<StudentResultExamDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<BaseStudentDto>> AddStudentAsync(AddStudentDto model)
    {
        try
        {
            var student = new Student()
            {
                Name = model.Name,
                Address = model.Address,
                DOB = model.DOB,
                Email = model.Email,
                Password = model.Password,
                Phone = model.Phone,
                Date_Of_Join = DateTime.Now.ToShortDateString(),
                Parent_Name = model.Parent_Name,
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return new Response<BaseStudentDto>(_mapper.Map<BaseStudentDto>(student));
        }
        catch (Exception ex)
        {
            return new Response<BaseStudentDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<string>> DeleteResultExamToStudent(StudentResultExamDto model)
    {
        try
        {
            var resultExam = await _context.Results.FirstOrDefaultAsync(re=>re.ExamId==model.ExamId);
            if (resultExam == null) return new Response<string>(HttpStatusCode.NoContent);
            _context.Results.Remove(resultExam);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted result exam");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<string>> DeleteStudentAsync(int id)
    {
        try
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return new Response<string>(HttpStatusCode.NoContent);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted student");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int id)
    {
        try
        {
            var student = await _context.Students.Select(s=>new GetStudentDto() { 
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                DOB = s.DOB,
                Parent_Name = s.Parent_Name,
                Password = s.Password,
                Phone = s.Phone,
                Address=s.Address,
                Date_Of_Join = s.Date_Of_Join,
                Issueses = s.Issueses,
                Results = s.Results,
                ClassroomStudents=s.ClassroomStudents,
            }).FirstOrDefaultAsync(s=>s.Id==id);
            if (student == null) return new Response<GetStudentDto>(HttpStatusCode.NotFound);
            return new Response<GetStudentDto>(student);
        }
        catch (Exception ex)
        {
            return new Response<GetStudentDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<GetStudentDto>>> GetStudentsAsync()
    {
        try
        {
            var student = await _context.Students.Select(s => new GetStudentDto()
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                DOB = s.DOB,
                Parent_Name = s.Parent_Name,
                Password = s.Password,
                Phone = s.Phone,
                Address = s.Address,
                Date_Of_Join = s.Date_Of_Join,
                Issueses = s.Issueses,
                Results = s.Results,
                ClassroomStudents = s.ClassroomStudents,
            }).ToListAsync();
            if (student.Count == 0) return new Response<List<GetStudentDto>>(HttpStatusCode.NotFound);
            return new Response<List<GetStudentDto>>(student);
        }
        catch (Exception ex)
        {
            return new Response<List<GetStudentDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<BaseStudentDto>> UpdateStudentAsync(AddStudentDto model)
    {
        try
        {
            var student=await _context.Students.FindAsync(model.Id);
            if (student == null) return new Response<BaseStudentDto>(HttpStatusCode.NoContent);
            student.Name = model.Name;
            student.Address = model.Address;
            student.DOB = model.DOB;
            student.Email = model.Email;
            student.Password = model.Password;
            student.Phone = model.Phone;
            student.Parent_Name = model.Parent_Name;
            await _context.SaveChangesAsync();
            return new Response<BaseStudentDto>(_mapper.Map<BaseStudentDto>(student));
        }
        catch (Exception ex)
        {
            return new Response<BaseStudentDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}
