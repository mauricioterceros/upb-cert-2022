using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic.Managers;
using Logic.Entities;
using ActiveDirectoryService;

namespace WebApiCerti.Controllers
{
    [Route("/student-management")] // Attributes
    [ApiController]
    public class StudentController : ControllerBase
    {
        // Http Methods => GET, POST, PUT, DELETE
        // GET => Return an entity or list of an entity.
        // POST => Create an entity or list of an entity (bulk actions).
        // PUT => Update an entity... or list of an entity (bulk actions).
        // DELETE => DELETE an entity or list of an entity.

        // Other: PATCH

        private StudentManager _studentManager;
        private ADService _activeDirectoryService;

        public StudentController(StudentManager studentManager, ADService activeDirectoryService)
        {
            _activeDirectoryService = activeDirectoryService;
            _studentManager = studentManager;
        }

        [HttpGet]
        [Route("/student-management/students")]
        public IActionResult GetStudent([FromHeader] string userName, [FromHeader] string password)
        {
            if (_activeDirectoryService.IsUserValid(userName, password))
            {
                return Ok(_studentManager.GetStudents());
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("/student-management/students")]
        public IActionResult CreateStudent([FromHeader]string userName, [FromHeader]string password, [FromBody]WebApiCerti.Models.Student student)
        {
            if (_activeDirectoryService.IsUserValid(userName, password))
            {
                Student createdStudent = _studentManager.CreateStudent(student.Name, student.LastName);
                return Ok(createdStudent);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPut]
        [Route("/student-management/students")]
        public IActionResult UpdateStudent()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("/student-management/students")]
        public IActionResult DeleteStudent()
        {
            return Ok();
        }
    }
}