using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace training_service.model
{
    [Table("courses")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Column("course_code")]
        
        public string CourseCode { get; set; }

        [Column("duration_hours")]
        public int? DurationHours { get; set; }

        public string Level { get; set; }

        public string Category { get; set; }

        public decimal? Price { get; set; }

        public bool IsActive { get; set; } = true;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Many courses can be taught by one instructor
        [ForeignKey("InstructorId")]
        public long? InstructorId { get; set; }
        public Instructor? Instructor { get; set;}

        // One course can have many lessons
        public List<Lesson> Lessons { get; set; } = new();

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
}
