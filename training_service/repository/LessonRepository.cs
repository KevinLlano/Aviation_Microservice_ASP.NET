using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using training_service.model;
using training_service.data;
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

        // CRUD Methods
        public async Task<List<Lesson>> GetAllAsync()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<Lesson> GetByIdAsync(long id)
        {
            return await _context.Lessons.FindAsync(id);
        }

        public async Task<Lesson> AddAsync(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task<Lesson> UpdateAsync(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task DeleteAsync(Lesson lesson)
        {
            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
        }

        // Custom Queries
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
