using AutoMapper;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure;
public class AutoMapperProfile:Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddStudentDto,Student>().ReverseMap();   
        CreateMap<BaseStudentDto,Student>().ReverseMap();


        CreateMap<AddTeacherDto,Teacher>().ReverseMap();
        CreateMap<BaseTeacherDto,Teacher>().ReverseMap();

        CreateMap<AddSubjectDto,Subject>().ReverseMap();
        CreateMap<BaseSubjectDto,Subject>().ReverseMap();

        CreateMap<Attendance,BaseAttendanceDto>().ReverseMap();
        CreateMap<Attendance,AddAttendanceDto>().ReverseMap();

        CreateMap<AddIssuesDto, Issues>().ReverseMap();
        CreateMap<BaseIssuesDto, Issues>().ReverseMap();

        CreateMap<AddClassroomDto, Classroom>().ReverseMap();
        CreateMap<BaseClassroomDto, Classroom>().ReverseMap();

        CreateMap<Exam, BaseExamDto>().ReverseMap();

        CreateMap<BaseTimeTableDto,TimeTable>().ReverseMap();

        CreateMap<StudentResultExamDto, Result>().ReverseMap();

        CreateMap<ClassroomStudentDto, ClassroomStudent>().ReverseMap();
    }
}
