using AutoMapper;
using Sunshine.Data.Models;
using Sunshine.Service.DTOs;
using Sunshine.Service.IRepositories;

namespace Sunshine.WebApi.Services
{
    public class GroupService : IGroupService
    {
        IGroupRepository groupRepository;
        ICourseRepository courseRepository;
        ITeacherRepository teacherRepository;
        IStudentRepository studentRepository;
        IStudentPaymentRepository studentPaymentRepository;
        IMapper mapper;

        public GroupService(IGroupRepository groupRepository, IMapper mapper, ITeacherRepository teacherRepository, IStudentRepository studentRepository, IStudentPaymentRepository studentPaymentRepository, ICourseRepository courseRepository)
        {
            this.groupRepository = groupRepository;
            this.mapper = mapper;
            this.teacherRepository = teacherRepository;
            this.studentRepository = studentRepository;
            this.studentPaymentRepository = studentPaymentRepository;
            this.courseRepository = courseRepository;
        }

        public async Task AddGroup(GroupAddDto groupAddDto)
        {
            var group = mapper.Map<Group>(groupAddDto);
            var course = await courseRepository.GetById(groupAddDto.CourseId);
            group.Course = course;
            group.Teacher = await teacherRepository.GetById(groupAddDto.TeacherId);
            group.CreatedTime = DateTime.Now;
            if (group is not null)
            {
                await groupRepository.Add(group);
            }
        }

        public async Task DeleteGroup(Guid Id)
        {
            await groupRepository.DeleteById(Id);
        }

        public async Task<IList<Group>> GetAllGroup()
        {
            return await groupRepository.GetAll();
        }

        public async Task<Group> GetGroupById(Guid Id)
        {
            return await groupRepository.GetById(Id);
        }

        public async Task UpdateGroup(Guid Id, GroupUpdateDto groupUpdateDto)
        {
            var group = mapper.Map<Group>(groupUpdateDto);
            group.Course = await courseRepository.GetById(groupUpdateDto.CourseId);
            group.Teacher = await teacherRepository.GetById(groupUpdateDto.TeacherId);
            (await studentRepository.GetAll())
                .Where(p => groupUpdateDto.StudentIds.Contains(p.Id))
                .ToList()
                .ForEach(p => group.Students.Add(p));
            (await studentPaymentRepository.GetAll())
                .Where(p => groupUpdateDto.StudentPaymentIds.Contains(p.Id))
                .ToList()
                .ForEach(p => group.StudentPayments.Add(p));
            await groupRepository.Update(Id, group);
        }

        public async Task AddStudentToGroup(Guid studentId, Guid groupId)
        {
            await groupRepository.AddStudentToGroup(studentId, groupId);
        }

        public async Task AddStudentsToGroup(IList<Guid> studentIds, Guid group)
        {
            await groupRepository.AddStudentsToGroup(studentIds, group);
        }

        public async Task DeleteStudentFromGroup(Guid studentId, Guid groupId)
        {
            await groupRepository.DeleteStudentFromGroup(studentId, groupId);
        }

        public async Task<int> GetNumberOfGroups()
        {
            return await groupRepository.NumberOfGroups();
        }
    }
}
