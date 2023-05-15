using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sunshine.Service.DTOs;
using Sunshine.WebApi.Services;

namespace Sunshine.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        ISpecialityService specialityService;
        IAuthManager authManager;

        public SpecialityController(ISpecialityService specialityService, IAuthManager authManager)
        {
            this.specialityService = specialityService;
            this.authManager = authManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(SpecialityDto specialityAddDto, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                if (specialityAddDto is not null)
                {
                    await specialityService.AddSpeciality(specialityAddDto);
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                return Ok(await specialityService.GetAllSpeciality());
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                await specialityService.DeleteSpeciality(Id);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid Id, SpecialityDto specialityUpdateDto, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                await specialityService.UpdateSpeciality(Id, specialityUpdateDto);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid Id, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                return Ok(await specialityService.GetSpecialityById(Id));
            }
            return BadRequest();
        }
    }
}
