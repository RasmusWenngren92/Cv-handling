using Cv_handling.Data;
using Cv_handling.DTOs;
using Cv_handling.Models;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling.UserServices;

public class UserService
{
    
        private readonly CvDbContext context;

        public UserService(CvDbContext _context)
        {
            context = _context;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var users = await context.Users.Select(u => new UserDto
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                EmailAddress = u.EmailAddress,

            }).ToListAsync();
            return users;
        }
        public async Task<List<EducationDto>> GetEducations()
        {
            var educations = await context.Educations.Select(e => new EducationDto
            {
                SchoolName = e.SchoolName,
                Degree = e.Degree,
                StartYear = e.StartYear,
                GraduationYear = e.GraduationYear,

            }).ToListAsync();
            return educations;
        }        
        public async Task<List<WorkDto>> GetWorks()
        {
            var works = await context.Works.Select(w => new WorkDto
            {
             Title = w.Title,
             Description = w.Description,
             Company = w.Company,
             StartYear = w.StartYear,
             EndYear = w.EndYear,

            }).ToListAsync();
            return works;
        }
        
}