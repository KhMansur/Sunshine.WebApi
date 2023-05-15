using AutoMapper;
using Sunshine.Data.Models;
using Sunshine.Service.DTOs;
using Sunshine.Service.IRepositories;

namespace Sunshine.WebApi.Services
{
    public class CourseService : ICourseService
    {
        ICourseRepository courseRepository;
        ISpecialityRepository specialityRepository;
        IMapper mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper, ISpecialityRepository specialityRepository)
        {
            this.courseRepository = courseRepository;
            this.mapper = mapper;
            this.specialityRepository = specialityRepository;
        }

        public async Task AddCourse(CourseAddDto courseAddDto)
        {
            var course = mapper.Map<Course>(courseAddDto);
            course.Speciality = await specialityRepository.GetById(courseAddDto.SpecialityId);
            if (course is not null)
            {
                await courseRepository.Add(course);
            }
        }

        public async Task DeleteCourse(Guid Id)
        {
            await courseRepository.DeleteById(Id);
        }

        public async Task<IList<Course>> GetAllCourse()
        {
            return await courseRepository.GetAll();
        }

        public async Task<Course> GetCourseById(Guid Id)
        {
            return await courseRepository.GetById(Id);
        }

        public async Task UpdateCourse(Guid Id, CourseAddDto courseAddDto)
        {
            var course = mapper.Map<Course>(courseAddDto);
            course.Speciality = await specialityRepository.GetById(courseAddDto.SpecialityId);
            await courseRepository.Update(Id, course);
        }
    }
}
