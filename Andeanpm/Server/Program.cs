using Andeanpm.Server.Data;
using Andeanpm.Server.Services.AuthService;
using Andeanpm.Server.Services.BannerService;
using Andeanpm.Server.Services.FormService;
using Andeanpm.Server.Services.InvestorsService;
using Andeanpm.Server.Services.NewsService;
using Andeanpm.Server.Services.OperationsService;
using Andeanpm.Server.Services.OurPeopleService;
using Andeanpm.Server.Services.StatisticsService;
using Andeanpm.Server.Services.UserService;
using Andeanpm.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AndeampDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("AndeampConnection")));

// Add services to the container.

builder.Services.Configure<SmptSettings>(a => builder.Configuration.GetSection(nameof(SmptSettings)).Bind(a));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBannerService, BannerService>();
builder.Services.AddScoped<IFormService, FormService>();
builder.Services.AddScoped<IInvestorsService, InvestorsService>();
builder.Services.AddScoped<IStatisticsService, StatisticsService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IOperationsService, OperationsService>();
builder.Services.AddScoped<IOurPeopleService, OurPeopleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =
            new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
