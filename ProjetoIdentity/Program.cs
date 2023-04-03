using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using ProjetoIdentity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ProjetoIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'ProjetoIdentityContextConnection' not found.");

builder.Services.AddDbContext<ProjetoIdentityContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ProjetoIdentityContext>();

builder.Services.AddMailKit(optionBuilder =>
{
    optionBuilder.UseMailKit(new MailKitOptions()
    {
        Server = builder.Configuration.GetValue<string>("EmailConfiguration:Server"),
        Port = Int32.Parse(builder.Configuration.GetValue<string>("EmailConfiguration:Port")),
        SenderName = builder.Configuration.GetValue<string>("EmailConfiguration:SenderName"),
        SenderEmail = builder.Configuration.GetValue<string>("EmailConfiguration:SenderEmail"),
        Account = builder.Configuration.GetValue<string>("EmailConfiguration:Account"),
        Password = builder.Configuration.GetValue<string>("EmailConfiguration:Password"),
        Security = true
    });
});

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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
