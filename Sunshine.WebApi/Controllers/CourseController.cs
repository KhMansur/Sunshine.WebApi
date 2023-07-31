using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sunshine.Service.DTOs;
using Sunshine.WebApi.Services;

namespace Sunshine.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ICourseService courseService;
        IAuthManager authManager;

        public CourseController(ICourseService courseService, IAuthManager authManager)
        {
            this.courseService = courseService;
            this.authManager = authManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CourseAddDto courseAddDto, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                if (courseAddDto is not null)
                {
                    await courseService.AddCourse(courseAddDto);
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
                return Ok(await courseService.GetAllCourse());
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                await courseService.DeleteCourse(Id);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid Id, string token, CourseAddDto courseUpdateDto)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                await courseService.UpdateCourse(Id, courseUpdateDto);
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
                return Ok(await courseService.GetCourseById(Id));
            }
            return BadRequest();
        }

    }
}
