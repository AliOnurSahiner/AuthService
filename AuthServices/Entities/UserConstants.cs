using AuthServices.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServices.Entities
{
    public class UserConstants
    {
        public static List<User> Users = new List<User>()
        {
            new User() { UserName = "jason_admin", Email = "jason.admin@email.com", Password = "MyPass_w0rd", FirstName = "Jason", LastName = "Bryant", Role = "Administrator" },
            new User() { UserName = "elyse_seller", Email = "elyse.seller@email.com", Password = "MyPass_w0rd", FirstName = "Elyse", LastName = "Lambert", Role = "Seller" },
        };
    }
}
