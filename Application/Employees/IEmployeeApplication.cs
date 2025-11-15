using Application.Users.Dto;
using Application.Roles.DTO;
using AuthWebApp.Service.UserLogins.Dto;

namespace Application.Users
{
    public interface IUserApplication
    {
        Task updateDTO(string name, Employees.Dto.updateDTO input);
        Task<int> CreateUser(CreateUserDto input);
        Task<LoginResponseDto> LoginAsync(LoginDto dto);
        Task DeleteUser(int id);

        Task<bool> ChangePasswordAsync(int id, ChangePasswordDto dto);

        Task<string> ForgetPasswordAsync(string emailId, string ipAddress);

        Task ResetPassword(ResetPasswordDto input);

    }
}
