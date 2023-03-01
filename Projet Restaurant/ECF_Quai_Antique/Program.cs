using ECF_Quai_Antique.BLL.Interfaces;
using ECF_Quai_Antique.BLL.Services;
using ECF_Quai_Antique.DAL.Interfaces;
using ECF_Quai_Antique.DAL.Repository;
using ECF_Quai_Antique.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices();

// Services related to DAL
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IRestaurantData, RestaurantData>();
builder.Services.AddScoped<IRestaurantMenuData, RestaurantMenuData>();
// Services related to BLL
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IRestaurantMenuService, RestaurantMenuService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
