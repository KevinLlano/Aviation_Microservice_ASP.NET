using System.Collections.Generic;
using System.Threading.Tasks;
using training_service.model;
using training_service.repository;

namespace training_service.service
{
    public class LessonService
    {
        private readonly LessonRepository _lessonRepository;

        public LessonService(LessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<List<Lesson>> GetAllLessonsAsync()
        {
            return await _lessonRepository.GetAllAsync();
        }

        public async Task<Lesson> GetLessonByIdAsync(long id)
        {
            return await _lessonRepository.GetByIdAsync(id);
        }

        public async Task<List<Lesson>> GetLessonsByCourseIdAsync(long courseId)
        {
            return await _lessonRepository.FindByCourseIdAsync(courseId);
        }

        public async Task<List<Lesson>> GetLessonsByCourseIdOrderedAsync(long courseId)
        {
            return await _lessonRepository.FindByCourseIdOrderByLessonNumberAscAsync(courseId);
        }

        public async Task<List<Lesson>> GetLessonsByTypeAsync(LessonType type)
        {
            return await _lessonRepository.FindByTypeAsync(type);
        }

        public async Task<List<Lesson>> GetMandatoryLessonsAsync()
        {
            return await _lessonRepository.FindByIsMandatoryTrueAsync();
        }

        public async Task<List<Lesson>> GetLessonsByCourseIdAndTypeAsync(long courseId, LessonType type)
        {
            return await _lessonRepository.FindByCourseIdAndTypeAsync(courseId, type);
        }

        public async Task<Lesson> CreateLessonAsync(Lesson lesson)
        {
            return await _lessonRepository.AddAsync(lesson);
        }

        public async Task<Lesson> UpdateLessonAsync(long id, Lesson lessonDetails)
        {
            var lesson = await _lessonRepository.GetByIdAsync(id);
            if (lesson == null) return null;

            lesson.Title = lessonDetails.Title;
            lesson.Description = lessonDetails.Description;
            lesson.LessonNumber = lessonDetails.LessonNumber;
            lesson.DurationMinutes = lessonDetails.DurationMinutes;
            lesson.Type = lessonDetails.Type;
            lesson.Content = lessonDetails.Content;
            lesson.IsMandatory = lessonDetails.IsMandatory;
            lesson.CourseId = lessonDetails.CourseId;

            return await _lessonRepository.UpdateAsync(lesson);
        }

        public async Task<bool> DeleteLessonAsync(long id)
        {
            var lesson = await _lessonRepository.GetByIdAsync(id);
            if (lesson == null) return false;

            await _lessonRepository.DeleteAsync(lesson);
            return true;
        }
    }
}
