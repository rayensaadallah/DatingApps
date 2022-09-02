using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entity;
namespace API.Interfaces
{
    public interface IUserRepo
    {
        void Update(AppUser user);
        Task<bool>SaveAllAsync();
        Task<IEnumerable<AppUser>>GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<IEnumerable<MemberDto>>GetMembersAsync();
        Task<MemberDto>GetMemberAsync(string username);

    }
}