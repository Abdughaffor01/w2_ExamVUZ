using System.ComponentModel.DataAnnotations;

namespace Domain;
public class BaseClassroomDto
{
    public int ClassroomId { get; set; }
    public int Grade { get; set; }
    public int TeacherId { get; set; }
}
