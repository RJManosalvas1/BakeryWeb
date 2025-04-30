using BakeryWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BakeryWeb.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BakeryWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BakeryWebContext") ?? throw new InvalidOperationException("Connection string 'BakeryWebContext' not found.")));


builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<BakeryWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build(); 

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); 
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
