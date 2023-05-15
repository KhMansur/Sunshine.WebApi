using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.IRepositories
{
    public interface ITeacherRepository
    {
        Task Add(Teacher teacher);

        Task<Teacher> GetById(Guid id);

        Task DeleteById(Guid id);

        Task Delete(Teacher teacher);

        Task<IList<Teacher>> GetAll();

        Task Update(Guid Id, Teacher teacher);

        Task<Teacher> GetByName(string name);

        Task<int> NumberOfTeachers();
    }
}
