using Sunshine.Data.Models;

namespace Sunshine.WebApi.Services
{
    public interface ITeacherPaymentService
    {
        Task AddTeacherPayment(TeacherPayment TeacherPayment);

        Task UpdateTeacherPayment(Guid Id, TeacherPayment TeacherPayment);

        Task DeleteTeacherPayment(Guid Id);

        Task<TeacherPayment> GetTeacherPaymentById(Guid Id);

        Task<IList<TeacherPayment>> GetAllTeacherPayment();
    }
}
