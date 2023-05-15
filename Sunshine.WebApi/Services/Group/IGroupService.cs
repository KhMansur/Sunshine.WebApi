using Sunshine.Data.Models;
using Sunshine.Service.DTOs;

namespace Sunshine.WebApi.Services
{
    public interface IGroupService
    {
        Task AddGroup(GroupAddDto group);

        Task UpdateGroup(Guid Id, GroupUpdateDto group);

        Task DeleteGroup(Guid Id);

        Task<Group> GetGroupById(Guid Id);

        Task<IList<Group>> GetAllGroup();

        Task AddStudentsToGroup(IList<Guid> studentIds, Guid group);

        Task AddStudentToGroup(Guid studentId, Guid groupId);

        Task DeleteStudentFromGroup(Guid studentId, Guid groupId);

        Task<int> GetNumberOfGroups();
    }
}
