using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Sunshine.Data.Models;
using Sunshine.Service.DTOs;
using Sunshine.WebApi.Services;

namespace Sunshine.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentService studentService;
        IAuthManager authManager;

        public StudentController(IStudentService studentService, IAuthManager authManager)
        {
            this.studentService = studentService;
            this.authManager = authManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegisterStudentDto registerStudentDto, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                
                if (registerStudentDto is not null)
                {
                    await authManager.AddStudent(registerStudentDto);
                    await studentService.AddStudent(registerStudentDto);
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
                return Ok(await studentService.GetAllStudent());
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                await studentService.DeleteStudent(Id);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid Id, StudentUpdateDto studentUpdateDto, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                await studentService.UpdateStudent(Id, studentUpdateDto);
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
                return Ok(await studentService.GetStudentById(Id));
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddGroupToStudent(Guid studentId, Guid groupId, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                await studentService.AddStudentToGroup(studentId, groupId);
                return Ok();
            }
            return BadRequest();
        }
    }
}
