using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var con = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddDbContext<DataContext>(c=>c.UseNpgsql(con));
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<ITeacherService,TeacherService>();
builder.Services.AddScoped<ISubjectService,SubjectService>();
builder.Services.AddScoped<IAttendanceService,AttendanceService>();
builder.Services.AddScoped<IClassroomService,ClassroomService>();
builder.Services.AddScoped<IExamService,ExamService>();
builder.Services.AddScoped<IIssuesService,IssuesService>();
builder.Services.AddScoped<ITimeTableService,TimeTableService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
