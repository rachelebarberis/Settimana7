using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Settimana7.Models;
using Settimana7.Services;

namespace Settimana7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            var result = await _studentService.CreateStudentAsync(student);
            if (!result)
            {
                return BadRequest(new
                {
                    message = "Error"
                });

            }
            return Ok(new
            {
                message = "Aggiunto!"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var studentsList = await _studentService.GetStudentsAsync();
            if(studentsList == null)
            {
                return BadRequest(new
                {
                    message = "Error"
                });
            }
            if(!studentsList.Any())
            {
                return NoContent();
            }

            var count = studentsList.Count();
            var text = count == 1 ? $"{count} studente trovato" : $"{count} studenti trovati"; 

            return Ok(new
            {
                message = text,
                students = studentsList

            });
        }
    }
}

