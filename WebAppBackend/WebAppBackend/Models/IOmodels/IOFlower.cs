using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBackend.Models.DBmodels;

namespace WebAppBackend.Models.IOmodels
{
    public class IOFlower : Flower
    {
        public List<User_Flower> FlowerDetails {get; set;}

        public IOFlower(int id, string flower_name, string flower_name_latin, string flower_info, int watering_interval , List<User_Flower> flowerdetails) : base(id, flower_name, flower_name_latin,flower_info,watering_interval)
        {

        }
    }
}
