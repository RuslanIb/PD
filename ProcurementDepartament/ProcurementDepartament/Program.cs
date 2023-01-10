using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcurementDepartament.Data;
using System.Drawing.Text;
using System.Security.Policy;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProcurementDepartamentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProcurementDepartamentContext") ?? throw new InvalidOperationException("Connection string 'ProcurementDepartamentContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

internal class StartUp
{
    private IConfigurationRoot _confSting;

    public StartUp(IHostEnvironment hostEnv)
    {
        _confSting = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("appsettings.json").Build();
    }
}