using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Roles
{
    public class RoleRepository : IRoleRepository

    {
        private readonly ProjectContext _context;

        public RoleRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<Role> CreateRole(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetById(int id)
        {
            return await _context.Roles.FirstAsync();
        }

        public async Task<Role> UpdateRole(int id, Role input)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            role.Name = input.Name;
            role.UpdatedDate = DateTime.Now;
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }
    }

}
