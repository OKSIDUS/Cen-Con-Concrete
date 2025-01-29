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

//BAL
builder.Services.AddScoped<IJobService, JobService>();

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