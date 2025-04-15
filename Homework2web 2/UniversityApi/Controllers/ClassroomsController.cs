using Microsoft.AspNetCore.Mvc;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/classrooms")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private static List<Classroom> classrooms = new List<Classroom>
        {
            new Classroom { Id = "B6", Description = "Computer Engineering Ground Floor", Capacity = 60 }
        };

        // GET: api/classrooms
        [HttpGet]
        public ActionResult<IEnumerable<Classroom>> GetClassrooms()
        {
            return Ok(classrooms);
        }

        // GET: api/classrooms/{id}
        [HttpGet("{id}")]
        public ActionResult<Classroom> GetClassroom(string id)
        {
            var classroom = classrooms.FirstOrDefault(c => c.Id == id);
            if (classroom == null)
                return NotFound();
            return Ok(classroom);
        }
    }
}
