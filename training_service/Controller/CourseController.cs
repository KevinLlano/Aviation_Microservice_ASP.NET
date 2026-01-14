using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using training_service.model;
using training_service.services;

namespace training_service.Controller
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseById(long id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
                return NotFound();
            return Ok(course);
        }

        [HttpGet("code/{courseCode}")]
        public async Task<ActionResult<Course>> GetCourseByCourseCode(string courseCode)
        {
            var course = await _courseService.GetCourseByCourseCodeAsync(courseCode);
            if (course == null)
                return NotFound();
            return Ok(course);
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<List<Course>>> GetCoursesByCategory(string category)
        {
            var courses = await _courseService.GetCoursesByCategoryAsync(category);
            return Ok(courses);
        }

        [HttpGet("active")]
        public async Task<ActionResult<List<Course>>> GetActiveCourses()
        {
            var courses = await _courseService.GetActiveCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("instructor/{instructorId}")]
        public async Task<ActionResult<List<Course>>> GetCoursesByInstructor(long instructorId)
        {
            var courses = await _courseService.GetCoursesByInstructorAsync(instructorId);
            return Ok(courses);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse([FromBody] Course course)
        {
            var created = await _courseService.CreateCourseAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Course>> UpdateCourse(long id, [FromBody] Course course)
        {
            var updated = await _courseService.UpdateCourseAsync(id, course);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpPatch("{id}/toggle-status")]
        public async Task<ActionResult<Course>> ToggleCourseStatus(long id)
        {
            var toggled = await _courseService.ToggleCourseStatusAsync(id);
            if (toggled == null)
                return NotFound();
            return Ok(toggled);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(long id)
        {
            var deleted = await _courseService.DeleteCourseAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
