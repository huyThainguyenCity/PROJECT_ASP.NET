using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_ASP.NET.Repository;

namespace Project_ASP.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ProjectPRN231_HuyDQContext _context;
        private readonly IUserRepository _us;

        public UsersController(ProjectPRN231_HuyDQContext context, IUserRepository us)
        {
            _context = context;
            _us = us;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetUsers()
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            return await _context.Accounts.ToListAsync();
        }

        [HttpGet("{email}/{pass}")]
        public async Task<ActionResult<Account>> GetUser(string email, string pass)
        {
            if (_us.GetUser(email, pass) == false)
            {
                return NotFound();
            }
            var users = _context.Accounts.FirstOrDefault(u => u.Username == email);
            return users;
        }

        [HttpPost("{email}/{pass}/{role}")]
        public async Task<ActionResult<Account>> PostUser(string email, string pass, int role)
        {
            try
            {
                if (role != 1 && role != 2)
                {
                    return BadRequest("Giá trị role không hợp lệ. Chỉ chấp nhận role là 1 (teacher) hoặc 2 (student).");
                }
                bool emailExists = _context.Accounts.Any(a => a.Username == email);
                if (emailExists)
                {
                    return BadRequest("Email đã tồn tại. Vui lòng sử dụng một email khác.");
                }
                Account user = new Account()
                {
                    Username = email,
                    Password = pass,
                    RoleId = role,
                };
                _context.Accounts.Add(user);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Ok(ex.GetBaseException);
            }
        }
    }
}
