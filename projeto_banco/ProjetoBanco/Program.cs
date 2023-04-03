using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoBanco.Areas.Identity.Data;
using ProjetoBanco.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BancoContextConnection") ?? throw new InvalidOperationException("Connection string 'BancoContextConnection' not found.");

builder.Services.AddDbContext<BancoContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Cliente>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<BancoContext>(); ;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IChavePixRepository, ChavePixRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

