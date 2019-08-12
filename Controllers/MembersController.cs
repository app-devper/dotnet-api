using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Helpers;
using Microsoft.Extensions.Options;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private IMemberService _memberService;
        private readonly AppSettings _appSettings;
        public MembersController(IOptions<AppSettings> appSettings, IMemberService memberService)
        {
            _appSettings = appSettings.Value;
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
