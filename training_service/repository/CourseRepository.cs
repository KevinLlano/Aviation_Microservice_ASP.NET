using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using training_service.model;
using Microsoft.EntityFrameworkCore;

namespace training_service.repository
{
    public class CourseRepository
    {
        private readonly TrainingDbContext _context;

        public CourseRepository(TrainingDbContext context)
        {
            _context = context;
        }

        public async Task<Course> FindByCourseCodeAsync(string courseCode)
        {
            return await _context.Courses
                .FirstOrDefaultAsync(c => c.CourseCode == courseCode);
        }

        public async Task<List<Course>> FindByCategoryAsync(string category)
        {
            return await _context.Courses
                .Where(c => c.Category == category)
                .ToListAsync();
        }

        public async Task<List<Course>> FindByIsActiveTrueAsync()
        {
            return await _context.Courses
                .Where(c => c.IsActive)
                .ToListAsync();
        }

        public async Task<List<Course>> FindByInstructorIdAsync(long instructorId)
        {
            return await _context.Courses
                .Where(c => c.InstructorId == instructorId)
                .ToListAsync();
        }

        public async Task<List<Course>> FindByCategoryAndIsActiveTrueAsync(string category)
        {
            return await _context.Courses
                .Where(c => c.Category == category && c.IsActive)
                .ToListAsync();
        }
    }
}
