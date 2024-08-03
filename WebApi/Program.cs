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
builder.Services.AddHttpClient<IDato1822, DatoService>();
builder.Services.AddHttpClient<IArrestprotokol, ArrestprotokolService>();
builder.Services.AddHttpClient<IBegrav, BegravService>();
builder.Services.AddHttpClient<IBorger, BorgerService>();
builder.Services.AddHttpClient<IBørn, BørnService>();
builder.Services.AddHttpClient<IChristian, ChristianService>();
builder.Services.AddHttpClient<IFoto, FotoService>();
builder.Services.AddHttpClient<IFt, FtService>();
builder.Services.AddHttpClient<IFPBog, FPBogService>();
builder.Services.AddHttpClient<IGårdReg, GårdRegService>();



SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
SD.FeallesAPIBase = builder.Configuration["ServiceUrls:Feallesbase"];
SD.AfgangTilgangAPIBase = builder.Configuration["ServiceUrls:AfgangTilgang"];
SD.AllsandAPIBase = builder.Configuration["ServiceUrls:Allsand"];
SD.DatoAPIBase = builder.Configuration["ServiceUrls:Dato"];
SD.ArrestAPIBase = builder.Configuration["ServiceUrls:arrestprotokoller"];
SD.BegravAPIBase = builder.Configuration["ServiceUrls:Begrav"];
SD.BorgerAPIBase = builder.Configuration["ServiceUrls:Borger"];
SD.BornAPIBase = builder.Configuration["ServiceUrls:Born"];
SD.ChristianAPIBase = builder.Configuration["ServiceUrls:Christian"];
SD.FotoAPIBase = builder.Configuration["ServiceUrls:Foto"];
SD.FtAPIBase = builder.Configuration["ServiceUrls:Ft"];
SD.FPBogApiBase = builder.Configuration["ServiceUrls:FPBog"];
SD.GårdRegApiBase = builder.Configuration["ServiceUrls:Greg"];



builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IFeallesService, FeallesService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAfgangTilgangService, AfgangTilgangService>();
builder.Services.AddScoped<IAllsand, AllsandService>();
builder.Services.AddScoped<IDato1822, DatoService>();
builder.Services.AddScoped<IArrestprotokol, ArrestprotokolService>();
builder.Services.AddScoped<IBegrav, BegravService>();
builder.Services.AddScoped<IBorger, BorgerService>();
builder.Services.AddScoped<IBørn, BørnService>();
builder.Services.AddScoped<IChristian, ChristianService>();
builder.Services.AddScoped<IFoto, FotoService>();
builder.Services.AddScoped<IFt, FtService>();
builder.Services.AddScoped<IFPBog, FPBogService>();
builder.Services.AddScoped<IGårdReg, GårdRegService>();



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
