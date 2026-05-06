using LmsProjectApi.DTOs.Groups;
using LmsProjectApi.Models.Api;
using LmsProjectApi.Services.Groups;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        public async Task<ActionResult<GroupResponseDto>> CreateAsync(
            [FromBody] GroupCreateDto dto)
        {
            GroupResponseDto created =
                await _groupService.AddAsync(dto);

            return Ok(ApiResponse<GroupResponseDto>.Ok(created, "Successfully created."));
        }

        [HttpGet]
        public ActionResult<ICollection<GroupSimpleDto>> GetAll()
        {
            ICollection<GroupSimpleDto> gruops =
                _groupService.GetAll();

            return Ok(ApiResponse<ICollection<GroupSimpleDto>>.Ok(gruops));
        }

        [HttpGet("{groupId}")]
        public async Task<ActionResult<GroupResponseDto>> GetByIdAsync(Guid groupId)
        {
            GroupResponseDto group =
                await _groupService.GetByIdAsync(groupId);

            return Ok(group);
        }

        [HttpPut("{groupId}")]
        public async Task<ActionResult<GroupResponseDto>> UpdateAsync(
            Guid groupId,
            GroupUpdateDto dto)
        {
            GroupResponseDto updated =
                await _groupService.UpdateAsync(groupId, dto);

            return Ok(ApiResponse<GroupResponseDto>.Ok(updated, "Successfully updated."));

        }

        [HttpDelete("{groupId}")]
        public async Task<IActionResult> DeleteAsync(Guid groupId)
        {
            await _groupService.DeleteAsync(groupId);

            return Ok(ApiResponse<object>.Ok(null!, "Successfully deleted."));

        }
    }
}
