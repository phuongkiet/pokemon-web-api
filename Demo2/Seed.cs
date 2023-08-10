using Demo2.Entity;
using System.Diagnostics.Metrics;

namespace Demo2
{
    public class Seed
    {
        private AppDbContext dataContext;

        public void SeedDataContext()
        {
            dataContext = new AppDbContext();
            if (!dataContext.PokemonOwners.Any())
            {
                var pokemonOwners = new List<PokemonOwners>()
                {
                    new PokemonOwners()
                    {
                        Pokemon = new Pokemon()
                        {
                            Name = "Pikachu",
                            BirthDate = new DateTime(1903,1,1),
                            Sex = "Male",
                            IsShiny = false,
                            PokemonCategories = new List<PokemonCategories>()
                            {
                                new PokemonCategories { Category = new Category() { Name = "Electric"}}
                            },
                        },
                        Owner = new Owner()
                        {
                            Name = "Takeshi",
                            Gym = "Nibi Gym",
                            Region = new Region()
                            {
                                Name = "Kanto"
                            }
                        }
                    },
                    new PokemonOwners()
                    {
                        Pokemon = new Pokemon()
                        {
                            Name = "Zenigame",
                            BirthDate = new DateTime(1903,1,1),
                            Sex = "Male",
                            IsShiny = false,
                            PokemonCategories = new List<PokemonCategories>()
                            {
                                new PokemonCategories { Category = new Category() { Name = "Water"}}
                            },
                        },
                        Owner = new Owner()
                        {
                            Name = "Kasumi",
                            Gym = "Hanada Gym",
                            Region = new Region()
                            {
                                Name = "Kanto"
                            }
                        }
                    },
                                    new PokemonOwners()
                    {
                        Pokemon = new Pokemon()
                        {
                            Name = "Fushigidane",
                            BirthDate = new DateTime(1903,1,1),
                            Sex = "Male",
                            IsShiny = false,
                            PokemonCategories = new List<PokemonCategories>()
                            {
                                new PokemonCategories { Category = new Category() { Name = "Leaf"}}
                            },
                        },
                        Owner = new Owner()
                        {
                            Name = "Satoshi",
                            Gym = "Masara Gym",
                            Region = new Region()
                            {
                                Name = "Kanto"
                            }
                        }
                    }
                };
                dataContext.PokemonOwners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
