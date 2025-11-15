using Domain;
using YourAppNamespace.Models;

namespace Data.Users
{
    public interface IUserRepository
    {

        Task<User> CreateUser(User employee);

        Task<User?> GetByEmail(string email);
        Task<User?> GetById(int id);

        Task<User?> GetByIdAndPassword(int id, string password);

        Task DeleteUser(int id);
        Task UpdateUser(User input);

        Task<User?> LoginAsync(string email, string password);



        Task<string> ResetPasswordCode(string emailId, int UserId, string ipAddress);

        Task<ResetPasswordCode?> ValidateResetPasswordCode(string code);

        Task UpdateResetPasswordCode(ResetPasswordCode input);

    }
}
