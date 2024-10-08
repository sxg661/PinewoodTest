using Microsoft.AspNetCore.Mvc;

namespace PinewoodBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet(Name = "GetTest")]
        public string GetMessage()
        {
            return "This is a test message";
        }
    }
}
