using LmycAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmycAPI.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                if (!context.Users.Any(u => u.UserName == "a"))
                {
                    var adminUser = new ApplicationUser
                    {
                        UserName = "a",
                        Email = "a@a.a",
                        FirstName = "Admin",
                        LastName = "Admin",
                        AddressPostalCode = "V9X3F3",
                        AddressStreet = "3700 Willingdon Avenue",
                        AddressCity = "Burnaby",
                        AddressProvince = "BC",
                        AddressCountry = "Canada",
                        MobileNumber = "604-555-1234",
                        SailingExperience = 12
                    };

                    await userManager.CreateAsync(adminUser, "P@$$w0rd");
                    await EnsureRole(serviceProvider, adminUser.Id, "Admin");
                }

                if (!context.Users.Any(u => u.UserName == "m"))
                {
                    var userMember = new ApplicationUser
                    {
                        UserName = "m",
                        Email = "m@m.m",
                        FirstName = "Member",
                        LastName = "One",
                        AddressPostalCode = "V4G5H9",
                        AddressStreet = "3700 Willingdon Avenue",
                        AddressCity = "Burnaby",
                        AddressProvince = "BC",
                        AddressCountry = "Canada",
                        MobileNumber = "604-555-1234",
                        SailingExperience = 12
                    };

                    await userManager.CreateAsync(userMember, "P@$$w0rd");
                    //string id = await userManager.FindByNameAsync(adminUser.UserName);
                    await EnsureRole(serviceProvider, userMember.Id, "Member");
                }

                InitializeBoat(context);
                InitializeReservation(context);
            }
        }

        public static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string id, string role)
        {
            IdentityResult identityResult = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(role))
            {
                identityResult = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var user = await userManager.FindByIdAsync(id);

            identityResult = await userManager.AddToRoleAsync(user, role);
            return identityResult;
        }

        public static void InitializeBoat(ApplicationDbContext db)
        {
            if (db.Boats.Any())
            {
                return;
            }

            List<Boat> boats = new List<Boat>
                {
                    new Boat
                    {
                        BoatName = "The Titanic",
                        Picture = "http://www.boattown.com/assets/img/final/home/new-arrivals.jpg",
                        FeetInInches = 54,
                        Make = "Canada",
                        Year = "1998",
                        RecordCreationDate = DateTime.Today,
                        CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
                    },
                    new Boat
                    {
                        BoatName = "Thunderstorm",
                        Picture = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/aa/Lifeboat.17-31.underway.arp.jpg/1200px-Lifeboat.17-31.underway.arp.jpg",
                        FeetInInches = 54,
                        Make = "Canada",
                        Year = "1998",
                        RecordCreationDate = DateTime.Today,
                        CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
                    },
                    new Boat
                    {
                        BoatName = "Free Willy",
                        Picture = "http://itayachtscanada.com/wp-content/uploads/2018/03/4u5b50owk7t34ttehdhemjt4seg2ogbo.jpg.gz.jpg",
                        FeetInInches = 54,
                        Make = "Canada",
                        Year = "1998",
                        RecordCreationDate = DateTime.Today,
                        CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
                    },
                    new Boat
                    {
                        BoatName = "Flipper",
                        Picture = "https://prodwebassets.s3.amazonaws.com/boats/4681986/4681986_20140410083142702_1_XLARGE.jpg",
                        FeetInInches = 54,
                        Make = "Canada",
                        Year = "1998",
                        RecordCreationDate = DateTime.Today,
                        CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
                    },
                    new Boat
                    {
                        BoatName = "Shirley",
                        Picture = "https://completewellbeing.com/wp-content/uploads/2008/12/the-empty-boat.jpg",
                        FeetInInches = 54,
                        Make = "Canada",
                        Year = "1998",
                        RecordCreationDate = DateTime.Today,
                        CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id
                    },

                };

            db.Boats.AddRange(boats);
            db.SaveChanges();
        }

        private static void InitializeReservation(ApplicationDbContext db)
        {
            if (!db.Reservations.Any())
            {
                List<Reservation> reservations = new List<Reservation>
                    {
                        new Reservation
                        {
                            StartDateTime = DateTime.Today,
                            EndDateTime = DateTime.Today.AddDays(1),
                            CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "m").Id,
                            ReservedBoat = db.Boats.FirstOrDefault(b => b.BoatName == "Flipper").BoatId.ToString(),
                        },
                        new Reservation
                        {
                            StartDateTime = DateTime.Today.AddDays(3),
                            EndDateTime = DateTime.Today.AddDays(6),
                            CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "m").Id,
                            ReservedBoat = db.Boats.FirstOrDefault(b => b.BoatName == "Jeremiah Thomas").BoatId.ToString(),
                        },
                    };
                db.Reservations.AddRange(reservations);
                db.SaveChanges();
            }
        }
    }
}
