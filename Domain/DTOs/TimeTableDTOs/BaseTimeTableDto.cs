using System.ComponentModel.DataAnnotations;

namespace Domain;
public class BaseTimeTableDto
{
    public int TT_Id { get; set; }
    public string Day { get; set; }
    public string Time { get; set; }
    public int SubjectId { get; set; }
}
