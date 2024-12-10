using System;

using CAPA_NEGOCIO;
using Microsoft.EntityFrameworkCore;
using RegistroEpidemiologico;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});


// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar los servicios de sesión
builder.Services.AddDistributedMemoryCache();  // Para almacenar la sesión en memoria
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Tiempo de expiración de la sesión
    options.Cookie.HttpOnly = true; // Seguridad
    options.Cookie.IsEssential = true; // Esencial para que funcione incluso con restricciones de cookies
});

//INICIO CONTEXTOS DE DATOS

// Configurar el contexto de base de datos
builder.Services.AddDbContext<SghrhContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cn"))
);

List<Type> types = new List<Type>
{
    typeof(BusquedaPaciente),
    typeof(UsuarioBL),
    typeof(ServicioBL),
    typeof(CamaBL)
    

};

foreach (var type in types)
{
    builder.Services.AddScoped(type);
}



//FIN CONTEXTOS DE DATOS


// Configure the HTTP request pipeline.
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // El valor predeterminado de HSTS es 30 días. Puedes cambiarlo para escenarios de producción.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Habilitar el middleware de sesión
app.UseSession();

// Configurar el enrutamiento de las solicitudes HTTP
app.UseRouting();

// Habilitar la autorización 
app.UseAuthorization();

// Configurar la ruta predeterminada del controlador
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

app.Run();
