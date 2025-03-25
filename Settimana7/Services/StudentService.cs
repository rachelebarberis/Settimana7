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
        public async Task<Student?> GetStudentByIdAsync(Guid id)
        {
            try
            {
                return await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch 
            {
          
                return null;
            }
        }

        public async Task<bool> DeleteStudentAsync(Guid id)
        {
            try
            {
                var existingStudent = await GetStudentByIdAsync(id);

                if (existingStudent == null)
                {
                    return false;
                }

                _context.Students.Remove(existingStudent);

                return await SaveAsync();
            }
            catch 
            {
            
                return false;
            }
        }

        public async Task<bool> UpdateStudentAsync(Guid id, Student student)
        {
            try
            {
                var existingStudent = await GetStudentByIdAsync(id);

                if (existingStudent == null)
                {
                    return false;
                }

                existingStudent.Nome = student.Nome;
                existingStudent.Cognome = student.Cognome;
                existingStudent.Email = student.Email;

         

                return await SaveAsync();
            }
            catch 
            {

                return false;
            }
        }
    }
}
    

