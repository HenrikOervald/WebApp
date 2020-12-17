using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFrontEnd.Models
{
    public class IOUser : User
    {
        public List<User_flower> User_Flowers { get; set; }
    }
}
