using AutoMapper;
using Sunshine.Data.Models;
using Sunshine.Service.DTOs;
using Sunshine.Service.IRepositories;

namespace Sunshine.WebApi.Services
{
    public class StudentService : IStudentService
    {
        IStudentRepository studentRepository;
        IGroupRepository groupRepository;
        IStudentPaymentRepository studentPaymentRepository;
        IMapper mapper;

        public StudentService(IStudentRepository studentRepository, IStudentPaymentRepository studentPaymentRepository, IGroupRepository groupRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.studentPaymentRepository = studentPaymentRepository;
            this.groupRepository = groupRepository;
            this.mapper = mapper;
        }

        public async Task AddStudent(RegisterStudentDto registerStudentAddDto)
        {
            var studentAddDto = mapper.Map<StudentAddDto>(registerStudentAddDto);
            if (studentAddDto is not null)
            {
                var student = mapper.Map<Student>(studentAddDto);
                student.CreatedTime = DateTime.Now;
                await studentRepository.Add(student);
            }
        }

        public async Task DeleteStudent(Guid Id)
        {
            await studentRepository.DeleteById(Id);
        }

        public async Task<IList<StudentListDto>> GetAllStudent()
        {
            return mapper.Map<IList<StudentListDto>>(await studentRepository.GetAll());
        }

        public async Task<StudentInfoDto> GetStudentById(Guid Id)
        {
            var studentInfo = mapper.Map<StudentInfoDto>(await studentRepository.GetById(Id));
            return studentInfo;
        }

        public async Task UpdateStudent(Guid Id, StudentUpdateDto studentUpdateDto)
        {
            var student = mapper.Map<Student>(studentUpdateDto);
            (await studentPaymentRepository.GetAll())
                .Where(p => studentUpdateDto.PaymentIds
                .Contains(p.Id)).ToList()
                .ForEach(x => student.Payments.Add(x));
            (await groupRepository.GetAll())
                .Where(p => studentUpdateDto.GroupIds
                .Contains(p.Id)).ToList()
                .ForEach(x => student.Groups.Add(x));

            await studentRepository.Update(Id, student);
        }

        public async Task AddStudentToGroup(Guid studentId, Guid groupId)
        {
            await studentRepository.AddStudentToGroup(studentId, groupId);
        }

        public async Task<int> GetNumberOfStudents()
        {
            return await studentRepository.NumberOfStudents();
        }
    }
}
