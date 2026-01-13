using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace training_service.model
{
    [Table("instructors")]
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Column("email")]
        
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Specialization { get; set; }

        [Column("years_experience")]
        public int? YearsOfExperience { get; set; }

        [Column("certification_number")]
        public string CertificationNumber { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // One instructor can teach many courses
        public List<Course> Courses { get; set; } = new();

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
