using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.IRepositories
{
    public interface IGroupRepository
    {
        Task Add(Group group);

        Task<Group> GetById(Guid id);

        Task DeleteById(Guid id);

        Task Delete(Group group);

        Task<IList<Group>> GetAll();

        Task Update(Guid Id, Group group);

        Task AddStudentsToGroup(IList<Guid> studentIds, Guid groupId);

        Task AddStudentToGroup(Guid studentId, Guid groupId);
        
        Task DeleteStudentFromGroup(Guid studentId, Guid groupId);

        Task<int> NumberOfGroups();
    }
}
