using backend.DTOs.common;
using backend.DTOs.request.SMT_CauTrucDe;
using backend.DTOs.response.SMT_CauTrucDe;
using backend.Models;
using backend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Service
{
    public class SMT_CauTrucDeService
    {
        private readonly SMT_CauTrucDeRepository _repo;

        public SMT_CauTrucDeService(SMT_CauTrucDeRepository repo)
        {
            _repo = repo;
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

        public async Task<RestResponse<ResultPaginationDTO<ResSMT_CauTrucDeDTO>>> GetAll(int page, int pageSize)
        {
            try
            {
                if (page < 1) page = 1;
                if (pageSize < 1) pageSize = 10;

                var query = _repo.Query()
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

                return new RestResponse<ResultPaginationDTO<ResSMT_CauTrucDeDTO>>
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
                };
            }
            catch (Exception ex)
            {
                return new RestResponse<ResultPaginationDTO<ResSMT_CauTrucDeDTO>>
                {
                    StatusCode = 500,
                    Message = "Lỗi khi lấy dữ liệu",
                    Error = ex.Message
                };
            }
        }

        public async Task<RestResponse<object>> GetDeleted()
        {
            try
            {
                var entities = await _repo.Query()
                    .Where(x => x.is_deleted)
                    .AsNoTracking()
                    .ToListAsync();

                var result = entities.Select(MapToDTO);

                return new RestResponse<object>
                {
                    StatusCode = 200,
                    Message = "Danh sách cấu trúc đề đã xóa",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new RestResponse<object>
                {
                    StatusCode = 500,
                    Message = "Lỗi khi lấy danh sách đã xóa",
                    Error = ex.Message
                };
            }
        }

        public async Task<RestResponse<object>> GetById(long id)
        {
            try
            {
                var entity = await _repo.GetById(id);

                if (entity == null)
                {
                    return new RestResponse<object>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy cấu trúc đề"
                    };
                }

                return new RestResponse<object>
                {
                    StatusCode = 200,
                    Message = "Thông tin cấu trúc đề",
                    Data = MapToDTO(entity)
                };
            }
            catch (Exception ex)
            {
                return new RestResponse<object>
                {
                    StatusCode = 500,
                    Message = "Lỗi khi lấy dữ liệu",
                    Error = ex.Message
                };
            }
        }

        public async Task<RestResponse<object>> Create(ReqCreateSMT_CauTrucDeDTO dto)
        {
            try
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

                await _repo.Add(entity);

                return new RestResponse<object>
                {
                    StatusCode = 201,
                    Message = "Tạo cấu trúc đề thành công",
                    Data = MapToDTO(entity)
                };
            }
            catch (Exception ex)
            {
                return new RestResponse<object>
                {
                    StatusCode = 500,
                    Message = "Lỗi khi tạo dữ liệu",
                    Error = ex.Message
                };
            }
        }

        public async Task<RestResponse<object>> Update(long id, ReqUpdateSMT_CauTrucDeDTO dto)
        {
            try
            {
                var entity = await _repo.GetById(id);

                if (entity == null)
                {
                    return new RestResponse<object>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy cấu trúc đề"
                    };
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

                await _repo.Update();

                return new RestResponse<object>
                {
                    StatusCode = 200,
                    Message = "Cập nhật thành công",
                    Data = MapToDTO(entity)
                };
            }
            catch (Exception ex)
            {
                return new RestResponse<object>
                {
                    StatusCode = 500,
                    Message = "Lỗi khi cập nhật",
                    Error = ex.Message
                };
            }
        }

        public async Task<RestResponse<object>> SoftDelete(long id)
        {
            try
            {
                var entity = await _repo.GetById(id);

                if (entity == null)
                {
                    return new RestResponse<object>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy cấu trúc đề"
                    };
                }

                entity.is_deleted = true;
                entity.last_modified_times = DateTime.UtcNow;

                await _repo.Update();

                return new RestResponse<object>
                {
                    StatusCode = 200,
                    Message = "Đã xóa cấu trúc đề"
                };
            }
            catch (Exception ex)
            {
                return new RestResponse<object>
                {
                    StatusCode = 500,
                    Message = "Lỗi khi xóa",
                    Error = ex.Message
                };
            }
        }

        public async Task<RestResponse<object>> Restore(long id)
        {
            try
            {
                var entity = await _repo.GetById(id);

                if (entity == null)
                {
                    return new RestResponse<object>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy cấu trúc đề"
                    };
                }

                entity.is_deleted = false;

                await _repo.Update();

                return new RestResponse<object>
                {
                    StatusCode = 200,
                    Message = "Khôi phục thành công"
                };
            }
            catch (Exception ex)
            {
                return new RestResponse<object>
                {
                    StatusCode = 500,
                    Message = "Lỗi khi khôi phục",
                    Error = ex.Message
                };
            }
        }

        public async Task<RestResponse<object>> HardDelete(long id)
        {
            try
            {
                var entity = await _repo.GetById(id);

                if (entity == null)
                {
                    return new RestResponse<object>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy cấu trúc đề"
                    };
                }

                await _repo.Delete(entity);

                return new RestResponse<object>
                {
                    StatusCode = 200,
                    Message = "Xóa vĩnh viễn thành công"
                };
            }
            catch (Exception ex)
            {
                return new RestResponse<object>
                {
                    StatusCode = 500,
                    Message = "Lỗi khi xóa vĩnh viễn",
                    Error = ex.Message
                };
            }
        }
    }
}