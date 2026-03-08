using CleanArch.Application.Features.Members;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            var result = await _memberService.GetMemberByIdAsync(id);

            // If the Result failed, we return 404. If it succeeded, we return 200.
            return result.IsSuccess
                ? Ok(result.Value)
                : NotFound(result.Error);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var result = await _memberService.GetAllMembersAsync();
            return Ok(result.Value);
        }
        /// <summary>
        /// Creates a new gym member.
        /// </summary>
        /// <param name="request">The member details.</param>
        /// <returns>The ID of the newly created member.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateMember([FromBody] CreateMemberRequest request)
        {
            var result = await _memberService.CreateMemberAsync(
                request.FirstName,
                request.LastName,
                request.Email);

            return result.IsSuccess
                ? CreatedAtAction(nameof(GetMember), new { id = result.Value }, result.Value)
                : BadRequest(result.Error);
        }

        // A small record just for the Request body
        public record CreateMemberRequest(string FirstName, string LastName, string Email);
    }
}
