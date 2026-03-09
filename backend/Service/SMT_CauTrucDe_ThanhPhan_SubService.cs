using backend.DTOs.common;
using backend.DTOs.request.SMT_CauTrucDe;
using backend.DTOs.response.SMT_CauTrucDe;
using backend.Models;
using backend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Service
{
    public class SMT_CauTrucDe_ThanhPhan_SubService
    {
        private readonly SMT_CauTrucDe_ThanhPhan_SubRepository _repo;

        public SMT_CauTrucDe_ThanhPhan_SubService(SMT_CauTrucDe_ThanhPhan_SubRepository repo)
        {
            _repo = repo;
        }

        private static ResSMT_CauTrucDe_ThanhPhan_Sub MapToDTO(SMT_CauTrucDe_ThanhPhan_Sub c)
        {
            return new ResSMT_CauTrucDe_ThanhPhan_Sub
            {
                id = c.id,
                id_cautrucde_thanhphan = c.id_cautrucde_thanhphan,
                id_nhomcauhoi = c.id_nhomcauhoi,
                id_chude = c.id_chude,
                id_mucdo = c.id_mucdo,
                so_cau = c.so_cau,
                order = c.order,
                created_user_id = c.created_user_id,
                created_time = c.created_time,
                last_modified_user_id = c.last_modified_user_id,
                last_modified_times = c.last_modified_times,
                ten_chude = c.ten_chude,
                ten_muc_tri_nang = c.ten_muc_tri_nang,
                total_question = c.total_question
            };
        }

        public async Task<RestResponse<object>> GetAll()
        {
            try
            {
                var entities = await _repo.Query()
                    .AsNoTracking()
                    .ToListAsync();

                var result = entities.Select(MapToDTO);

                return new RestResponse<object>
                {
                    StatusCode = 200,
                    Message = "Danh sách thành phần sub",
                    Data = result
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
                        Message = "Không tìm thấy thành phần sub"
                    };
                }

                return new RestResponse<object>
                {
                    StatusCode = 200,
                    Message = "Thông tin thành phần sub",
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

        public async Task<RestResponse<object>> Create(ReqCreateSMT_CauTrucDe_ThanhPhan_SubDTO dto)
        {
            try
            {
                var entity = new SMT_CauTrucDe_ThanhPhan_Sub
                {
                    id_cautrucde_thanhphan = dto.id_cautrucde_thanhphan,
                    id_nhomcauhoi = dto.id_nhomcauhoi,
                    id_chude = dto.id_chude,
                    id_mucdo = dto.id_mucdo,
                    so_cau = dto.so_cau,
                    order = dto.order,
                    ten_chude = dto.ten_chude,
                    ten_muc_tri_nang = dto.ten_muc_tri_nang,
                    total_question = dto.total_question,
                    created_user_id = 1,
                    created_time = DateTime.UtcNow
                };

                await _repo.Add(entity);

                return new RestResponse<object>
                {
                    StatusCode = 201,
                    Message = "Tạo thành phần sub thành công",
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

        public async Task<RestResponse<object>> Update(long id, ReqUpdateSMT_CauTrucDe_ThanhPhan_SubDTO dto)
        {
            try
            {
                var entity = await _repo.GetById(id);

                if (entity == null)
                {
                    return new RestResponse<object>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy thành phần sub"
                    };
                }

                entity.id_cautrucde_thanhphan = dto.id_cautrucde_thanhphan;
                entity.id_nhomcauhoi = dto.id_nhomcauhoi;
                entity.id_chude = dto.id_chude;
                entity.id_mucdo = dto.id_mucdo;
                entity.so_cau = dto.so_cau;
                entity.order = dto.order;
                entity.ten_chude = dto.ten_chude;
                entity.ten_muc_tri_nang = dto.ten_muc_tri_nang;
                entity.total_question = dto.total_question;

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

        public async Task<RestResponse<object>> Delete(long id)
        {
            try
            {
                var entity = await _repo.GetById(id);

                if (entity == null)
                {
                    return new RestResponse<object>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy thành phần sub"
                    };
                }

                await _repo.Delete(entity);

                return new RestResponse<object>
                {
                    StatusCode = 200,
                    Message = "Xóa thành công"
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

        public async Task<RestResponse<object>> GetByThanhPhan(long id)
        {
            try
            {
                var entities = await _repo.Query()
                    .Where(x => x.id_cautrucde_thanhphan == id)
                    .AsNoTracking()
                    .OrderBy(x => x.order)
                    .ToListAsync();

                var result = entities.Select(MapToDTO);

                return new RestResponse<object>
                {
                    StatusCode = 200,
                    Message = "Danh sách sub theo thành phần",
                    Data = result
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
    }
}