using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestRentHouse.Models;

namespace TestRentHouse.Context
{
    public class HouseDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Images> Images { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<User> Users { get; set; }



   

        public HouseDbContext(DbContextOptions<HouseDbContext> options) : base(options)
        {

            if (Database.EnsureCreated())
            {
                Districts?.AddRange(
                    new District { Name = "Black District" },
                    new District { Name = "White District" },
                    new District { Name = "Yellow District" },
                    new District { Name = "Red District" },
                    new District { Name = "Pink District" },
                    new District { Name = "Blue District" },
                    new District { Name = "Wheat District" },
                    new District { Name = "Green District" },
                    new District { Name = "Sky District" }
                    );

                SaveChanges();




                Cities?.AddRange(
                    new City { Name = "Mayami", Districts = Districts?.Where(x => new List<string>() { "Black District", "White District", "Yellow District" }.Contains(x.Name)).ToList() },
                    new City { Name = "Vice City", Districts = Districts?.Where(x => new List<string>() { "Red District", "Pink District", "Blue District" }.Contains(x.Name)).ToList() },
                    new City { Name = "San Andreas", Districts = Districts?.Where(x => new List<string>() { "Wheat District", "Green District", "Sky District" }.Contains(x.Name)).ToList() }
                                );
                SaveChanges();




                Countries?.AddRange(
                    new Country
                    {
                        Name = "LostWorld",
                        Cities = Cities?.Where(x => new List<string>() { "Mayami", "Vice City", "San Andreas" }.Contains(x.Name)).ToList()
                    });
                SaveChanges();


                Houses?.AddRange(
                    new House { District = Districts?.Where(x => x.Name == "Black District").FirstOrDefault(),
                        Name = "Обьявление номер 1", Area = 333, CountFloor = 3, CountRoom = 12, 
                        Description = "Super magic House", Subscribe = 3, Price = 10000000 , Is_Valid = true ,
                        Images_Path = new List<Images> {
                    new Images { Path = "Images\\2123123.jpg" },
                    new Images { Path = "Images\\2123123.jpg" },
                    new Images { Path = "Images\\2123123.jpg" },
                    new Images { Path = "Images\\2123123.jpg" },
                    new Images { Path = "Images\\2123123.jpg" }

                        }} );

                SaveChanges();



                Statuses?.AddRange(
                    new Status { Name = "admin" },
                    new Status { Name = "user" },
                    new Status { Name = "guest" }
                    );
                SaveChanges();



                Favorites?.Add( new Favorites { idAdt = Houses.FirstOrDefault().Id });
                SaveChanges();


                Users?.AddRange(
                    new User { Status = Statuses.Where(x => x.Name == "admin").FirstOrDefault() ,
                                Email = "admin@gmail.com",
                                Password = "1111" ,
                                Salt = "1111",
                                FirstName = "Rick" ,
                                LastName = "Sanches" ,
                                Number = "123456789",
                                Houses =  new List<House> { Houses.First()} ,
                                Favorites = new List<Favorites> { Favorites.First()} ,                                

                    }
                    );

                SaveChanges();



            }



        }
    }
}
