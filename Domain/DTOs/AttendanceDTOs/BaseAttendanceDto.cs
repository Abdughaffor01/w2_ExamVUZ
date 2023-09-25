using Domain.Entities;

namespace Domain;
public class BaseAttendanceDto
{
    public int TeacherId { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
}
