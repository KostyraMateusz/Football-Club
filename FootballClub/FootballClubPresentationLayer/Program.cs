using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using FootballClubLibrary.Data;
using FootballClubLibrary.Intefaces;
using FootballClubLibrary.Interfaces;
using FootballClubLibrary.Repositories;
using FootballClubLibrary.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IKlubRepository, KlubRepository>();
builder.Services.AddScoped<IZarzadRepository, ZarzadRepository>();
builder.Services.AddScoped<IPilkarzRepository, PilkarzRepository>();
builder.Services.AddScoped<IPracownikRepository, PracownikRepository>();
builder.Services.AddScoped<IStatystykaRepository, StatystykaRepository>();
builder.Services.AddScoped<IKlubService, KlubService>();
builder.Services.AddScoped<IPilkarzService, PilkarzService>();
builder.Services.AddScoped<IPracownikService, PracownikService>();
builder.Services.AddScoped<IStatystykaService, StatystykaService>();
builder.Services.AddScoped<IZarzadRepository, ZarzadRepository>();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("CorsPolicy", build =>
{
    build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

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

app.UseCors("CorsPolicy");
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
