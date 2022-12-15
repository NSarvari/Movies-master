using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = 
                applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.
                    ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Iskra",
                            Logo="https://upload.wikimedia.org/wikipedia/commons/f/f8/Iskra-logo.jpg",
                            Description="A cinema in Veliko Tarnovo"
                        },

                        new Cinema()
                        {
                            Name = "Palace",
                            Logo="https://meetolerance.eu/wp-content/uploads/2018/11/logo-cinema-palace.png",
                            Description="A cinema in Europe"
                        },

                        new Cinema()
                        {
                            Name = "Arena",
                            Logo="https://searchlogovector.com/wp-content/uploads/2018/07/arena-cinemas-logo-vector.png",
                            Description="A cinema in Bulgaria"
                        },

                    });
                }

                //Actor
                if (!context.Actors.Any())
                {

                }
                //Movie
                if (!context.Movies.Any())
                {

                }
                //MovieActor
                if (!context.MovieActors.Any())
                {

                }
                //Producer
                if (!context.Producers.Any())
                {

                }
            }
        }
    }
}
