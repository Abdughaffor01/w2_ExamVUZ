namespace Domain;
public class BaseStudentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DOB { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Parent_Name { get; set; }
}
