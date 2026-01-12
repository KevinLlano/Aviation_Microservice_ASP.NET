using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace training_service.model
{
    [Table("lessons")]
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Column("lesson_number")]
        public int? LessonNumber { get; set; }

        [Column("duration_minutes")]
        public int? DurationMinutes { get; set; }

        [Column("type")]
        public LessonType? Type { get; set; }

        public string Content { get; set; }

        [Column("is_mandatory")]
        public bool IsMandatory { get; set; } = true;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Many lessons belong to one course
        [ForeignKey("CourseId")]
        public long CourseId { get; set; }
        public Course Course { get; set; }

        // Set timestamps
        public void OnCreate()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void OnUpdate()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }

    public enum LessonType
    {
        THEORY,
        PRACTICAL,
        SIMULATOR,
        ASSESSMENT,
        GROUND_SCHOOL
    }
}
