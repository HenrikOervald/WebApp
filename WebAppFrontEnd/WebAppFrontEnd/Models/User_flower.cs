using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFrontEnd.Models
{
    public class User_flower
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Flower_id { get; set; }

        [DataType(DataType.Date)]
        public DateTime User_flower_creation_date { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Last_watered { get; set; }
    }
}
