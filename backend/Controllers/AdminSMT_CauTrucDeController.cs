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
    [Route("api/v1/admin/[controller]")]
    public class AdminSMT_CauTrucDeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminSMT_CauTrucDeController(ApplicationDbContext context)
        {
            _context = context;
        }

        private static ResSMT_CauTrucDeDTO MapToDTO(SMT_CauTrucDe c)
        {
            return new ResSMT_CauTrucDeDTO
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
            };
        }

        [HttpGet]
        public async Task<ActionResult<RestResponse<ResultPaginationDTO<ResSMT_CauTrucDeDTO>>>> GetAll(
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

                var entities = await query
                    .OrderBy(x => x.id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var result = entities.Select(MapToDTO).ToList();

                return Ok(new RestResponse<ResultPaginationDTO<ResSMT_CauTrucDeDTO>>
                {
                    StatusCode = 200,
                    Message = "Danh sách cấu trúc đề",
                    Data = new ResultPaginationDTO<ResSMT_CauTrucDeDTO>
                    {
                        Meta = new PaginationMeta
                        {
                            Page = page,
                            PageSize = pageSize,
                            Pages = totalPages,
                            Total = total
                        },
                        Result = result
                    }
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

        [HttpGet("deleted")]
        public async Task<IActionResult> GetDeleted()
        {
            var entities = await _context.SMT_CauTrucDes
                .Where(x => x.is_deleted)
                .AsNoTracking()
                .ToListAsync();

            var result = entities.Select(MapToDTO);

            return Ok(new RestResponse<object>
            {
                StatusCode = 200,
                Message = "Danh sách cấu trúc đề đã xóa",
                Data = result
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var entity = await _context.SMT_CauTrucDes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);

            if (entity == null)
            {
                return NotFound(new RestResponse<object>
                {
                    StatusCode = 404,
                    Message = "Không tìm thấy cấu trúc đề"
                });
            }

            return Ok(new RestResponse<object>
            {
                StatusCode = 200,
                Message = "Thông tin cấu trúc đề",
                Data = MapToDTO(entity)
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReqCreateSMT_CauTrucDeDTO dto)
        {
            var entity = new SMT_CauTrucDe
            {
                id_mon = dto.id_mon,
                name = dto.name,
                id_maudethi = dto.id_maudethi,
                is_dungtailieu = dto.is_dungtailieu,
                note = dto.note,
                id_kieuhienthi = dto.id_kieuhienthi,
                is_trondethi = dto.is_trondethi,
                duration = dto.duration,
                status = dto.status,
                order = dto.order,
                so_cau_hoi = dto.so_cau_hoi,
                id_he = dto.id_he,
                created_user_id = 1,
                created_time = DateTime.UtcNow,
                is_deleted = false
            };

            _context.SMT_CauTrucDes.Add(entity);
            await _context.SaveChangesAsync();

            return StatusCode(201, new RestResponse<object>
            {
                StatusCode = 201,
                Message = "Tạo cấu trúc đề thành công",
                Data = MapToDTO(entity)
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] ReqUpdateSMT_CauTrucDeDTO dto)
        {
            var entity = await _context.SMT_CauTrucDes.FindAsync(id);

            if (entity == null)
            {
                return NotFound(new RestResponse<object>
                {
                    StatusCode = 404,
                    Message = "Không tìm thấy cấu trúc đề"
                });
            }

            entity.id_mon = dto.id_mon;
            entity.name = dto.name;
            entity.id_maudethi = dto.id_maudethi;
            entity.is_dungtailieu = dto.is_dungtailieu;
            entity.note = dto.note;
            entity.id_kieuhienthi = dto.id_kieuhienthi;
            entity.is_trondethi = dto.is_trondethi;
            entity.duration = dto.duration;
            entity.status = dto.status;
            entity.order = dto.order;
            entity.so_cau_hoi = dto.so_cau_hoi;
            entity.id_he = dto.id_he;

            entity.last_modified_user_id = 1;
            entity.last_modified_times = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(new RestResponse<object>
            {
                StatusCode = 200,
                Message = "Cập nhật thành công",
                Data = MapToDTO(entity)
            });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(long id)
        {
            var entity = await _context.SMT_CauTrucDes.FindAsync(id);

            if (entity == null)
            {
                return NotFound(new RestResponse<object>
                {
                    StatusCode = 404,
                    Message = "Không tìm thấy cấu trúc đề"
                });
            }

            entity.is_deleted = true;
            entity.last_modified_user_id = 1;
            entity.last_modified_times = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(new RestResponse<object>
            {
                StatusCode = 200,
                Message = "Đã xóa cấu trúc đề"
            });
        }


        [HttpPut("restore/{id}")]
        public async Task<IActionResult> Restore(long id)
        {
            var entity = await _context.SMT_CauTrucDes.FindAsync(id);

            if (entity == null)
                return NotFound();

            entity.is_deleted = false;
            entity.last_modified_times = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(new RestResponse<object>
            {
                StatusCode = 200,
                Message = "Khôi phục thành công"
            });
        }

        [HttpDelete("hard-delete/{id}")]
        public async Task<IActionResult> HardDelete(long id)
        {
            var entity = await _context.SMT_CauTrucDes.FindAsync(id);

            if (entity == null)
                return NotFound();

            _context.SMT_CauTrucDes.Remove(entity);
            await _context.SaveChangesAsync();

            return Ok(new RestResponse<object>
            {
                StatusCode = 200,
                Message = "Xóa vĩnh viễn thành công"
            });
        }
    }
}