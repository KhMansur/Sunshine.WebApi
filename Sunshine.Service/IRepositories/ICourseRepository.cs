using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.IRepositories
{
    public interface ICourseRepository
    {
        Task Add(Course coure);

        Task<Course> GetById(Guid id);

        Task DeleteById(Guid id);

        Task Delete(Course course);

        Task<IList<Course>> GetAll();

        Task Update(Guid Id, Course course);
    }
}
