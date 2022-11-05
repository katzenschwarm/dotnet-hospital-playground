using HMS.Database;
using HMS.Services.Infrastructure.Depencency;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterApplicationServices();
builder.Services.RegisterApplicationRepositories();

builder.Services.AddControllers();

builder.Services.AddDbContext<HospitalDbContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        builder => builder.MigrationsAssembly("HMS.WebApi"))
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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