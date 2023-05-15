using Sunshine.Data.Models;
using Sunshine.Service.DTOs;

namespace Sunshine.WebApi.Services
{
    public interface IStudentPaymentService
    {
        Task AddStudentPayment(StudentPaymentAddDto studentPayment);

        Task UpdateStudentPayment(Guid Id, StudentPaymentAddDto studentPayment);

        Task DeleteStudentPayment(Guid Id);

        Task<StudentPayment> GetStudentPaymentById(Guid Id);

        Task<IList<StudentPayment>> GetAllStudentPayment();

        Task<IList<StudentPayment>> GetLastNStudentPayments(int n);
    }
}
