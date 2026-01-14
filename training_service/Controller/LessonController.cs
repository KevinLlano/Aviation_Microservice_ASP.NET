using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using training_service.model;       
using training_service.service;

namespace training_service.Controller
{
    [ApiController]
    [Route("api/lessons")]
    public class LessonController : ControllerBase
    {
        private readonly LessonService _lessonService;

        public LessonController(LessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lesson>>> GetAllLessons()
        {
            var lessons = await _lessonService.GetAllLessonsAsync();
            return Ok(lessons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lesson>> GetLessonById(long id)
        {
            var lesson = await _lessonService.GetLessonByIdAsync(id);
            if (lesson == null)
                return NotFound();
            return Ok(lesson);
        }

        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<List<Lesson>>> GetLessonsByCourse(long courseId)
        {
            var lessons = await _lessonService.GetLessonsByCourseIdAsync(courseId);
            return Ok(lessons);
        }

        [HttpGet("type/{type}")]
        public async Task<ActionResult<List<Lesson>>> GetLessonsByType(LessonType type)
        {
            var lessons = await _lessonService.GetLessonsByTypeAsync(type);
            return Ok(lessons);
        }

        [HttpGet("mandatory")]
        public async Task<ActionResult<List<Lesson>>> GetMandatoryLessons()
        {
            var lessons = await _lessonService.GetMandatoryLessonsAsync();
            return Ok(lessons);
        }

        [HttpPost]
        public async Task<ActionResult<Lesson>> CreateLesson([FromBody] Lesson lesson)
        {
            var created = await _lessonService.CreateLessonAsync(lesson);
            return CreatedAtAction(nameof(GetLessonById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Lesson>> UpdateLesson(long id, [FromBody] Lesson lesson)
        {
            var updated = await _lessonService.UpdateLessonAsync(id, lesson);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(long id)
        {
            var deleted = await _lessonService.DeleteLessonAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
