using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppBackend.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Password { get; set; }

        public User(string username, string first_name, string last_name, string password)
        {
            this.Username = username;
            this.First_name = first_name;
            this.Last_name = last_name;
            this.Password = password;
        }

        public User(string username, string first_name, string last_name)
        {
            Username = username;
            First_name = first_name;
            Last_name = last_name;
        }
    }
}
