namespace SatRecruitment.Domain.Entities.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task AddUserAsync(User user);
        Task<bool> IsDuplicatedUserAsync(User user);
    }
}
