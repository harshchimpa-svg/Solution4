using Domain;
using Microsoft.EntityFrameworkCore;
using YourAppNamespace.Models;

namespace Data;

public class ProjectContext : DbContext
{

    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }


    public DbSet<ResetPasswordCode> ResetPasswordCodes { get; set; }
}
