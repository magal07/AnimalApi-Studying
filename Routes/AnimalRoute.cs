using AnimalApi.Data;
using AnimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalApi.Routes
{
    public static class AnimalRoute
    {
        public static void AnimalRoutes(this WebApplication app)
        {
            var routes = app.MapGroup("animal");

            routes.MapPost("", async (AnimalRequest req, AnimalContext context, 
                                    CancellationToken ct) => {

                var animal = new AnimalModel(req.Name);
                await context.AddAsync(animal);
                await context.SaveChangesAsync();

                return Results.Ok(animal);
            });

            routes.MapGet("", async (AnimalContext context) =>
            {
                var animal = await context.Animals.ToListAsync();

                return Results.Ok(animal);
            });

            routes.MapPut("{id:guid}", async (Guid id, AnimalRequest req, AnimalContext context) =>
            {
                var animal = await context.Animals.FirstOrDefaultAsync(x => x.Id == id);

                if (animal is null) return Results.NotFound();

                animal.ChangeName(req.Name);
                await context.SaveChangesAsync();

                return Results.Ok();

            });

            routes.MapDelete("{id:guid}", async(Guid id, AnimalContext context) =>
            {
                var animal = await context.Animals.FirstOrDefaultAsync(x => x.Id == id);

                if (animal is null) return Results.NotFound();

                animal.DeleteAnimal();

                await context.SaveChangesAsync();

                return Results.Ok();
            });
        }
    }
}
