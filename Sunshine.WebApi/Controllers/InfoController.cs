using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sunshine.Data.Models;
using Sunshine.WebApi.Services;

namespace Sunshine.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        IGroupService groupService;
        ITeacherService teacherService;
        IStudentService studentService;
        IAuthManager authManager;
        IStudentPaymentService studentPaymentService;

        public InfoController(IGroupService groupService,
            ITeacherService teacherService,
            IStudentService studentService,
            IAuthManager authManager,
            IStudentPaymentService studentPaymentService)
        {
            this.groupService = groupService;
            this.teacherService = teacherService;
            this.studentService = studentService;
            this.authManager = authManager;
            this.studentPaymentService = studentPaymentService;
        }

        [HttpGet]
        public async Task<IActionResult> AdminDashboardInfo(string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                int numberOfGroups = await groupService.GetNumberOfGroups();
                int numberOfStudents = await studentService.GetNumberOfStudents();
                int numberOfTeachers = await teacherService.GetNumberOfTeachers();
                //IList<StudentPayment> lastNPayments = await studentPaymentService.GetLastNStudentPayments(6);
                DateTime now = DateTime.Now;
                int month = now.Day <= 5 ? 0 : 1; 
                DateTime deadline = new DateTime(now.Year, now.Month + month, 6);
                int deadlineDays = (deadline - now).Days;

                return Ok(new
                {
                    NumberOfGroups = numberOfGroups,
                    NumberOfStudents = numberOfStudents,
                    NumberOfTeachers = numberOfTeachers,
                    DeadlineDays = deadlineDays
                });
            }
            return BadRequest();
        }
    }
}
