using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OOP.Hubs;
using OOP.Models;
using OOP.Models.Lab2;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddSignalR();
builder.Services.AddCors();
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
else
{
    app.UseExceptionHandler("/Shared/Error");
}

app.UseStaticFiles();
app.UseCors(policy =>
{
    policy.SetIsOriginAllowed(origin => true)
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials();
});
app.MapDefaultControllerRoute();
app.MapHub<MessageHub>("/messages");
#endregion

app.Run();
