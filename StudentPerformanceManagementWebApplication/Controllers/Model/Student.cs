namespace StudentPerformanceManagementWebApplication.Controllers.Model
{
    public class Student
    {
        public int StudentId { get; set; } //properties
        public string FullName { get; set; }
        public string Department { get; set; }
        public int YearOfStudy { get; set; }
        public List<int> Marks { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
    }
}
