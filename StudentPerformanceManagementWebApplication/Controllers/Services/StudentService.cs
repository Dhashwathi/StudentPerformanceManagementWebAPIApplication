using StudentPerformanceManagementWebApplication.Controllers.Model;

namespace StudentPerformanceManagementWebApplication.Controllers.Services
{
    public interface IStudentService //Creating interface
    {
        //Add method
        public Student AddStudent(AddUpdateStudent addUpdateStudentObj);
        //get method
        public List<Student> GetAllStudents();
        //Get student by Id
        public Student GetStudentById(int StudentId);
        //Update student By Id
        public Student UpdateStudentById(int StudentId, AddUpdateStudent updStudObject);
        //Delete method
        public bool DeleteStudent(int StudentId);
    }
    //Inheriting class class with interface
    public class StudentService : IStudentService
    {
        //In memory List with tye student
        private readonly List<Student> StudentList;
        public StudentService() //Creating Constructor
        {
            StudentList = new List<Student>()
            {
                //specifying initial values to properties
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
        //Implementing Add method
        public Student AddStudent(AddUpdateStudent addUpdateStudentObj)
        {
            var addStud = new Student()
            {
                StudentId = StudentList.Max(o => o.StudentId) + 1,
                FullName = addUpdateStudentObj.FullName,
                Department = addUpdateStudentObj.Department,
                YearOfStudy = addUpdateStudentObj.YearOfStudy,
                Marks = addUpdateStudentObj.Marks,
                DateOfBirth = addUpdateStudentObj.DateOfBirth,
                Email = addUpdateStudentObj.Email,
                Gender = addUpdateStudentObj.Gender
            };
            StudentList.Add(addStud); //Added to list
            return addStud;
        }
        //Implementing Get method
        public List<Student> GetAllStudents()
        {
            return StudentList.ToList();
        }

        //implementing get by studentID
        public Student GetStudentById(int InputStudentId)
        {
            var SelectStud = StudentList.FirstOrDefault(s => s.StudentId == InputStudentId);
            return SelectStud;

        }
        //implementing Update Student 
        public Student UpdateStudentById(int InputStudentId, AddUpdateStudent updateobj)
        {
            var selectStud = StudentList.FirstOrDefault(s => s.StudentId == InputStudentId);
            if (selectStud != null)
            {
                selectStud.FullName = updateobj.FullName;
                selectStud.Department = updateobj.Department;
                selectStud.YearOfStudy = updateobj.YearOfStudy;
                selectStud.Marks = updateobj.Marks;
                selectStud.DateOfBirth = updateobj.DateOfBirth;
                selectStud.Gender = updateobj.Gender;
                selectStud.Email = updateobj.Email;
                return selectStud;
            }
            else
            {
                return null;
            }

        }
        //implementing Delete student method
        public bool DeleteStudent(int InputStudentId)
        {
            //Check the studentId exists
            var removeStudent = StudentList.FirstOrDefault(o => o.StudentId == InputStudentId);
            if (removeStudent != null)
            {
                StudentList.Remove(removeStudent);
                return true;
            }
            return false;
        }
        
    }
}
