namespace UniversityApi.Models
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public List<string> Courses { get; set; } = new List<string>();
    }
}
