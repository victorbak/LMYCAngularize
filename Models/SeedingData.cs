//using LmycAPI.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace LmycAPI.Models
//{
//    public class SeedingData
//    {
//        public static void Initialize(ApplicationDbContext db)
//        {
//            if (!db.Boats.Any())
//            {
//                db.Boats.Add(new Boat
//                {
//                    BoatName = "Bob",
//                    Picture = "http://images.boats.com/resize/wp/2/files/2017/05/jeanneau-51-transom.jpg?w=450&h=450",
//                    FeetInInches = 12,
//                    Make = "Canada",
//                    Year = "2012",
//                    RecordCreationDate = DateTime.Today,
//                    CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id

//                });
//                db.Boats.Add(new Boat
//                {
//                    BoatName = "The Titanic",
//                    Picture = "http://images.boats.com/resize/wp/2/files/2017/05/jeanneau-51-transom.jpg?w=450&h=450",
//                    FeetInInches = 12,
//                    Make = "Canada",
//                    Year = "2011",
//                    RecordCreationDate = DateTime.Today,
//                    CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id

//                });
//                db.Boats.Add(new Boat
//                {
//                    BoatName = "Shirley",
//                    Picture = "http://images.boats.com/resize/wp/2/files/2017/05/jeanneau-51-transom.jpg?w=450&h=450",
//                    FeetInInches = 12,
//                    Make = "Canada",
//                    Year = "2010",
//                    RecordCreationDate = DateTime.Today,
//                    CreatedBy = db.Users.FirstOrDefault(u => u.UserName == "a").Id

//                });
//                db.SaveChanges();
//            }
//        }
//    }
//}
