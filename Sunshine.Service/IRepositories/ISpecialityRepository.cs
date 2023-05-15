using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.IRepositories
{
    public interface ISpecialityRepository
    {
        Task Add(Speciality speciality);

        Task<Speciality> GetById(Guid id);

        Task DeleteById(Guid id);

        Task Delete(Speciality speciality);

        Task<IList<Speciality>> GetAll();

        Task Update(Guid Id, Speciality speciality);
    }
}
