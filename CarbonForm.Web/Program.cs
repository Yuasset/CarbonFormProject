using CarbonForm.Data.Contexts;
using CarbonForm.Data.Interfaces;
using CarbonForm.Data.Repositories;
using CarbonForm.Service.Mappings;
using CarbonForm.Service.Services;
using CarbonForm.Service.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly("CarbonForm.Data"));
});

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<GeneralMappingProfile>();
    cfg.LicenseKey = builder.Configuration["AutoMapper:LicenseKey"];
});
builder.Services.AddValidatorsFromAssemblyContaining<UserInfoValidator>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ISurveyService, SurveyService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
