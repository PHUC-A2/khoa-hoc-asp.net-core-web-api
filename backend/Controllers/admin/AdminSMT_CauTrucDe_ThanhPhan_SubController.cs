using backend.DTOs.request.SMT_CauTrucDe;
using backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.admin
{
    [Route("api/v1/admin/[controller]")]
    [ApiController]
    public class AdminSMT_CauTrucDe_ThanhPhan_SubController : ControllerBase
    {
        private readonly SMT_CauTrucDe_ThanhPhan_SubService _service;

        public AdminSMT_CauTrucDe_ThanhPhan_SubController(SMT_CauTrucDe_ThanhPhan_SubService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _service.GetById(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReqCreateSMT_CauTrucDe_ThanhPhan_SubDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.Create(dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] ReqUpdateSMT_CauTrucDe_ThanhPhan_SubDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.Update(id, dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.Delete(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("by-thanhphan/{id}")]
        public async Task<IActionResult> GetByThanhPhan(long id)
        {
            var result = await _service.GetByThanhPhan(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}