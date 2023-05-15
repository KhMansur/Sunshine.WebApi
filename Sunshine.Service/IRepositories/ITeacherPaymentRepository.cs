using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Service.IRepositories
{
    public interface ITeacherPaymentRepository
    {
        Task Add(TeacherPayment teacherPayment);

        Task<TeacherPayment> GetById(Guid id);

        Task DeleteById(Guid id);

        Task Delete(TeacherPayment teacherPayment);

        Task<IList<TeacherPayment>> GetAll();

        Task Update(Guid Id, TeacherPayment teacherPayment);
    }
}
