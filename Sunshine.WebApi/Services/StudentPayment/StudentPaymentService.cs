using AutoMapper;
using Sunshine.Data.Models;
using Sunshine.Service.DTOs;
using Sunshine.Service.IRepositories;

namespace Sunshine.WebApi.Services
{
    public class StudentPaymentService : IStudentPaymentService
    {
        IStudentPaymentRepository studentPaymentRepository;
        IStudentRepository studentRepository;
        IGroupRepository groupRepository;
        IMapper mapper;

        public StudentPaymentService(IStudentPaymentRepository studentPaymentRepository)
        {
            this.studentPaymentRepository = studentPaymentRepository;
        }

        public async Task AddStudentPayment(StudentPaymentAddDto studentPaymentAddDto)
        {
            var studentPayment = mapper.Map<StudentPayment>(studentPaymentAddDto);
            studentPayment.isCalculated = false;
            studentPayment.RecievedTime = DateTime.Now;
            if (studentPayment is not null)
            {
                await studentPaymentRepository.Add(studentPayment);
            }
        }

        public async Task DeleteStudentPayment(Guid Id)
        {
            await studentPaymentRepository.DeleteById(Id);
        }

        public async Task<IList<StudentPayment>> GetAllStudentPayment()
        {
            return await studentPaymentRepository.GetAll();
        }

        public async Task<IList<StudentPayment>> GetLastNStudentPayments(int n)
        {
            return await studentPaymentRepository.LastNStudentPayments(n);
        }

        public async Task<StudentPayment> GetStudentPaymentById(Guid Id)
        {
            return await studentPaymentRepository.GetById(Id);
        }

        public async Task UpdateStudentPayment(Guid Id, StudentPaymentAddDto studentPaymentDto)
        {
            var studentPayment = mapper.Map<StudentPayment>(studentPaymentDto);
            await studentPaymentRepository.Update(Id, studentPayment);
        }
    }
}
