using backend.DTOs.request.SMT_CauTrucDe;
using backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/v1/admin/[controller]")]
    public class AdminSMT_CauTrucDeController : ControllerBase
    {
        private readonly SMT_CauTrucDeService _service;

        public AdminSMT_CauTrucDeController(SMT_CauTrucDeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            return Ok(await _service.GetAll(page, pageSize));
        }

        [HttpGet("deleted")]
        public async Task<IActionResult> GetDeleted()
        {
            return Ok(await _service.GetDeleted());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReqCreateSMT_CauTrucDeDTO dto)
        {
            return Ok(await _service.Create(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, ReqUpdateSMT_CauTrucDeDTO dto)
        {
            return Ok(await _service.Update(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(long id)
        {
            return Ok(await _service.SoftDelete(id));
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> Restore(long id)
        {
            return Ok(await _service.Restore(id));
        }

        [HttpDelete("hard-delete/{id}")]
        public async Task<IActionResult> HardDelete(long id)
        {
            return Ok(await _service.HardDelete(id));
        }
    }
}