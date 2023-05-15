using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.IRepositories
{
    public interface IStudentPaymentRepository
    {
        Task Add(StudentPayment studentPayment);

        Task<StudentPayment> GetById(Guid id);

        Task DeleteById(Guid id);

        Task Delete(StudentPayment studentPayment);

        Task<IList<StudentPayment>> GetAll();

        Task Update(Guid Id, StudentPayment studentPayment);

        Task<IList<StudentPayment>> LastNStudentPayments(int n);
    }
}
