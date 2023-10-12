using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;
        public StudentController(IStudentLogic studentLogic)
        {
            _studentLogic = studentLogic;
        }


        [HttpPost]
        public IActionResult PostStudent([FromBody] Student student)
        {
            if(student == null)
                throw new Exception("Null Student");
            
            _studentLogic.InsertStudents(student);
            return Ok(student);
        }

        
        [HttpGet]
        public IActionResult GetAll([FromQuery] int age)
        {
            return Ok(_studentLogic.GetStudents(age));
        }

        [AuthorizationFilter()]
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_studentLogic.GetStudentById(id));
        }
    }
}
