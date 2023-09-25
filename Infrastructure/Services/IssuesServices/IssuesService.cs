using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure;
public class IssuesService : IIssuesService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public IssuesService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<BaseIssuesDto>> AddIssuesAsync(AddIssuesDto model)
    {
        try
        {
            var issus = _mapper.Map<Issues>(model);
            await _context.Issues.AddAsync(issus);
            await _context.SaveChangesAsync();
            return new Response<BaseIssuesDto>(_mapper.Map<BaseIssuesDto>(issus));
        }
        catch (Exception ex)
        {
            return new Response<BaseIssuesDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<string>> DeleteIssuesAsync(int id)
    {
        try
        {
            var issus = await _context.Issues.FindAsync(id);
            if (issus == null) return new Response<string>(HttpStatusCode.NoContent);
            _context.Issues.Remove(issus);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted issus");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<GetIssuesesDto>> GetIssuesByIdAsync(int id)
    {
        try
        {
            var issues=await _context.Issues.Select(i=>new GetIssuesesDto() { 
                StudentId=i.StudentId,
                Details=i.Details,
                IsResolved=i.IsResolved,
                Type = i.Type
            }).FirstOrDefaultAsync(i=>i.StudentId==id);
            if (issues == null) return new Response<GetIssuesesDto>(HttpStatusCode.NotFound);
            return new Response<GetIssuesesDto>(issues);

        }
        catch (Exception ex)
        {
            return new Response<GetIssuesesDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<GetIssuesesDto>>> GetIssuesesAsync()
    {
        try
        {
            var issues = await _context.Issues.Select(i => new GetIssuesesDto()
            {
                StudentId = i.StudentId,
                Details = i.Details,
                IsResolved = i.IsResolved,
                Type = i.Type
            }).ToListAsync();
            if (issues == null) return new Response<List<GetIssuesesDto>>(HttpStatusCode.NotFound);
            return new Response<List<GetIssuesesDto>>(issues);

        }
        catch (Exception ex)
        {
            return new Response<List<GetIssuesesDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<BaseIssuesDto>> UpdateIssuesAsync(AddIssuesDto model)
    {
        try
        {
            var issus = await _context.Issues.FindAsync(model.StudentId);
            if (issus == null) return new Response<BaseIssuesDto>(HttpStatusCode.NoContent);
            _mapper.Map(model,issus);
            await _context.SaveChangesAsync();
            return new Response<BaseIssuesDto>(_mapper.Map<BaseIssuesDto>(issus));
        }
        catch (Exception ex)
        {
            return new Response<BaseIssuesDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}
