using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppBackend.Models.DBmodels
{
    public class User_Flower
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public int Flower_id { get; set; }

        [DataType(DataType.Date)]
        public DateTime User_flower_creation_date { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Last_watered { get; set; }
    }
}
