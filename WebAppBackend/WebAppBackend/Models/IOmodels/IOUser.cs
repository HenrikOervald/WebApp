using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBackend.Models.DBmodels;

namespace WebAppBackend.Models.IOmodels
{
    public class IOUser : User
    {
        public List<IOFlower> Flowers { get; set; }

        public IOUser(string username, string first_name, string last_name, List<IOFlower> flowers) : base (username, first_name,last_name) 
        {
            //TODO: Write something here that makes sence so that the IO format for IOUser fits 
        }
    }
}
