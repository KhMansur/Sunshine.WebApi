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
    public class GroupRepository : IGroupRepository
    {
        AppDbContext dbContext;
        public GroupRepository(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task Add(Group group)
        {
            await dbContext.Groups.AddAsync(group);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Group group)
        {
            dbContext.Groups.Remove(group);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var group = await dbContext.Groups.FirstOrDefaultAsync(s => s.Id == id);
            dbContext.Groups.Remove(group);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Group>> GetAll()
        {
            return await dbContext.Groups
                .Include(p => p.Students)
                .Include(p => p.Course)
                .Include(p => p.StudentPayments)
                .Include(p => p.Teacher)
                    .ToListAsync();
        }

        public async Task<Group> GetById(Guid id)
        {
            return await dbContext.Groups
                .Include(p => p.Students)
                .Include(p => p.Course)
                .Include(p => p.StudentPayments)
                .Include(p => p.Teacher)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Update(Guid id, Group newGroup)
        {
            var oldGroup = await dbContext.Groups.FirstOrDefaultAsync(s => s.Id == id);
            dbContext.Groups.Attach(oldGroup).CurrentValues.SetValues(newGroup);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddStudentToGroup(Guid studentId, Guid groupId)
        {
            var group = await dbContext.Groups.FirstOrDefaultAsync(p => p.Id == groupId);
            var student = await dbContext.Students.FirstOrDefaultAsync(p => p.Id == studentId);
            group.Students.Add(student);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddStudentsToGroup(IList<Guid> studentIds, Guid groupId)
        {
            var group = await dbContext.Groups.FirstOrDefaultAsync(p => p.Id == groupId);
            var students = dbContext.Students.Where(p => studentIds.Contains(p.Id));
            await students.ForEachAsync(p => group.Students.Add(p));
            await dbContext.SaveChangesAsync();
        }
        
        public async Task DeleteStudentFromGroup(Guid studentId, Guid groupId)
        {
            var group = await dbContext.Groups.FirstOrDefaultAsync(p => p.Id == groupId);
            var student = await dbContext.Students.FirstOrDefaultAsync(p => p.Id == studentId);
            group.Students.Remove(student);
            await dbContext.SaveChangesAsync();
        }

        public async Task<int> NumberOfGroups()
        {
            return await dbContext.Groups.CountAsync();
        }
    }
}
