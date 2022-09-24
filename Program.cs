using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OOP.Models;
using OOP.Models.Lab1.Task3;
using OOP.Models.Lab2;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OOPDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeesConnection"));
});

builder.Services.AddScoped<IEmployeesRepository, EFEmployeeRepository>();
#endregion

var app = builder.Build();

#region Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.MapDefaultControllerRoute();
#endregion

app.Run();
