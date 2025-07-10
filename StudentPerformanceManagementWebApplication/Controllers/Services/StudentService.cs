using StudentPerformanceManagementWebApplication.Controllers.Model;

namespace StudentPerformanceManagementWebApplication.Controllers.Services
{
    public interface IStudentService
    {
        public Student AddStudent(AddUpdateStudent addUpdateStudentObj);
        public List<Student> GetAllStudents();
    }
    public class StudentService : IStudentService
    {
        private readonly List<Student> StudentList;
        public StudentService()
        {
            StudentList = new List<Student>()
            {
                new Student()
                {
                    StudentId=21001,
                    FullName="Dhashwathi",
                    Department="AI&DS",
                    YearOfStudy=2021,
                    Marks=new List<int>{100,90,80,50 },
                    DateOfBirth=new DateOnly(2004,09,10),
                    Email="dhash@123gmaail.com",
                    Gender="Female"
                }
            };
        }
        public Student AddStudent(AddUpdateStudent addUpdateStudentObj)
        {
            var addStud = new Student()
            {
                StudentId = StudentList.Max(o => o.StudentId) + 1,
                FullName = addUpdateStudentObj.FullName,
                Department=addUpdateStudentObj.Department,
                YearOfStudy = addUpdateStudentObj.YearOfStudy,
                Marks = addUpdateStudentObj.Marks,
                DateOfBirth = addUpdateStudentObj.DateOfBirth,
                Email = addUpdateStudentObj.Email,
                Gender = addUpdateStudentObj.Gender
            };
            StudentList.Add(addStud);
            return addStud;
        }
        public List<Student> GetAllStudents() {
            return StudentList.ToList(); 
        }
    }
}
