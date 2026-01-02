using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult SayHello()
        {
            var res = new
            {
                Id = 01,
                HoVaTen = "Nguyễn Văn A",
                Email = "nva@gmail.com"
                
            };
            Console.WriteLine("Hello");
            return Ok(res);
        }

    }
}
