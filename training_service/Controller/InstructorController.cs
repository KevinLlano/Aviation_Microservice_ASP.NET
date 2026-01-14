using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using training_service.model;
using training_service.service;

namespace training_service.Controller
{
    [ApiController]
    [Route("api/instructors")]
    public class InstructorController : ControllerBase
    {
        private readonly InstructorService _instructorService;

        public InstructorController(InstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Instructor>>> GetAllInstructors()
        {
            var instructors = await _instructorService.GetAllInstructorsAsync();
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Instructor>> GetInstructorById(long id)
        {
            var instructor = await _instructorService.GetInstructorByIdAsync(id);
            if (instructor == null)
                return NotFound();
            return Ok(instructor);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<Instructor>> GetInstructorByEmail(string email)
        {
            var instructor = await _instructorService.GetInstructorByEmailAsync(email);
            if (instructor == null)
                return NotFound();
            return Ok(instructor);
        }

        [HttpGet("specialization/{specialization}")]
        public async Task<ActionResult<List<Instructor>>> GetInstructorsBySpecialization(string specialization)
        {
            var instructors = await _instructorService.GetInstructorsBySpecializationAsync(specialization);
            return Ok(instructors);
        }

        [HttpGet("experienced")]
        public async Task<ActionResult<List<Instructor>>> GetExperiencedInstructors([FromQuery] int minYears = 5)
        {
            var instructors = await _instructorService.GetExperiencedInstructorsAsync(minYears);
            return Ok(instructors);
        }

        [HttpPost]
        public async Task<ActionResult<Instructor>> CreateInstructor([FromBody] Instructor instructor)
        {
            var created = await _instructorService.CreateInstructorAsync(instructor);
            return CreatedAtAction(nameof(GetInstructorById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Instructor>> UpdateInstructor(long id, [FromBody] Instructor instructor)
        {
            var updated = await _instructorService.UpdateInstructorAsync(id, instructor);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(long id)
        {
            var deleted = await _instructorService.DeleteInstructorAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
