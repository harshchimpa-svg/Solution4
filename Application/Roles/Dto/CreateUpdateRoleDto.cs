using System.ComponentModel.DataAnnotations;

namespace Application.Roles.DTO;

public class CreateUpdateRoleDto
{
    [Required(ErrorMessage="Name is required!")]
    public string Name { get; set; }
}
