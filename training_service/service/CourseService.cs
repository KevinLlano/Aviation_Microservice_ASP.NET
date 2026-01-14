using System.Collections.Generic;
using System.Threading.Tasks;
using training_service.model;
using training_service.repository;

namespace training_service.services
{
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course> GetCourseByIdAsync(long id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task<Course> GetCourseByCourseCodeAsync(string courseCode)
        {
            return await _courseRepository.FindByCourseCodeAsync(courseCode);
        }

        public async Task<List<Course>> GetCoursesByCategoryAsync(string category)
        {
            return await _courseRepository.FindByCategoryAsync(category);
        }

        public async Task<List<Course>> GetActiveCoursesAsync()
        {
            return await _courseRepository.FindByIsActiveTrueAsync();
        }

        public async Task<List<Course>> GetCoursesByInstructorAsync(long instructorId)
        {
            return await _courseRepository.FindByInstructorIdAsync(instructorId);
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            return await _courseRepository.AddAsync(course);
        }

        public async Task<Course> UpdateCourseAsync(long id, Course courseDetails)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return null;

            course.Title = courseDetails.Title;
            course.Description = courseDetails.Description;
            course.CourseCode = courseDetails.CourseCode;
            course.Category = courseDetails.Category;
            course.DurationHours = courseDetails.DurationHours;
            course.Level = courseDetails.Level;
            course.Price = courseDetails.Price;
            course.IsActive = courseDetails.IsActive;
            course.Instructor = courseDetails.Instructor;

            return await _courseRepository.UpdateAsync(course);
        }

        public async Task<bool> DeleteCourseAsync(long id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return false;

            await _courseRepository.DeleteAsync(course);
            return true;
        }

        public async Task<Course> ToggleCourseStatusAsync(long id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return null;

            course.IsActive = !course.IsActive;
            return await _courseRepository.UpdateAsync(course);
        }
    }
}
