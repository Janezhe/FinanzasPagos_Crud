using Microsoft.EntityFrameworkCore;
using FinanzasPagos_Crud.Data;
using NetEscapades.Configuration.Yaml;

var builder = WebApplication.CreateBuilder(args);

// ── Agregar configuración desde appsettings.yml ──────────────
builder.Configuration.Sources.Clear();   // limpia json por defecto
builder.Configuration.AddYamlFile("appsettings.yml", optional: false, reloadOnChange: true);

// ── MVC ──────────────────────────────────────────────────────
builder.Services.AddControllersWithViews();

// ── DbContext MySQL ───────────────────────────────────────────
var connStr = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddDbContext<FinanzasDb>(options =>
    options.UseMySql(connStr, ServerVersion.AutoDetect(connStr)));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pagos}/{action=Index}/{id?}");

app.Run();