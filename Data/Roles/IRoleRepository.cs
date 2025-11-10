using Domain;

namespace Data.Roles
{
    public interface IRoleRepository
    {
        Task<Role> GetById(int id);
        Task<Role> CreateRole(Role role);

        Task<List<Role>> GetAllRoles();

        Task DeleteRole(int id);

        Task<Role> UpdateRole(int id, Role role);

    }

}
