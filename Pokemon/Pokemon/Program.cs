using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Pokemon.Data;
using Pokemon.Logic.Interfaces;
using Pokemon.Logic.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpClient<IPokeApiService, PokeApiService>(options => options.BaseAddress = new Uri("https://pokeapi.co"));

builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<IWhoService, WhoService>();

builder.Services.AddMemoryCache();

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");    
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