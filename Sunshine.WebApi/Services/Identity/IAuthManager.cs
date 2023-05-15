using Sunshine.Data.Models;
using Sunshine.Service.DTOs;

namespace Sunshine.WebApi.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDto dto);

        Task<string> CreateToken();

        Task<Response> ValidateToken(string token);

        Task<string> AddStudent(RegisterStudentDto dto);

        Task<string> AddTeacher(RegisterTeacherDto dto);
    }
}
