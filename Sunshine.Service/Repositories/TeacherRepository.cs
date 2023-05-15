using Microsoft.EntityFrameworkCore;
using Sunshine.Data.DBContext;
using Sunshine.Data.Models;
using Sunshine.Service.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        AppDbContext dbContext;
        public TeacherRepository(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task Add(Teacher teacher)
        {
            await dbContext.Teachers.AddAsync(teacher);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Teacher teacher)
        {
            dbContext.Teachers.Remove(teacher);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var teacher = await dbContext.Teachers.FirstOrDefaultAsync(s => s.Id == id);
            dbContext.Teachers.Remove(teacher);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Teacher>> GetAll()
        {
            return await dbContext.Teachers
                .Include(p => p.Groups)
                .Include(p => p.Speciality)
                .Include(p => p.TeacherPayments)
                .ToListAsync();
        }

        public async Task<Teacher> GetById(Guid id)
        {
            return await dbContext.Teachers
                .Include(p => p.Groups)
                .Include(p => p.Speciality)
                .Include(p => p.TeacherPayments)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Update(Guid id, Teacher newTeacher)
        {
            var oldTeacher = await dbContext.Teachers.FirstOrDefaultAsync(s => s.Id == id);
            dbContext.Teachers.Attach(oldTeacher).CurrentValues.SetValues(newTeacher);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Teacher> GetByName(string name)
        {
            return await dbContext.Teachers.FirstOrDefaultAsync(teacher => teacher.Firstname.ToLower().Contains(name.ToLower()) || teacher.Lastname.ToLower().Contains(name.ToLower()));
        }

        public async Task<int> NumberOfTeachers()
        {
            return await dbContext.Teachers.CountAsync();
        }
    }
}
