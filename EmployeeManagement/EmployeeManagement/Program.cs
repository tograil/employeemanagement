using EmployeeManagement.Domain.Contracts;
using EmployeeManagement.Infrastructure.Context;
using EmployeeManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EmployeeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRolesService, RolesService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Services.CreateScope().ServiceProvider
    .GetRequiredService<EmployeeContext>()
    .Database
    .EnsureCreated();

app.Run();
