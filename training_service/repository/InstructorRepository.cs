using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using training_service.model;
using Microsoft.EntityFrameworkCore;

namespace training_service.repository
{
    public class InstructorRepository
    {
        private readonly TrainingDbContext _context;

        public InstructorRepository(TrainingDbContext context)
        {
            _context = context;
        }

        public async Task<Instructor> FindByEmailAsync(string email)
        {
            return await _context.Instructors
                .FirstOrDefaultAsync(i => i.Email == email);
        }

        public async Task<List<Instructor>> FindBySpecializationAsync(string specialization)
        {
            return await _context.Instructors
                .Where(i => i.Specialization == specialization)
                .ToListAsync();
        }

        public async Task<Instructor> FindByCertificationNumberAsync(string certificationNumber)
        {
            return await _context.Instructors
                .FirstOrDefaultAsync(i => i.CertificationNumber == certificationNumber);
        }

        public async Task<List<Instructor>> FindByYearsOfExperienceGreaterThanEqualAsync(int years)
        {
            return await _context.Instructors
                .Where(i => i.YearsOfExperience >= years)
                .ToListAsync();
        }
    }
}
