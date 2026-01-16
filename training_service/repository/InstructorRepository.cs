using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using training_service.model;
using training_service.data;
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

        // CRUD Methods
        public async Task<List<Instructor>> GetAllAsync()
        {
            return await _context.Instructors.ToListAsync();
        }

        public async Task<Instructor> GetByIdAsync(long id)
        {
            return await _context.Instructors.FindAsync(id);
        }

        public async Task<Instructor> AddAsync(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return instructor;
        }

        public async Task<Instructor> UpdateAsync(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
            return instructor;
        }

        public async Task DeleteAsync(Instructor instructor)
        {
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
        }

        // Custom Queries
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
