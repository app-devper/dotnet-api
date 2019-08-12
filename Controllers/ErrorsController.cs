using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("/errors")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("{code}")]
        public IActionResult Error(int code)
        {
            var parsedCode = (HttpStatusCode) code;
            return new ObjectResult(new {message = parsedCode.ToString()});
        }
    }
}