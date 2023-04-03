using CRUD_SQLSERVER.Persistence;
using CRUD_SQLSERVER.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Injeção de dependencia do banco de dados sql
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PetShopContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("conexao")));

//Configurar injeção de dependência dos repositories
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();
builder.Services.AddScoped<IPlanoRepository, PlanoRepository>();
builder.Services.AddScoped<IAnimalVeterinarioRepository, AnimalVeterinarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
