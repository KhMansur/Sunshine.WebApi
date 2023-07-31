using AutoMapper;
using Sunshine.Data.Models;
using Sunshine.Service.DTOs.TeacherPayment;
using Sunshine.Service.IRepositories;

namespace Sunshine.WebApi.Services
{
    public class TeacherPaymentService : ITeacherPaymentService
    {
        ITeacherPaymentRepository teacherPaymentRepository;
        IStudentPaymentRepository studentPaymentRepository;
        ITeacherRepository teacherRepository;
        IMapper mapper;

        public TeacherPaymentService(ITeacherPaymentRepository teacherPaymentRepository, IMapper mapper, ITeacherRepository teacherRepository, IStudentPaymentRepository studentPaymentRepository = null)
        {
            this.teacherPaymentRepository = teacherPaymentRepository;
            this.mapper = mapper;
            this.teacherRepository = teacherRepository;
            this.studentPaymentRepository = studentPaymentRepository;
        }

        public async Task AddTeacherPayment(TeacherPaymentAddDto teacherPaymentAddDto)
        {
            var teacherPayment = mapper.Map<TeacherPayment>(teacherPaymentAddDto);
            teacherPayment.Teacher = await teacherRepository.GetById(teacherPaymentAddDto.TeacherId);
            IList<StudentPayment> studentPayments = new List<StudentPayment>();
            int amount = 0;
            foreach(var studentPaymentId in teacherPaymentAddDto.StudentPaymentIds)
            {
                var studentPayment = await studentPaymentRepository.GetById(studentPaymentId);
                amount += studentPayment.Amount;
                studentPayments.Add(studentPayment);
            }
            teacherPayment.StudentPayments = studentPayments;
            teacherPayment.Amount = amount;
            teacherPayment.RecievedTime = DateTime.Now;
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
