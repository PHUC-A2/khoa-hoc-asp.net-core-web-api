using backend.DTOs.common;
using backend.DTOs.request.SMT_CauTrucDe;
using backend.DTOs.response.SMT_CauTrucDe;
using backend.Models;
using backend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Service
{
    public class SMT_CauTrucDe_ThanhPhanService
    {
        private readonly SMT_CauTrucDe_ThanhPhanRepository _repo;

        public SMT_CauTrucDe_ThanhPhanService(SMT_CauTrucDe_ThanhPhanRepository repo)
        {
            _repo = repo;
        }

        private static ResSMT_CauTrucDe_ThanhPhan MapToDTO(SMT_CauTrucDe_ThanhPhan c)
        {
            return new ResSMT_CauTrucDe_ThanhPhan
            {
                id = c.id,
                id_cautrucde = c.id_cautrucde,
                note = c.note,
                type_answer = c.type_answer,
                order = c.order,
                coefficient = c.coefficient,
                is_fixed = c.is_fixed,
                created_user_id = c.created_user_id,
                created_time = c.created_time,
                last_modified_user_id = c.last_modified_user_id,
                last_modified_times = c.last_modified_times,
                so_cau_hoi = c.so_cau_hoi,
                total_question = c.total_question,
                total_score = c.total_score
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
                    Message = "Danh sách thành phần cấu trúc đề",
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
                        Message = "Không tìm thấy thành phần cấu trúc đề"
                    };
                }

                return new RestResponse<object>
                {
                    StatusCode = 200,
                    Message = "Thông tin thành phần cấu trúc đề",
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

        public async Task<RestResponse<object>> Create(ReqCreateSMT_CauTrucDe_Thanh_PhanDTO dto)
        {
            try
            {
                var entity = new SMT_CauTrucDe_ThanhPhan
                {
                    id_cautrucde = dto.id_cautrucde,
                    note = dto.note,
                    type_answer = dto.type_answer,
                    order = dto.order,
                    coefficient = dto.coefficient,
                    is_fixed = dto.is_fixed,
                    so_cau_hoi = dto.so_cau_hoi,
                    total_question = dto.total_question,
                    total_score = dto.total_score,
                    created_user_id = 1,
                    created_time = DateTime.UtcNow
                };

                await _repo.Add(entity);

                return new RestResponse<object>
                {
                    StatusCode = 201,
                    Message = "Tạo thành phần cấu trúc đề thành công",
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

        public async Task<RestResponse<object>> Update(long id, ReqUpdateSMT_CauTrucDe_Thanh_PhanDTO dto)
        {
            try
            {
                var entity = await _repo.GetById(id);

                if (entity == null)
                {
                    return new RestResponse<object>
                    {
                        StatusCode = 404,
                        Message = "Không tìm thấy thành phần cấu trúc đề"
                    };
                }

                entity.id_cautrucde = dto.id_cautrucde;
                entity.note = dto.note;
                entity.type_answer = dto.type_answer;
                entity.order = dto.order;
                entity.coefficient = dto.coefficient;
                entity.is_fixed = dto.is_fixed;
                entity.so_cau_hoi = dto.so_cau_hoi;
                entity.total_question = dto.total_question;
                entity.total_score = dto.total_score;

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
                        Message = "Không tìm thấy thành phần cấu trúc đề"
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

        public async Task<RestResponse<object>> GetByCauTrucDe(long id)
        {
            try
            {
                var entities = await _repo.Query()
                    .Where(x => x.id_cautrucde == id)
                    .AsNoTracking()
                    .OrderBy(x => x.order)
                    .ToListAsync();

                var result = entities.Select(MapToDTO);

                return new RestResponse<object>
                {
                    StatusCode = 200,
                    Message = "Danh sách thành phần theo cấu trúc đề",
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