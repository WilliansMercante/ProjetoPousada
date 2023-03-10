using Microsoft.EntityFrameworkCore;

using ProjetoPousada.Infra.Contexts;
using ProjetoPousada.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ConfiguracaoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PROJETO_POUSADA")), ServiceLifetime.Scoped);
builder.Services.AddDbContext<ProjetoPousadaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PROJETO_POUSADA")), ServiceLifetime.Scoped);

InjectionDependencyCore.ConfigureServices(builder.Services);

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
    pattern: "{controller}/{action}/{id?}");

app.MapGet("/", context =>
{
    return Task.Run(() => context.Response.Redirect("/Autenticar/Index"));
});


app.Run();
