using ProdutosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosAPI.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>
            {
                new()  { Id = 1, Username = "andreza", Password = "secreta", Role = "employee" },
                new()  { Id = 2, Username = "ploomes", Password = "mastersecret", Role = "company" }
            };
            
            return users
                .FirstOrDefault(x =>
                    x.Username == username
                    && x.Password == password);
        }
    }
}
