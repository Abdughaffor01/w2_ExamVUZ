using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure;
public class SubjectService : ISubjectService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public SubjectService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<BaseSubjectDto>> AddSubjectAsync(AddSubjectDto model)
    {
        try
        {
            var subject = new Subject() { 
                Name = model.Name,
                Description = model.Description,
                Grade = model.Grade
            };
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            return new Response<BaseSubjectDto>(_mapper.Map<BaseSubjectDto>(subject));
        }
        catch (Exception ex)
        {
            return new Response<BaseSubjectDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<GetSubjectDto>> GetSubjectByIdAsync(int id)
    {
        try
        {
            var subject = await _context.Subjects.Select(s => new GetSubjectDto() { 
                SubjectId=s.SubjectId,    
                Name=s.Name,
                Grade=s.Grade,
                Description=s.Description,
                Results = s.Results
            }).FirstOrDefaultAsync(s=>s.SubjectId==id);
            if (subject == null) return new Response<GetSubjectDto>(HttpStatusCode.NoContent);
            return new Response<GetSubjectDto>(subject);
        }
        catch (Exception ex)
        {
            return new Response<GetSubjectDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<GetSubjectDto>>> GetSubjectsAsync()
    {
        try
        {
            var subjects = await _context.Subjects.Select(s => new GetSubjectDto()
            {
                SubjectId = s.SubjectId,
                Name = s.Name,
                Grade = s.Grade,
                Description = s.Description,
                Results = s.Results
            }).ToListAsync();
            if (subjects.Count == 0) return new Response<List<GetSubjectDto>>(HttpStatusCode.NoContent);
            return new Response<List<GetSubjectDto>>(subjects);
        }
        catch (Exception ex)
        {
            return new Response<List<GetSubjectDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<BaseSubjectDto>> UpdateSubjectAsync(AddSubjectDto model)
    {
        try
        {
            var subject = await _context.Subjects.FindAsync(model.SubjectId);
            if (subject == null) return new Response<BaseSubjectDto>(HttpStatusCode.NoContent);
            subject.Name = model.Name;
            subject.Description = model.Description;
            subject.Grade = model.Grade;
            await _context.SaveChangesAsync();
            return new Response<BaseSubjectDto>(_mapper.Map<BaseSubjectDto>(subject));
        }
        catch (Exception ex)
        {
            return new Response<BaseSubjectDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<string>> UpdateSubjectAsync(int id)
    {
        try
        {
            var subject=await _context.Subjects.FindAsync(id);
            if (subject == null) return new Response<string>(HttpStatusCode.NoContent);
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted subject");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}
