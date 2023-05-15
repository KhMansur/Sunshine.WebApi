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
    public class TeacherPaymentRepository : ITeacherPaymentRepository
    {
        AppDbContext dbContext;
        public TeacherPaymentRepository(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task Add(TeacherPayment teacherPayment)
        {
            await dbContext.TeacherPayments.AddAsync(teacherPayment);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(TeacherPayment teacherPayment)
        {
            dbContext.TeacherPayments.Remove(teacherPayment);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var teacherPayment = await dbContext.TeacherPayments.FirstOrDefaultAsync(s => s.Id == id);
            dbContext.TeacherPayments.Remove(teacherPayment);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<TeacherPayment>> GetAll()
        {
            return await dbContext.TeacherPayments
                .Include(p => p.Teacher)
                .Include(p => p.StudentPayments)
                .ToListAsync();
        }

        public async Task<TeacherPayment> GetById(Guid id)
        {
            return await dbContext.TeacherPayments
                .Include(p => p.Teacher)
                .Include(p => p.StudentPayments)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Update(Guid id, TeacherPayment newTeacherPayment)
        {
            var oldTeacherPayment = await dbContext.TeacherPayments.FirstOrDefaultAsync(s => s.Id == id);
            dbContext.TeacherPayments.Attach(oldTeacherPayment).CurrentValues.SetValues(newTeacherPayment);
            await dbContext.SaveChangesAsync();
        }
    }
}
