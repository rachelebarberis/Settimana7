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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _studentService.GetStudentByIdAsync(id);

            return result != null ? Ok(new { message = "Student found", customer = result }) : BadRequest(new { message = "Something went wrong" });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _studentService.DeleteStudentAsync(id);

            return result ? Ok(new { message = "Customer deleted" }) : BadRequest(new { message = "Something went wrong" });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody] Student student)
        {
            var result = await _studentService.UpdateStudentAsync(id, student);

            return result ? Ok(new { message = "Student updated" }) : BadRequest(new { message = "Something went wrong" });
        }
    }
}
    


