using Cen_Con.BAL.Interfaces;
using Cen_Con.BAL.Services;
using Cen_Con.DAL.DataContext;
using Cen_Con.DAL.Repositories;
using Cen_Con.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CenConDbContext>(options =>
    options.UseSqlServer(defaultConnectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().
    AddEntityFrameworkStores<CenConDbContext>();

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
        };
    });

builder.Services.AddAuthorization();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@.-_";
});


builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Cen-Con.Api", Version = "v1" });

    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insert token using Bearer format: Bearer {your_token}"
    });

    s.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string [] { }
        }
    });
});
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
builder.Services.AddScoped<IAuthService, AuthServcie>();
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

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
