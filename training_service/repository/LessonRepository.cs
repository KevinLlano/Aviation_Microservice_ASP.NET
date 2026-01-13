using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using training_service.model;
using Microsoft.EntityFrameworkCore;

namespace training_service.repository
{
    public class LessonRepository
    {
        private readonly TrainingDbContext _context;

        public LessonRepository(TrainingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Lesson>> FindByCourseIdAsync(long courseId)
        {
            return await _context.Lessons
                .Where(l => l.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<List<Lesson>> FindByCourseIdOrderByLessonNumberAscAsync(long courseId)
        {
            return await _context.Lessons
                .Where(l => l.CourseId == courseId)
                .OrderBy(l => l.LessonNumber)
                .ToListAsync();
        }

        public async Task<List<Lesson>> FindByTypeAsync(LessonType type)
        {
            return await _context.Lessons
                .Where(l => l.Type == type)
                .ToListAsync();
        }

        public async Task<List<Lesson>> FindByIsMandatoryTrueAsync()
        {
            return await _context.Lessons
                .Where(l => l.IsMandatory)
                .ToListAsync();
        }

        public async Task<List<Lesson>> FindByCourseIdAndTypeAsync(long courseId, LessonType type)
        {
            return await _context.Lessons
                .Where(l => l.CourseId == courseId && l.Type == type)
                .ToListAsync();
        }
    }
}
