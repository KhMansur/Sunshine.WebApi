using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.IRepositories
{
    public interface IStudentRepository
    {
        Task Add(Student student);

        Task<Student> GetById(Guid id);

        Task DeleteById(Guid id);

        Task Delete(Student student);

        Task<IList<Student>> GetAll();

        Task Update(Guid Id, Student student);

        Task AddStudentToGroup(Guid studentId, Guid groupId);

        Task<int> NumberOfStudents();
    }
}
