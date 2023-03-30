using Microsoft.EntityFrameworkCore;
using SatRecruitment.Domain.Entities;
using SatRecruitment.Domain.Entities.Repositories;
using SatRecruitment.Infrastructure.Data;

namespace SatRecruitment.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> IsDuplicatedUserAsync(User user)
        {
            return await _context.Users.AnyAsync(u => u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase) ||
                u.Phone == user.Phone ||
                (u.Name.Equals(user.Name, StringComparison.OrdinalIgnoreCase) &&
                u.Address.Equals(user.Address, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
