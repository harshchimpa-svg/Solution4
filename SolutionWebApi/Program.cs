
using Application.Blogs;
using Application.Employees;
using Application.Roles;
using Data;
using Data.Blogs;
using Data.Employees;
using Data.Roles;
using Microsoft.EntityFrameworkCore;
using RoleWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IBlogRepository, BlogRepository>();
builder.Services.AddTransient<IBlogApplication, BlogApplication>();
builder.Services.AddTransient<IEmployeeApplication,EmployeeApplication >();
builder.Services.AddTransient<IRoleApplication,RoleApplication>();
builder.Services.AddTransient<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddTransient<IRoleRepository,RoleRepository>();
builder.Services.AddTransient<IEmailService, EmailService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
