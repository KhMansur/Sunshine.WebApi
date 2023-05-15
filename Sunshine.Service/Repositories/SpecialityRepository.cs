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
    public class SpecialityRepository : ISpecialityRepository
    {
        AppDbContext dbContext;
        public SpecialityRepository(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task Add(Speciality speciality)
        {
            await dbContext.Specialities.AddAsync(speciality);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Speciality speciality)
        {
            dbContext.Specialities.Remove(speciality);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var speciality = await dbContext.Specialities.FirstOrDefaultAsync(s => s.Id == id);
            dbContext.Specialities.Remove(speciality);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Speciality>> GetAll()
        {
            return await dbContext.Specialities.ToListAsync();
        }

        public async Task<Speciality> GetById(Guid id)
        {
            return await dbContext.Specialities.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Update(Guid id, Speciality newSpeciality)
        {
            var oldSpeciality = await dbContext.Specialities.FirstOrDefaultAsync(s => s.Id == id);
            dbContext.Specialities.Attach(oldSpeciality).CurrentValues.SetValues(newSpeciality);
            await dbContext.SaveChangesAsync();
        }
    }
}
