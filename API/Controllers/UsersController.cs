using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IMapper _mapper;
        
        private readonly IUserRepo _userRepo;
        public UsersController(IUserRepo userRepo,IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        [HttpGet]
          public async Task <ActionResult<IEnumerable<MemberDto>>>GetUsers()
        {
            var users = await _userRepo.GetMembersAsync();
            var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            return Ok(usersToReturn);
        }
        [HttpGet("{username}")]
        public async Task <ActionResult<MemberDto>>GetUser(string username)
        { 
            return await _userRepo.GetMemberAsync(username);
           
        }
    }
}