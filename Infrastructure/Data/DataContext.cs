using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<ClassroomStudent> ClassroomStudents { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Issues> Issues { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<TimeTable> TimeTables { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassroomStudent>().HasKey(cs=>new {cs.StudentId,cs.ClassroomId });
        modelBuilder.Entity<Result>().HasKey(r=>new {r.StudentId,r.SubjectId});
    }
}
