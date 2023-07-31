using Sunshine.Data.Models;
using Sunshine.Service.DTOs.TeacherPayment;

namespace Sunshine.WebApi.Services
{
    public interface ITeacherPaymentService
    {
        Task AddTeacherPayment(TeacherPaymentAddDto teacherPaymentAddDto);

        Task UpdateTeacherPayment(Guid Id, TeacherPayment TeacherPayment);

        Task DeleteTeacherPayment(Guid Id);

        Task<TeacherPayment> GetTeacherPaymentById(Guid Id);

        Task<IList<TeacherPayment>> GetAllTeacherPayment();
    }
}
