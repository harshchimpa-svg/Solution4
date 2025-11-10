using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Roles.Dto;

public class BlogDto
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsPublished { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
