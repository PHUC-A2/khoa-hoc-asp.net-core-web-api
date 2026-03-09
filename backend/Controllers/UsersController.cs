using backend.Data;
using backend.DTOs.common;
using backend.DTOs.request.user;
using backend.DTOs.response;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/users?page=1&pageSize=10
        [HttpGet]
        public async Task<ActionResult<RestResponse<ResultPaginationDTO<ResUserDTO>>>> GetUsers(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            var total = await _context.Users.CountAsync();
            var totalPages = (int)Math.Ceiling((double)total / pageSize);

            var users = await _context.Users
                .OrderBy(u => u.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(u => new ResUserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                })
                .ToListAsync();

            var resultPagination = new ResultPaginationDTO<ResUserDTO>
            {
                Meta = new PaginationMeta
                {
                    Page = page,
                    PageSize = pageSize,
                    Pages = totalPages,
                    Total = total
                },
                Result = users
            };

            var response = new RestResponse<ResultPaginationDTO<ResUserDTO>>
            {
                StatusCode = 200,
                Message = "Lấy danh sách người dùng",
                Data = resultPagination
            };

            return Ok(response);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestResponse<ResUserDTO>>> GetUser(long id)
        {
            var user = await _context.Users
                .Where(u => u.Id == id)
                .Select(u => new ResUserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound(new RestResponse<object>
                {
                    StatusCode = 404,
                    Message = "Không tìm thấy người dùng",
                    Data = null
                });
            }

            return Ok(new RestResponse<ResUserDTO>
            {
                StatusCode = 200,
                Message = "Lấy thông tin người dùng",
                Data = user
            });
        }

        // POST api/users
        [HttpPost]
        public async Task<IActionResult> CreateUser(ReqCreateUserDTO dto)
        {
            dto.Email = dto.Email.Trim();
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                return BadRequest(new RestResponse<object>
                {
                    StatusCode = 400,
                    Error = "VALIDATION_ERROR",
                    Message = "Email đã tồn tại",
                    Data = new { Field = "email" }
                });
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email
            };
            user.SetPassword(dto.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return StatusCode(201, new RestResponse<ResUserDTO>
            {
                StatusCode = 201,
                Message = "Tạo người dùng thành công",
                Data = new ResUserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                }
            });
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(long id, ReqUpdateUserDTO dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound(new RestResponse<object>
                {
                    StatusCode = 404,
                    Message = "Không tìm thấy người dùng"
                });

            dto.Email = dto.Email.Trim();
            if (user.Email != dto.Email && await _context.Users.AnyAsync(u => u.Email == dto.Email && u.Id != id))
            {
                return BadRequest(new RestResponse<object>
                {
                    StatusCode = 400,
                    Error = "VALIDATION_ERROR",
                    Message = "Email đã tồn tại",
                    Data = new { Field = "email" }
                });
            }

            if (dto.Name != null)
                user.Name = dto.Name;
            user.Email = dto.Email;

            await _context.SaveChangesAsync();

            return Ok(new RestResponse<ResUserDTO>
            {
                StatusCode = 200,
                Message = "Cập nhật người dùng thành công",
                Data = new ResUserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                }
            });
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new RestResponse<object>
                {
                    StatusCode = 404,
                    Message = "Không tìm thấy người dùng"
                });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new RestResponse<object>
            {
                StatusCode = 200,
                Message = "Đã xóa người dùng",
                Data = null
            });
        }
    }
}
