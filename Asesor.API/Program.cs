
using Asesor.API.Midlewares;
using Asesor.Aplicacion;
using Asesor.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AgregarServiciosDeAplicacion();
builder.Services.AgregarServiciosDePersistencia();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Manejador de excepciones personalizado y centralizado para toda la aplicación, que captura cualquier excepción no controlada y devuelve una respuesta de error adecuada al cliente.
app.UseManejadorExcepciones();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
