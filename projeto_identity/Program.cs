using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using projeto_identity.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ProjetoBancoContextConnection") ?? throw new InvalidOperationException("Connection string 'ProjetoBancoContextConnection' not found.");

builder.Services.AddDbContext<ProjetoBancoContext>(options =>
    options.UseSqlServer(connectionString));;

//requere confirmação de email
builder.Services.AddDefaultIdentity<Cliente>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ProjetoBancoContext>();;

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
