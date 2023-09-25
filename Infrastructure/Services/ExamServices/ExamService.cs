using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json.Serialization;

namespace Infrastructure;
public class ExamService : IExamService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ExamService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<BaseExamDto>> AddExamAsync(AddExamDto model)
    {
        try
        {
            var exam=new Exam() { 
                Name = model.Name,
                Date = model.Date,
                Type = model.Type,
            };
            await _context.Exams.AddAsync(exam);
            await _context.SaveChangesAsync();
            return new Response<BaseExamDto>(_mapper.Map<BaseExamDto>(exam));
        }
        catch (Exception ex)
        {
            return new Response<BaseExamDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<string>> DeleteExamAsync(int id)
    {
        try
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null) return new Response<string>(HttpStatusCode.NoContent);
            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted exam");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<GetExamDto>> GetExamByIdAsync(int id)
    {
        try
        {
            var exam = await _context.Exams.Select(e=>new GetExamDto() { 
                ExamId=e.ExamId,
                Date=e.Date,
                Name=e.Name,
                Type = e.Type,
                Results = e.Results
            }).FirstOrDefaultAsync(e=>e.ExamId==id);
            if (exam == null) return new Response<GetExamDto>(HttpStatusCode.NoContent);
            return new Response<GetExamDto>(exam);
        }
        catch (Exception ex)
        {
            return new Response<GetExamDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<GetExamDto>>> GetExamsAsync()
    {
        try
        {
            var exam = await _context.Exams.Select(e => new GetExamDto()
            {
                ExamId = e.ExamId,
                Date = e.Date,
                Name = e.Name,
                Type = e.Type,
                Results = e.Results
            }).ToListAsync();
            if (exam == null) return new Response<List<GetExamDto>>(HttpStatusCode.NoContent);
            return new Response<List<GetExamDto>>(exam);
        }
        catch (Exception ex)
        {
            return new Response<List<GetExamDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<BaseExamDto>> UpdateExamAsync(AddExamDto model)
    {
        try
        {
            var exam = await _context.Exams.FindAsync(model.ExamId);
            if (exam == null) return new Response<BaseExamDto>(HttpStatusCode.NoContent);
            exam.Name = model.Name;
            exam.Date = model.Date;
            exam.Type = model.Type;
            await _context.SaveChangesAsync();
            return new Response<BaseExamDto>(_mapper.Map<BaseExamDto>(exam));
        }
        catch (Exception ex)
        {
            return new Response<BaseExamDto>(HttpStatusCode.InternalServerError,ex.Message); 
        }
    }
}
