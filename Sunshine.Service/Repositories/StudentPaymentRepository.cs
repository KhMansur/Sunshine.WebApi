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
    public class StudentPaymentRepository : IStudentPaymentRepository
    {
        AppDbContext dbContext;
        public StudentPaymentRepository(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task Add(StudentPayment studentPayment)
        {
            await dbContext.StudentPayments.AddAsync(studentPayment);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(StudentPayment studentPayment)
        {
            dbContext.StudentPayments.Remove(studentPayment);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var studentPayment = await dbContext.StudentPayments.FirstOrDefaultAsync(s => s.Id == id);
            dbContext.StudentPayments.Remove(studentPayment);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<StudentPayment>> GetAll()
        {
            return await dbContext.StudentPayments
                .Include(p => p.Group)
                .Include(p => p.Student)
                .ToListAsync();
        }

        public async Task<StudentPayment> GetById(Guid id)
        {
            return await dbContext.StudentPayments
                .Include(p => p.Group)
                .Include(p => p.Student)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IList<StudentPayment>> LastNStudentPayments(int n)
        {
            return await dbContext.StudentPayments.TakeLast(n).ToListAsync();
        }

        public async Task Update(Guid id, StudentPayment newStudentPayment)
        {
            var oldStudentPayment = await dbContext.StudentPayments.FirstOrDefaultAsync(s => s.Id == id);
            dbContext.StudentPayments.Attach(oldStudentPayment).CurrentValues.SetValues(newStudentPayment);
            await dbContext.SaveChangesAsync();
        }
    }
}
