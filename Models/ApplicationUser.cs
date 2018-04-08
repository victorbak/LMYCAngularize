using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LmycAPI.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressStreet { get; set; }
        public string AddressPostalCode { get; set; }
        public string AddressCity { get; set; }
        public string AddressProvince { get; set; }
        public string AddressCountry { get; set; }
        public string MobileNumber { get; set; }
        public int SailingExperience { get; set; }
    }
}
