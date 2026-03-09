using backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.client
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SMT_CauTrucDeController : ControllerBase
    {
        private readonly SMT_CauTrucDeService _service;

        public SMT_CauTrucDeController(SMT_CauTrucDeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetSMT_CauTrucDes(int page = 1, int pageSize = 10)
        {
            return Ok(await _service.GetAll(page, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSMT_CauTrucDe(long id)
        {
            return Ok(await _service.GetById(id));
        }
    }
}