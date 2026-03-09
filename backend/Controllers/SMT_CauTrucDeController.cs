using backend.Data;
using backend.DTOs.common;
using backend.DTOs.request.SMT_CauTrucDe;
using backend.DTOs.response.SMT_CauTrucDe;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SMT_CauTrucDeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SMT_CauTrucDeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/SMT_CauTrucDe?page=1&pageSize=10
        [HttpGet]
        public async Task<ActionResult<RestResponse<ResultPaginationDTO<ResSMT_CauTrucDeDTO>>>> GetSMT_CauTrucDes(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (page < 1) page = 1;
                if (pageSize < 1) pageSize = 10;

                var query = _context.SMT_CauTrucDes
                    .Where(x => !x.is_deleted)
                    .AsNoTracking();

                var total = await query.CountAsync();
                var totalPages = (int)Math.Ceiling((double)total / pageSize);

                var data = await query
                    .OrderBy(x => x.id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(c => new ResSMT_CauTrucDeDTO
                    {
                        id = c.id,
                        id_mon = c.id_mon,
                        name = c.name,
                        id_maudethi = c.id_maudethi,
                        is_dungtailieu = c.is_dungtailieu,
                        note = c.note,
                        id_kieuhienthi = c.id_kieuhienthi,
                        is_trondethi = c.is_trondethi,
                        duration = c.duration,
                        status = c.status,
                        is_deleted = c.is_deleted,
                        created_user_id = c.created_user_id,
                        created_time = c.created_time,
                        last_modified_user_id = c.last_modified_user_id,
                        last_modified_times = c.last_modified_times,
                        order = c.order,
                        so_cau_hoi = c.so_cau_hoi,
                        id_he = c.id_he
                    })
                    .ToListAsync();

                return Ok(new RestResponse<ResultPaginationDTO<ResSMT_CauTrucDeDTO>>
                {
                    StatusCode = 200,
                    Message = "Lấy danh sách cấu trúc đề",
                    Data = new ResultPaginationDTO<ResSMT_CauTrucDeDTO>
                    {
                        Meta = new PaginationMeta
                        {
                            Page = page,
                            PageSize = pageSize,
                            Pages = totalPages,
                            Total = total
                        },
                        Result = data
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RestResponse<object>
                {
                    StatusCode = 500,
                    Message = "Lỗi khi lấy danh sách cấu trúc đề",
                    Error = ex.Message
                });
            }
        }

        // GET api/SMT_CauTrucDe/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSMT_CauTrucDe(long id)
        {
            try
            {
                var cauTrucDe = await _context.SMT_CauTrucDes
                    .Where(c => c.id == id && !c.is_deleted)
                    .AsNoTracking()
                    .Select(c => new ResSMT_CauTrucDeDTO
                    {
                        id = c.id,
                        id_mon = c.id_mon,
                        name = c.name,
                        id_maudethi = c.id_maudethi,
                        is_dungtailieu = c.is_dungtailieu,
                        note = c.note,
                        id_kieuhienthi = c.id_kieuhienthi,
                        is_trondethi = c.is_trondethi,
                        duration = c.duration,
                        status = c.status,
                        is_deleted = c.is_deleted,
                        created_user_id = c.created_user_id,
                        created_time = c.created_time,
                        last_modified_user_id = c.last_modified_user_id,
                        last_modified_times = c.last_modified_times,
                        order = c.order,
                        so_cau_hoi = c.so_cau_hoi,
                        id_he = c.id_he
                    })
                    .FirstOrDefaultAsync();

                if (cauTrucDe == null)
                {
                    return NotFound(new RestResponse<object>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy cấu trúc đề"
                    });
                }

                return Ok(new RestResponse<ResSMT_CauTrucDeDTO>
                {
                    StatusCode = 200,
                    Message = "Lấy thông tin cấu trúc đề",
                    Data = cauTrucDe
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RestResponse<object>
                {
                    StatusCode = 500,
                    Message = "Lỗi khi lấy dữ liệu",
                    Error = ex.Message
                });
            }
        }

    }
}