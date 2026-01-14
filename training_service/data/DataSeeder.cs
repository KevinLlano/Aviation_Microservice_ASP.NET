using training_service.model;

namespace training_service.data
{
    public static class DataSeeder
    {
        public static void SeedData(TrainingDbContext context)
        {
            
            if (context.Instructors.Any())
            {
                return; 
            }

            // Instructors
            var instructor1 = new Instructor
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@aviation.com",
                Phone = "555-0101",
                Specialization = "Flight Training",
                YearsOfExperience = 15,
                CertificationNumber = "CFI-12345"
            };

            var instructor2 = new Instructor
            {
                FirstName = "Sarah",
                LastName = "Johnson",
                Email = "sarah.johnson@aviation.com",
                Phone = "555-0102",
                Specialization = "Aircraft Maintenance",
                YearsOfExperience = 10,
                CertificationNumber = "AMT-67890"
            };

            context.Instructors.AddRange(instructor1, instructor2);
            context.SaveChanges();

            // Courses
            var course1 = new Course
            {
                Title = "Private Pilot License (PPL)",
                Description = "Complete ground school and flight training for Private Pilot License",
                CourseCode = "PPL-101",
                Category = "Flight Training",
                DurationHours = 60,
                Level = "Beginner",
                Price = 8500.00m,
                IsActive = true,
                InstructorId = instructor1.Id
            };

            var course2 = new Course
            {
                Title = "Aircraft Maintenance Basics",
                Description = "Introduction to aircraft maintenance procedures and safety",
                CourseCode = "AMT-101",
                Category = "Maintenance",
                DurationHours = 40,
                Level = "Beginner",
                Price = 3500.00m,
                IsActive = true,
                InstructorId = instructor2.Id
            };

            context.Courses.AddRange(course1, course2);
            context.SaveChanges();

            // Lessons for Course 1
            var lesson1 = new Lesson
            {
                Title = "Introduction to Aviation",
                Description = "Overview of aviation principles and regulations",
                LessonNumber = 1,
                DurationMinutes = 120,
                Type = LessonType.THEORY,
                Content = "https://materials.aviation.com/ppl/intro",
                IsMandatory = true,
                CourseId = course1.Id
            };

            var lesson2 = new Lesson
            {
                Title = "Pre-Flight Inspection",
                Description = "Learn proper pre-flight inspection procedures",
                LessonNumber = 2,
                DurationMinutes = 90,
                Type = LessonType.PRACTICAL,
                Content = "https://materials.aviation.com/ppl/preflight",
                IsMandatory = true,
                CourseId = course1.Id
            };

            var lesson3 = new Lesson
            {
                Title = "First Solo Flight",
                Description = "Your first solo flight experience",
                LessonNumber = 3,
                DurationMinutes = 60,
                Type = LessonType.PRACTICAL,
                Content = "https://materials.aviation.com/ppl/solo",
                IsMandatory = true,
                CourseId = course1.Id
            };

            // Lesson for Course 2
            var lesson4 = new Lesson
            {
                Title = "Safety Procedures",
                Description = "Essential safety procedures for aircraft maintenance",
                LessonNumber = 1,
                DurationMinutes = 90,
                Type = LessonType.GROUND_SCHOOL,
                Content = "https://materials.aviation.com/amt/safety",
                IsMandatory = true,
                CourseId = course2.Id
            };

            context.Lessons.AddRange(lesson1, lesson2, lesson3, lesson4);
            context.SaveChanges();

            Console.WriteLine("Sample data loaded successfully!");
        }
    }
}
