using training_service.model;

namespace training_service.repository
{
    public class CourseRepository
    {
        private readonly TrainingDbContext _context;

        public CourseRepository(TrainingDbContext context)
        {
            _context = context;
        }
        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        // Get course by ID
        public async Task<Course> GetByIdAsync(long id)
        {
            return await _context.Courses.FindAsync(id);
        }

        // Add a new course
        public async Task<Course> AddAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        // Update an existing course
        public async Task<Course> UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return course;
        }

        // Delete a course
        public async Task DeleteAsync(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
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
