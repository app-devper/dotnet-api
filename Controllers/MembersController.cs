using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;

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
        public IActionResult GetMembers([FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "limit")] int limit = 20)
        {
            var result = _memberService.GetMembers(page, limit);
            return Ok(result);
        }
    }
}
