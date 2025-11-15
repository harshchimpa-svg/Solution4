using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourAppNamespace.Models;

namespace Data.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectContext _context;

        public UserRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User employee)
        {
            _context.Users.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUser(User input)
        {
            _context.Users.Update(input);
            await _context.SaveChangesAsync();
        }
        public async Task<User?> GetByEmail(string email)
        {

            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }


        public async Task<User?> GetById(int id)
        {

            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email
            && x.PasswordHash == password);

        }

        public async Task<User?> GetByIdAndPassword(int id, string password)
        {
            return await _context.Users
             .FirstOrDefaultAsync(x => x.Id == id && x.PasswordHash == password);
        
        }

        public async Task<string> ResetPasswordCode(string emailId, int userId, string ipAddress)
        {
            var resetCode = new ResetPasswordCode(userId, emailId, ipAddress);

            _context.ResetPasswordCodes.Add(resetCode);
            await _context.SaveChangesAsync();

            return resetCode.Code;
        }

        public async Task<ResetPasswordCode?> ValidateResetPasswordCode(string code)
        {

            return await _context.ResetPasswordCodes
                 .FirstOrDefaultAsync(x => x.Code == code
                 && x.ValidDate >= DateTime.UtcNow
                 && x.Status == ResetPasswordStatus.Created);
        }

        public async Task UpdateResetPasswordCode(ResetPasswordCode input)
        {
            _context.ResetPasswordCodes.Update(input);

            await _context.SaveChangesAsync();
        }
    }
}
