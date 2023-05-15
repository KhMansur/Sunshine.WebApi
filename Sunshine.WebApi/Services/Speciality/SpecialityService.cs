using AutoMapper;
using Sunshine.Data.Models;
using Sunshine.Service.DTOs;
using Sunshine.Service.IRepositories;

namespace Sunshine.WebApi.Services
{
    public class SpecialityService : ISpecialityService
    {
        ISpecialityRepository specialityRepository;
        IMapper mapper;

        public SpecialityService(ISpecialityRepository specialityRepository, IMapper mapper)
        {
            this.specialityRepository = specialityRepository;
            this.mapper = mapper;
        }

        public async Task AddSpeciality(SpecialityDto specialityDto)
        {
            var speciality = mapper.Map<Speciality>(specialityDto);
            if (speciality is not null)
            {
                await specialityRepository.Add(speciality);
            }
        }

        public async Task DeleteSpeciality(Guid Id)
        {
            await specialityRepository.DeleteById(Id);
        }

        public async Task<IList<Speciality>> GetAllSpeciality()
        {
            return await specialityRepository.GetAll();
        }

        public async Task<Speciality> GetSpecialityById(Guid Id)
        {
            return await specialityRepository.GetById(Id);
        }

        public async Task UpdateSpeciality(Guid Id, SpecialityDto specialityDto)
        {
            var speciality = mapper.Map<Speciality>(specialityDto);
            await specialityRepository.Update(Id, speciality);
        }
    }
}
