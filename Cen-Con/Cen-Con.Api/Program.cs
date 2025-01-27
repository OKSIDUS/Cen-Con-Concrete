using Cen_Con.BAL.Interfaces;
using Cen_Con.BAL.Services;
using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.Repositories;
using Cen_Con.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CenConDbContext>(options =>
    options.UseSqlServer(defaultConnectionString));

// Настройка Serilog
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

//DAL
builder.Services.AddScoped<IClientsRepository, ClientRepository>();
builder.Services.AddScoped<IConcreteSuppliersRepository, ConcreteSuppliersRepository>();
builder.Services.AddScoped<ICrewsRepository, CrewsRepository>();
builder.Services.AddScoped<IFinishesRepository, FinishRepository>();
builder.Services.AddScoped<IJobsRepository, JobsRepository>();
builder.Services.AddScoped<IStatusesRepository, StatusesRepository>();
builder.Services.AddScoped<IConcreteOrderRepository, ConcreteOrderRepository>();
builder.Services.AddScoped<IJobTypesRepository, JobTypesRepository>();

//BAL
builder.Services.AddScoped<IClientsService, ClientService>();
builder.Services.AddScoped<IConcreteSuppliersService, ConcreteSupplierService>();
builder.Services.AddScoped<ICrewsService, CrewService>();
builder.Services.AddScoped<IFinishesService, FinishesService>();
builder.Services.AddScoped<IJobsService, JobsService>();
builder.Services.AddScoped<IStatusesService, StatusesService>();
builder.Services.AddScoped<IConcreteOrderService, ConcreteOrderService>();
builder.Services.AddScoped<IJobTypeService, JobTypeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
