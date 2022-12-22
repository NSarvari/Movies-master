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
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
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
                    //context.SaveChanges();
                }

                //Actor
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName="Tom Cruise",
                            Bio="Thomas Cruise Mapother IV, known professionally as Tom Cruise, is an American actor and producer.",
                            ProfilePictureUrl="https://pyxis.nymag.com/v1/imgs/4e5/1f7/a917c50e70a4c16bc35b9f0d8ce0352635-14-tom-cruise.rsquare.w700.jpg"
                        },

                        new Actor()
                        {
                            FullName = "Robert Downey Jr.",
                            Bio="Robert John Downey Jr. is an American actor and producer.",
                            ProfilePictureUrl="https://m.media-amazon.com/images/I/51ksF2xwOtL._AC_SY780_.jpg"
                        },

                        new Actor()
                        {
                            FullName = "Johnny Depp",
                            Bio="John Christopher Depp II is an American actor and musician.",
                            ProfilePictureUrl="https://resizing.flixster.com/XG2-qBop3NJnsyyfWPXnX2LxxIY=/300x300/v2/https://flxt.tmsimg.com/v9/AllPhotos/33623/33623_v9_bc.jpg"
                        },

                        new Actor()
                        {
                            FullName = "Angelina Jolie",
                            Bio="Angelina Jolie DCMG is an American actress, filmmaker, and humanitarian.",
                            ProfilePictureUrl="https://cdn.britannica.com/61/103761-050-0174C1D5/Angelina-Jolie-Hollywood.jpg?w=400&h=300&c=crop"
                        },
                    });

                    //context.SaveChanges();
                }
                //Movie
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name="Pirates of the Caribbean 1",
                            Description="A blacksmith joins forces with Captain Jack Sparrow, a pirate, in a bid to free the love of his life from Jack's associates, who kidnapped her suspecting she has the medallion.",
                            ImageUrl="https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRKTcTqELNNPpy-c6orc876-Yxo-_QKENBdIufLEZNlSjHQBj_i",
                            Price="12 leva",
                            StartDate=DateTime.Now.AddDays(-4),
                            EndDate=DateTime.Now.AddDays(+2),
                            CinemaId=1,
                            ProducerID=2,
                            MovieCategory=MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Top Gun 2",
                            Description = "After more than 30 years of service as one of the Navy's top aviators, Pete 'Maverick' Mitchell is where he belongs, pushing the envelope as a courageous test pilot and dodging the advancement in rank that would ground him.",
                            ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRLeDZOOOe39EylZoDSJteMkbX8lqS4JT-SvEZ8W2M6s1DRBZMd",
                            Price = "12 leva",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(+12),
                            CinemaId = 2,
                            ProducerID = 1,
                            MovieCategory = MovieCategory.Action
                        }
                    });
                    //context.SaveChanges();
                }
                //MovieActor
                if (!context.MovieActors.Any())
                {
                    context.MovieActors.AddRange(new List<MovieActor>()
                    {
                        new MovieActor()
                        {
                            MovieId=1,
                            ActorId=3
                        },

                        new MovieActor()
                        {
                            MovieId=2,
                            ActorId=1
                        }
                    });

                    //context.SaveChanges();
                }
                //Producer
                //if (!context.Producers.Any())
                //{
                //    context.Producers.AddRange(new List<Producer>()
                //    {
                //        new Producer()
                //        {
                //            FullName="Tom Cruise",
                //            Bio="Thomas Cruise Mapother IV, known professionally as Tom Cruise, is an American actor and producer.",
                //            ProfilePictureUrl="https://pyxis.nymag.com/v1/imgs/4e5/1f7/a917c50e70a4c16bc35b9f0d8ce0352635-14-tom-cruise.rsquare.w700.jpg"
                //        },

                //        new Producer()
                //        {
                //            FullName="Jerry Bruckheimer",
                //            Bio="Jerome Leon Bruckheimer is an American film and television producer.",
                //            ProfilePictureUrl="https://resizing.flixster.com/LTs_UeHAc7D4LRRwMrJE5Q3vUYA=/218x280/v2/https://flxt.tmsimg.com/assets/71005_v9_ba.jpg"
                //        }
                //    });

                //}
                context.SaveChanges();
            }
        }
    }
}
