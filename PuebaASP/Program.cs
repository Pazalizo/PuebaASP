using Microsoft.EntityFrameworkCore;
using PruebaASP.Data;
using PuebaASP.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura el DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Añadir datos de prueba si la base de datos está vacía
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MyDbContext>();

    // Asegúrate de que la base de datos esté actualizada
    context.Database.Migrate();

    // Verifica si hay datos en las tablas y agrega datos de prueba si es necesario
    if (!context.Airports.Any())
    {
        context.Airports.AddRange(
            new Airport { Name = "JFK Airport", CodeIATA = "JFK", City = "New York" },
            new Airport { Name = "LAX Airport", CodeIATA = "LAX", City = "Los Angeles" }
        );
        context.SaveChanges();
    }

    if (!context.Planes.Any())
    {
        context.Planes.AddRange(
            new Plane { Name = "Boeing 747", Registration = "N12345" },
            new Plane { Name = "Airbus A320", Registration = "N67890" }
        );
        context.SaveChanges();
    }

    if (!context.Crews.Any())
    {
        context.Crews.AddRange(
            new Crew { Code = "CRW001" },
            new Crew { Code = "CRW002" }
        );
        context.SaveChanges();
    }

    if (!context.Flights.Any())
    {
        context.Flights.AddRange(
            new Flight { Code = "FL001", FlightDate = DateTime.Now, AirportOriginId = 1, AirportDestinationId = 2, PlaneId = 1, CrewId = 1 },
            new Flight { Code = "FL002", FlightDate = DateTime.Now.AddDays(1), AirportOriginId = 2, AirportDestinationId = 1, PlaneId = 2, CrewId = 2 }
        );
        context.SaveChanges();
    }

    if (!context.Passengers.Any())
    {
        context.Passengers.AddRange(
            new Passenger { Document = 12345678, Name = "John Doe", Age = 30, LuggageId = 1 },
            new Passenger { Document = 87654321, Name = "Jane Smith", Age = 25, LuggageId = 2 }
        );
        context.SaveChanges();
    }

    if (!context.Bookings.Any())
    {
        context.Bookings.AddRange(
            new Booking { Code = 1001, PassengerId = 1, FlightId = 1 },
            new Booking { Code = 1002, PassengerId = 2, FlightId = 2 }
        );
        context.SaveChanges();
    }

    if (!context.Luggages.Any())
    {
        context.Luggages.AddRange(
            new Luggage { Weight = 23.5 },
            new Luggage { Weight = 18.0 }
        );
        context.SaveChanges();
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
