using Application.Roles.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Roles
{
    public interface IRoleApplication
    {
        Task<Role> AddRole(CreateUpdateRoleDto input);

        Task<Role> UpdateRole(int id, CreateUpdateRoleDto input);

        Task DeleteRole(int id);

        Task<List<RoleDto>> GetAllRoles();

    }
}
