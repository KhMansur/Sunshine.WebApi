using AutoMapper;
using Sunshine.Data.Models;
using Sunshine.Service.DTOs;
using Sunshine.Service.DTOs.TeacherPayment;

namespace Sunshine.WebApi.Configurations
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            #region Student DTOs
            CreateMap<StudentAddDto, Student>().ReverseMap();

            CreateMap<StudentUpdateDto, Student>().ReverseMap();

            CreateMap<StudentListDto, Student>().ReverseMap();

            CreateMap<Student, StudentInfoDto>()
                .ForMember(p => p.GroupsShortInfo, c => c.MapFrom(x => x.Groups))
                .ForMember(p => p.PaymentsShortInfo, c => c.MapFrom(x => x.Payments))
                .ReverseMap();

            CreateMap<Group, GroupShortInfoDto>()
                .ForMember(p => p.CourseName, c => c.MapFrom(x => x.Course.Name))
                .ForMember(p => p.TeacherName, c => c.MapFrom(x => x.Teacher.Firstname + x.Teacher.Lastname))
                .ReverseMap();

            CreateMap<StudentPayment, StudentPaymentShortInfoDto>()
                .ForMember(p => p.GroupName, c => c.MapFrom(x => x.Group.Name))
                .ForMember(p => p.GroupId, c => c.MapFrom(x => x.Group.Id));

            CreateMap<RegisterStudentDto, Student>().ReverseMap();

            CreateMap<RegisterStudentDto, StudentAddDto>().ReverseMap();
            #endregion

            #region Teacher DTOs
            CreateMap<TeacherUpdateDto, Teacher>().ReverseMap();

            CreateMap<TeacherAddDto, Teacher>().ReverseMap();
            #endregion

            #region Group DTOs
            CreateMap<GroupAddDto, Group>().ReverseMap();
            #endregion

            #region Speciality DTOs
            CreateMap<SpecialityDto, Speciality>().ReverseMap();
            #endregion

            #region Course DTOs
            CreateMap<CourseAddDto, Course>().ReverseMap();

            CreateMap<Course, CoursePrintDto>()
                .ForMember(p => p.SpecialityName, c => c.MapFrom(x => x.Speciality.Name))
                .ReverseMap();
            #endregion

            #region StudentPayment DTOs
            CreateMap<StudentPaymentAddDto, StudentPayment>().ReverseMap();
            #endregion

            #region Identity
            CreateMap<ApiUser, UserDto>().ReverseMap();
            #endregion

            #region TeacherPayment
            CreateMap<TeacherPaymentAddDto, TeacherPayment>().ReverseMap();
            #endregion
        }
    }
}
