using Microsoft.AspNetCore.Mvc;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private static List<Course> courses = new List<Course>
        {
            new Course { Id = "BIM308", Title = "Web Server Programming", Classroom = "B6" }
        };

        
        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            return Ok(courses);
        }

        
        [HttpGet("{id}")]
        public ActionResult<Course> GetCourse(string id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound();
            return Ok(course);
        }

        
        [HttpPost]
        public ActionResult<Course> CreateCourse([FromBody] Course newCourse)
        {
            courses.Add(newCourse);
            return CreatedAtAction(nameof(GetCourse), new { id = newCourse.Id }, newCourse);
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(string id, [FromBody] Course updatedCourse)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound();
            course.Title = updatedCourse.Title;
            course.Classroom = updatedCourse.Classroom;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(string id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound();
            courses.Remove(course);
            return NoContent();
        }
    }
}
