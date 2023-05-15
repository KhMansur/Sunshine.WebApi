using Sunshine.Data.Models;
using Sunshine.Service.DTOs;

namespace Sunshine.WebApi.Services
{
    public interface ISpecialityService
    {
        Task AddSpeciality(SpecialityDto specialityDto);

        Task UpdateSpeciality(Guid Id, SpecialityDto specialityDto);

        Task DeleteSpeciality(Guid Id);

        Task<Speciality> GetSpecialityById(Guid Id);

        Task<IList<Speciality>> GetAllSpeciality();
    }
}
