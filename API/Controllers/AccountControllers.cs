using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountControllers: BaseApiControllers
    {
        private readonly DataContext _context;
        public AccountControllers(DataContext context)
        {
            _context = context;
        }
        [HttpPost("register")]// 404 erro 
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {
            if(await UserExist(registerDto.Username)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key

            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        private async Task<bool> UserExist(string Username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == Username.ToLower());
        }
    }
}