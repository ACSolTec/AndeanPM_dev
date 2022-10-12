using Andeanpm.Client;
using Andeanpm.Client.Providers;
using Andeanpm.Client.Services.AuthService;
using Andeanpm.Client.Services.BannerService;
using Andeanpm.Client.Services.FormService;
using Andeanpm.Client.Services.InvestorsService;
using Andeanpm.Client.Services.NewsService;
using Andeanpm.Client.Services.OperationsService;
using Andeanpm.Client.Services.OurPeopleService;
using Andeanpm.Client.Services.StatisticsService;
using Andeanpm.Client.Services.UploadImageService;
using Andeanpm.Client.Services.UserService;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBannerService, BannerService>();
builder.Services.AddScoped<IFormService, FormService>();
builder.Services.AddScoped<IInvestorsService, InvestorsService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IOperationsService, OperationsService>();
builder.Services.AddScoped<IOurPeopleService, OurPeopleService>();
builder.Services.AddScoped<IStatisticsService, StatisticsService>();
builder.Services.AddScoped<IUploadImageService, UploadImageService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
