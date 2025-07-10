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
        [HttpPost] //Post Method
        public IActionResult AddingNewStudent(AddUpdateStudent addnewStud)
        {
            var newStud = istudentService.AddStudent(addnewStud);
            return Ok(new
            {
                message = "success"
            });
        }
        [HttpGet] //Get method
        public IActionResult GetStudentList()
        {
            var allStudents = istudentService.GetAllStudents();
            return Ok(allStudents);
        }
        //get by ID method
        [HttpGet]
        [Route("{StudId}")]
        public IActionResult GetByStudentID(int StudId)
        {
            //call the seive method
            var fetchByStudId= istudentService.GetStudentById(StudId);
            if (fetchByStudId != null)
            {
                return Ok(fetchByStudId);
            }
            else
            {
                return NotFound();
            }
        }
        //Udpate Method
        [HttpPut]
        public IActionResult UpdateMethodByStudentID(int StudID, AddUpdateStudent updStud)
        {
            var updstudbyid = istudentService.UpdateStudentById(StudID, updStud);
            if (updstudbyid != null)
            {
                return Ok(updstudbyid);
            }
            else
            {
                return Ok(new
                {
                    message = "Invalid Student ID"
                });
            }

        }
        //Delete 
        [HttpDelete]
        public IActionResult DeleteByStudID(int StudID)
        {
            //Call the Service Delete method
            var DeleteStudentByID = istudentService.DeleteStudent(StudID);
            if(DeleteStudentByID== true)
            {
                return Ok(new
                {
                    message = "Student Deleted Successfully"
                });
            }
            return NotFound();
        }
    }
}
