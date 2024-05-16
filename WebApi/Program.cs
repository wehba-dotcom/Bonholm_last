using WebApi.Service.IService;
using WebApi.Service;
using WebApi.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddHttpClient<IFeallesService, FeallesService>();
builder.Services.AddHttpClient<IAfgangTilgangService, AfgangTilgangService>();
builder.Services.AddHttpClient<IAllsand, AllsandService>();


SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
SD.FeallesAPIBase = builder.Configuration["ServiceUrls:Feallesbase"];
SD.AfgangTilgangAPIBase = builder.Configuration["ServiceUrls:AfgangTilgang"];
SD.AllsandAPIBase = builder.Configuration["ServiceUrls:Allsand"];



builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IFeallesService, FeallesService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAfgangTilgangService, AfgangTilgangService>();
builder.Services.AddScoped<IAllsand, AllsandService>();



// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });


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
