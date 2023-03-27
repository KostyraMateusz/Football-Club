global using FootballClubLibrary.Data;
using FootballClubLibrary.Intefaces;
using FootballClubLibrary.Interfaces;
using FootballClubLibrary.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IKlubRepository, KlubRepository>();
builder.Services.AddScoped<IZarzadRepository, ZarzadRepository>();
builder.Services.AddScoped<IPilkarzRepository, PilkarzRepository>();
builder.Services.AddScoped<IPracownikRepository, PracownikRepository>();
builder.Services.AddScoped<IStatystykaRepository, StatystykaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
