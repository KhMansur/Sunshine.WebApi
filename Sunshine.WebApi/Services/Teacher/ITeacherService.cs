using Sunshine.Data.Models;
using Sunshine.Service.DTOs;

namespace Sunshine.WebApi.Services
{
    public interface ITeacherService
    {
        Task AddTeacher(TeacherAddDto teacherAddDto);

        Task UpdateTeacher(Guid Id, TeacherUpdateDto teacherUpdateDto);

        Task DeleteTeacher(Guid Id);

        Task<Teacher> GetTeacherById(Guid Id);

        Task<IList<Teacher>> GetAllTeacher();

        Task<Teacher> GetByName(string name);

        Task<int> GetNumberOfTeachers();
    }
}
