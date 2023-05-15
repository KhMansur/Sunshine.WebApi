using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Sunshine.Service.DTOs;
using Sunshine.WebApi.Services;

namespace Sunshine.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        IGroupService groupService;
        IAuthManager authManager;

        public GroupController(IGroupService groupService, IAuthManager authManager)
        {
            this.groupService = groupService;
            this.authManager = authManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(GroupAddDto groupAddDto, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                if (groupAddDto is not null)
                {
                    await groupService.AddGroup(groupAddDto);
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
                return Ok(await groupService.GetAllGroup());
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                await groupService.DeleteGroup(Id);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid Id, GroupUpdateDto groupUpdateDto, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                await groupService.UpdateGroup(Id, groupUpdateDto);
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
                return Ok(await groupService.GetGroupById(Id));
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentToGroup(Guid studentId, Guid groupId, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                await groupService.AddStudentToGroup(studentId, groupId);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentsToGroup(IList<Guid> studentIds, Guid groupId, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                await groupService.AddStudentsToGroup(studentIds, groupId);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudentFromGroup(Guid studentId, Guid groupId, string token)
        {
            var validation = this.authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("Manager")))
            {
                await groupService.DeleteStudentFromGroup(studentId, groupId);
                return Ok();
            }
            return BadRequest();
        }
    }
}
