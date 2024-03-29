using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using FootballClubLibrary.Data;
using FootballClubLibrary.Interfaces;
using FootballClubLibrary.Repositories;
using FootballClubLibrary.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IKlubRepository, KlubRepository>();
builder.Services.AddScoped<IPilkarzRepository, PilkarzRepository>();
builder.Services.AddScoped<IPracownikRepository, PracownikRepository>();
builder.Services.AddScoped<IStatystykaRepository, StatystykaRepository>();
builder.Services.AddScoped<IZarzadRepository, ZarzadRepository>();

builder.Services.AddScoped<IKlubService, KlubService>();
builder.Services.AddScoped<IPilkarzService, PilkarzService>();
builder.Services.AddScoped<IPracownikService, PracownikService>();
builder.Services.AddScoped<IStatystykaService, StatystykaService>();
builder.Services.AddScoped<IZarzadService, ZarzadService>();

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
