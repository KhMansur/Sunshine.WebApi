using Sunshine.Data.Models;
using Sunshine.Service.IRepositories;

namespace Sunshine.WebApi.Services
{
    public class TeacherPaymentService : ITeacherPaymentService
    {
        ITeacherPaymentRepository teacherPaymentRepository;

        public TeacherPaymentService(ITeacherPaymentRepository teacherPaymentRepository)
        {
            this.teacherPaymentRepository = teacherPaymentRepository;
        }

        public async Task AddTeacherPayment(TeacherPayment teacherPayment)
        {
            if (teacherPayment is not null)
            {
                await teacherPaymentRepository.Add(teacherPayment);
            }
        }

        public async Task DeleteTeacherPayment(Guid Id)
        {
            await teacherPaymentRepository.DeleteById(Id);
        }

        public async Task<IList<TeacherPayment>> GetAllTeacherPayment()
        {
            return await teacherPaymentRepository.GetAll();
        }

        public async Task<TeacherPayment> GetTeacherPaymentById(Guid Id)
        {
            return await teacherPaymentRepository.GetById(Id);
        }

        public async Task UpdateTeacherPayment(Guid Id, TeacherPayment TeacherPayment)
        {
            await teacherPaymentRepository.Update(Id, TeacherPayment);
        }
    }
}
