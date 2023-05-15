using Sunshine.Data.Models;
using Sunshine.Service.DTOs;

namespace Sunshine.WebApi.Services
{
    public interface ICourseService
    {
        Task AddCourse(CourseAddDto course);

        Task UpdateCourse(Guid Id, CourseAddDto course);

        Task DeleteCourse(Guid Id);

        Task<Course> GetCourseById(Guid Id);

        Task<IList<Course>> GetAllCourse();
    }
}
