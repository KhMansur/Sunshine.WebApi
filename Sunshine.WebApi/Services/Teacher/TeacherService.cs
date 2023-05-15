using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Sunshine.Data.Models;
using Sunshine.Service.DTOs;
using Sunshine.Service.IRepositories;
using Sunshine.Service.Repositories;

namespace Sunshine.WebApi.Services
{
    public class TeacherService : ITeacherService
    {
        ITeacherRepository teacherRepository;
        IMapper mapper;
        ITeacherPaymentRepository teacherPaymentRepository;
        IGroupRepository groupRepository;
        ISpecialityRepository specialityRepository;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            this.teacherRepository = teacherRepository;
            this.mapper = mapper;
        }

        public async Task AddTeacher(TeacherAddDto teacherAddDto)
        {
            var teacher = mapper.Map<Teacher>(teacherAddDto);
            if (teacher is not null)
            {
                await teacherRepository.Add(teacher);
            }
        }

        public async Task DeleteTeacher(Guid Id)
        {
            await teacherRepository.DeleteById(Id);
        }

        public async Task<IList<Teacher>> GetAllTeacher()
        {
            return await teacherRepository.GetAll();
        }

        public async Task<Teacher> GetTeacherById(Guid Id)
        {
            return await teacherRepository.GetById(Id);
        }

        public async Task UpdateTeacher(Guid Id, TeacherUpdateDto teacherUpdateDto)
        {
            var teacher = mapper.Map<Teacher>(teacherUpdateDto);
            (await specialityRepository.GetAll())
                .Where(p => teacherUpdateDto.SpecialityIds.Contains(p.Id))
                .ToList()
                .ForEach(p => teacher.Speciality.Add(p));
            (await groupRepository.GetAll())
                .Where(p => teacherUpdateDto.GroupIds.Contains(p.Id))
                .ToList()
                .ForEach(p => teacher.Groups.Add(p));
            (await teacherPaymentRepository.GetAll())
                .Where(p => teacherUpdateDto.TeacherPaymentIds.Contains(p.Id))
                .ToList()
                .ForEach(p => teacher.TeacherPayments.Add(p));

           await  teacherRepository.Update(Id, teacher);
        }

        public async Task<Teacher> GetByName(string name)
        {
            return await teacherRepository.GetByName(name);
        }

        public async Task<int> GetNumberOfTeachers()
        {
            return await teacherRepository.NumberOfTeachers();
        }
    }
}
