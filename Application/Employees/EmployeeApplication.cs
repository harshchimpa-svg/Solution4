using Application.Users.Dto;
using Application.Roles.DTO;
using AuthWebApp.Service.UserLogins.Dto;
using Data.Users;
using Domain;
using YourAppNamespace.Models;
using Application.Employees.Dto;

namespace Application.Users
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _employeeRepository;

        public async Task<int> CreateUser(CreateUserDto input)
        {
            var checkUser = await _employeeRepository.GetByEmail(input.Email);

            if (checkUser != null)
            {
                throw new Exception("Email Id already Exists");
            }

            var employee = new User();
            employee.Name = input.Name;
            employee.Email = input.Email;
            employee.PasswordHash = input.Password;

            employee.CreatedDate = DateTime.Now;

            var response = await _employeeRepository.CreateUser(employee);
              
            return response.Id;
        }
        public async Task<int> updateDTO(updateDTO input)
        {
            var employee = await _employeeRepository.GetByEmail(input.Name);

            if (employee != null)
            {
                throw new Exception("name is already Exists");  
            }

            var user = new User();
            employee .Name = input.Name;
            employee.Email=input.EmailId;
            var response = _employeeRepository.UpdateUser(employee);
        }
        public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _employeeRepository.LoginAsync(dto.Email, dto.Password);

            if (user == null)
            {
                throw new Exception("Invalid username/email or password");
            } 


            return new LoginResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            };
        }

        public async Task<bool> ChangePasswordAsync(int id, ChangePasswordDto dto)
        {
            var employee = await _employeeRepository.GetByIdAndPassword(id, dto.OldPassword);


            if (employee == null)
            {
                throw new Exception("User Not Found !");
            }



            employee.PasswordHash = dto.NewPassword;


            await _employeeRepository.UpdateUser(employee);

            return true;

        }

        public async Task<string> ForgetPasswordAsync(string emailId, string ipAddress)
        {
            var checkUser = await _employeeRepository.GetByEmail(emailId);

            if (checkUser == null)
            {
                throw new Exception("Email Id not Exists");
            }

            var code = await _employeeRepository.ResetPasswordCode(emailId, checkUser.Id, ipAddress);

            return code;

        }

        public async Task ResetPassword(ResetPasswordDto input)
        {
            var result = await _employeeRepository.ValidateResetPasswordCode(input.Code);

            if (result == null)
            {
                throw new Exception(" code is not valid");
            }

            var employee = await _employeeRepository.GetById(result.UserId);

            if (employee == null)
            {
                throw new Exception("User not found");
            }

            employee.PasswordHash = input.Password;

            await _employeeRepository.UpdateUser(employee);


            result.Status = ResetPasswordStatus.Used;

            await _employeeRepository.UpdateResetPasswordCode(result);
        }
        public async Task DeleteUser(int id)
        {
            await _employeeRepository.DeleteUser(id);
        }

        public Task updateDTO(string name)
        {
            throw new NotImplementedException();
        }

        public Task updateDTO(string name, updateDTO input)
        {
            throw new NotImplementedException();
        }
    }
    
}






