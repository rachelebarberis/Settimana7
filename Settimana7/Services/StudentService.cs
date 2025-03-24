using Microsoft.EntityFrameworkCore;
using Settimana7.Data;
using Settimana7.Models;

namespace Settimana7.Services
{
    public class StudentService
    {
        private ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            } 
            catch
            {
                return false;
            }
        }

        public async Task<bool>CreateStudentAsync(Student student)
        {
            try
            {
                _context.Students.Add(student);
             return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Student>?> GetStudentsAsync()
        {
            try
            {
                return await _context.Students.ToListAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
