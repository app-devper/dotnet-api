using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public IActionResult GetMembers([FromQuery] Query queryParam)
        {
            var result = _memberService.GetMembers(queryParam.Page, queryParam.Limit);
            return Ok(result);
        }
        
        [HttpGet("{id:length(24)}")]
        public IActionResult GetMember(string id)
        {
            var result = _memberService.GetMember(id);
            if (result == null)
            {
                return NotFound(new { message = "Member not found" });
            }
            return Ok(result);
        }
    }
}
