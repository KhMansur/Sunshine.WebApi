using Sunshine.Data.Models;
using Sunshine.Service.DTOs;

namespace Sunshine.WebApi.Services
{
    public interface IStudentService
    {
        Task AddStudent(RegisterStudentDto registerStudentDto);

        Task UpdateStudent(Guid Id, StudentUpdateDto studentUpdateDto);

        Task DeleteStudent(Guid Id);

        Task<StudentInfoDto> GetStudentById(Guid Id);

        Task<IList<StudentListDto>> GetAllStudent();

        Task AddStudentToGroup(Guid studentId, Guid groupId);

        Task<int> GetNumberOfStudents();
    }
}
