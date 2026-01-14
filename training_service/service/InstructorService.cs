using System.Collections.Generic;
using System.Threading.Tasks;
using training_service.model;
using training_service.repository;

namespace training_service.service
{
    public class InstructorService
    {
        private readonly InstructorRepository _instructorRepository;

        public InstructorService(InstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<List<Instructor>> GetAllInstructorsAsync()
        {
            return await _instructorRepository.GetAllAsync();
        }

        public async Task<Instructor> GetInstructorByIdAsync(long id)
        {
            return await _instructorRepository.GetByIdAsync(id);
        }

        public async Task<Instructor> GetInstructorByEmailAsync(string email)
        {
            return await _instructorRepository.FindByEmailAsync(email);
        }

        public async Task<List<Instructor>> GetInstructorsBySpecializationAsync(string specialization)
        {
            return await _instructorRepository.FindBySpecializationAsync(specialization);
        }

        public async Task<Instructor> CreateInstructorAsync(Instructor instructor)
        {
            return await _instructorRepository.AddAsync(instructor);
        }

        public async Task<Instructor> UpdateInstructorAsync(long id, Instructor instructorDetails)
        {
            var instructor = await _instructorRepository.GetByIdAsync(id);
            if (instructor == null) return null;

            instructor.FirstName = instructorDetails.FirstName;
            instructor.LastName = instructorDetails.LastName;
            instructor.Email = instructorDetails.Email;
            instructor.Phone = instructorDetails.Phone;
            instructor.Specialization = instructorDetails.Specialization;
            instructor.YearsOfExperience = instructorDetails.YearsOfExperience;
            instructor.CertificationNumber = instructorDetails.CertificationNumber;

            return await _instructorRepository.UpdateAsync(instructor);
        }

        public async Task<bool> DeleteInstructorAsync(long id)
        {
            var instructor = await _instructorRepository.GetByIdAsync(id);
            if (instructor == null) return false;

            await _instructorRepository.DeleteAsync(instructor);
            return true;
        }

        public async Task<List<Instructor>> GetExperiencedInstructorsAsync(int minYears)
        {
            return await _instructorRepository.FindByYearsOfExperienceGreaterThanEqualAsync(minYears);
        }
    }
}
