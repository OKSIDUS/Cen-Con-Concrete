using Cen_ConWEB.BAL.Interfaces;
using Cen_ConWEB.BAL.Services;
using Cen_ConWEB.DAL;
using Cen_ConWEB.DAL.Repositories;
using Cen_ConWEB.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Регистрация конфигурации
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

//DAL
builder.Services.AddHttpClient<IJobRepository, JobRepository>();
builder.Services.AddHttpClient<ICrewRepository, CrewRepoitory>();
builder.Services.AddHttpClient<IClientRepository, ClientRepository>();
builder.Services.AddHttpClient<IConcreteCustomerRepository, ConcreteCustomerRepository>();
builder.Services.AddHttpClient<IConcreteSupplierRepository, ConcreteSupplierRepository>();
builder.Services.AddHttpClient<IFinishTypeRepository, FinishTypeRepository>();
builder.Services.AddHttpClient<IJobTypeRepository, JobTypeRepository>();

//BAL
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IConcreteCustomerService, ConcreteCustomerService>();
builder.Services.AddScoped<IConcreteSupplierService, ConcreteSupplierService>();
builder.Services.AddScoped<IFinishService, FinishService>();
builder.Services.AddScoped<ICrewService, CrewService>();
builder.Services.AddScoped<IJobTypeService, JobTypeService>();

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();