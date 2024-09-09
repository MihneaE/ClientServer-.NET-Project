using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommonModule.Model;
using Microsoft.EntityFrameworkCore;

namespace CommonModule.Repository
{
    public class DataBaseInitializerRepository
    {
        internal DataBaseInitializerRepository()
        {
        }

        public static void SeedDatabase()
        {
            using (var context = new DatabaseRepository())
            {
                if (!context.Users.Any() && !context.Men.Any() && !context.Competitions.Any())
                {
                    var users = new List<User>
                {
                    new User { username = "x", password = "x" },
                    new User { username = "y", password = "y" },
                    new User { username = "z", password = "z" }
                };

                    var men = new List<Man>
                {
                    new Man { sample_id = 1, name = "John", age = 21 },
                    new Man { sample_id = 2, name = "Andrei", age = 17 },
                    new Man { sample_id = 3, name = "Mihai", age = 18 },
                    new Man { sample_id = 4, name = "Ionut", age = 19 },
                    new Man { sample_id = 5, name = "Adrian", age = 18 },
                    new Man { sample_id = 6, name = "Florin", age = 20 },
                    new Man { sample_id = 7, name = "George", age = 20 },
                    new Man { sample_id = 8, name = "Matei", age = 21 },
                    new Man { sample_id = 9, name = "Flaviu", age = 17 },
                    new Man { sample_id = 3, name = "Marius", age = 18 }
                };

                    var competitions = new List<Competition>
                {
                    new Competition { sample = "Desen", ageCategory = "6-8 ani", count = 1 },
                    new Competition { sample = "Desen", ageCategory = "9-11 ani", count = 1 },
                    new Competition { sample = "Desen", ageCategory = "12-15 ani", count = 2 },
                    new Competition { sample = "Cautarea unei comori", ageCategory = "6-8 ani", count = 1 },
                    new Competition { sample = "Cautarea unei comori", ageCategory = "9-11 ani", count = 1 },
                    new Competition { sample = "Cautarea unei comori", ageCategory = "12-15 ani", count = 1 },
                    new Competition { sample = "Poezie", ageCategory = "6-8 ani", count = 1 },
                    new Competition { sample = "Poezie", ageCategory = "9-11 ani", count = 1 },
                    new Competition { sample = "Poezie", ageCategory = "12-15 ani", count = 1 }
                };

                    context.Users.AddRange(users);
                    context.Men.AddRange(men);
                    context.Competitions.AddRange(competitions);

                    context.SaveChanges();
                }
            }
        }
    }
}
