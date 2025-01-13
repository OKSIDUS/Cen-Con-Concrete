using Cen_Con.BAL.Interfaces;
using Cen_Con.BAL.Services;
using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<CenConDbContext>(options =>
                options.UseSqlServer(defaultConnectionString));

Console.WriteLine("Default Connection String: " + defaultConnectionString);

//DAL
builder.Services.AddScoped<ITypesRepository, TypesRepository>();

//BAL
builder.Services.AddScoped<ITypesService, TypesService>();

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
