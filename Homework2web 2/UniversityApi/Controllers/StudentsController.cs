using Microsoft.AspNetCore.Mvc;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private static List<Student> students = new List<Student>
        {
            new Student 
            { 
                Id = 44488883333, 
                Name = "Emin Talip Demirkiran", 
                Email = "etd@eskisehir.edu.tr", 
                Courses = new List<string> { "BIM308", "BIM439", "BBO102" } 
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(long id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent([FromBody] Student newStudent)
        {
            students.Add(newStudent);
            return CreatedAtAction(nameof(GetStudent), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(long id, [FromBody] Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();
            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.Courses = updatedStudent.Courses;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(long id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();
            students.Remove(student);
            return NoContent();
        }
    }
}
