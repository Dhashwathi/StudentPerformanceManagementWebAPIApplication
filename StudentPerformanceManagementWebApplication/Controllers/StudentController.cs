using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPerformanceManagementWebApplication.Controllers.Services;
using StudentPerformanceManagementWebApplication.Controllers.Model;

namespace StudentPerformanceManagementWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //invoke interface
        private readonly IStudentService istudentService;
        public StudentController(IStudentService studentServiceobj)
        {
            istudentService= studentServiceobj;
        }
        [HttpPost]
        public IActionResult AddingNewStudent(AddUpdateStudent addnewStud)
        {
            var newStud = istudentService.AddStudent(addnewStud);
            return Ok(new
            {
                message = "success"
            });
        }
        [HttpGet]
        public IActionResult GetStudentList()
        {
            var allStudents = istudentService.GetAllStudents();
            return Ok(allStudents);
        }
    }
}
