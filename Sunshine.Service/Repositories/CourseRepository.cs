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
    public class CourseRepository : ICourseRepository
    {
        AppDbContext dbContext;
        public CourseRepository(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task Add(Course course)
        {
            await dbContext.Courses.AddAsync(course);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Course course)
        {
            dbContext.Courses.Remove(course);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var course = await dbContext.Courses.FirstOrDefaultAsync(s => s.Id == id);
            dbContext.Courses.Remove(course);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Course>> GetAll()
        {
            return await dbContext.Courses.Include(p => p.Speciality).ToListAsync();
        }

        public async Task<Course> GetById(Guid id)
        {
            return await dbContext.Courses.Include(p => p.Speciality).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Update(Guid id, Course newCourse)
        {
            var oldCourse = await dbContext.Courses.FirstOrDefaultAsync(s => s.Id == id);
            dbContext.Courses.Attach(oldCourse).CurrentValues.SetValues(newCourse);
            await dbContext.SaveChangesAsync();
        }
    }
}
