using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sunshine.Service.DTOs;
using Sunshine.WebApi.Services;

namespace Sunshine.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentPaymentController : ControllerBase
    {
        IStudentPaymentService studentPaymentService;
        IAuthManager authManager;

        public StudentPaymentController(IStudentPaymentService studentPaymentService, IAuthManager authManager)
        {
            this.studentPaymentService = studentPaymentService;
            this.authManager = authManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentPaymentAddDto studentPaymentAddDto, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                if (studentPaymentAddDto is not null)
                {
                    await studentPaymentService.AddStudentPayment(studentPaymentAddDto);
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
                return Ok(await studentPaymentService.GetAllStudentPayment());
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                await studentPaymentService.DeleteStudentPayment(Id);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid Id, StudentPaymentAddDto studentPaymentUpdateDto, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                await studentPaymentService.UpdateStudentPayment(Id, studentPaymentUpdateDto);
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
                return Ok(await studentPaymentService.GetStudentPaymentById(Id));
            }
            return BadRequest();
        }
    }
}
