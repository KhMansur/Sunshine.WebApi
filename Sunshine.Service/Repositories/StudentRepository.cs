using Microsoft.EntityFrameworkCore;
using Sunshine.Data.DBContext;
using Sunshine.Data.Models;
using Sunshine.Service.IRepositories;
namespace Sunshine.Service.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        AppDbContext dbContext;
        public StudentRepository(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        
        public async Task Add(Student student)
        {
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Student student)
        {
            dbContext.Students.Remove(student);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var student = await dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            dbContext.Students.Remove(student);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Student>> GetAll()
        {
            return await dbContext.Students
                .Include(p => p.Groups)
                .Include(p => p.Payments)
                .ToListAsync();
        }

        public async Task<Student> GetById(Guid id)
        {
            return await dbContext.Students
                .Include(p => p.Groups)
                .Include(p => p.Payments)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Update(Guid id, Student newStudent)
        {
            var oldStudent = await dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            dbContext.Students.Attach(oldStudent).CurrentValues.SetValues(newStudent);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddStudentToGroup(Guid studentId, Guid groupId)
        {
            var student = await dbContext.Students.FirstOrDefaultAsync(student => student.Id == studentId);
            var group = await dbContext.Groups.FirstOrDefaultAsync(group => group.Id == groupId);
            student.Groups.Add(group);
            await dbContext.SaveChangesAsync();
        }

        public async Task<int> NumberOfStudents()
        {
            return await dbContext.Students.CountAsync();
        }
    }
}
