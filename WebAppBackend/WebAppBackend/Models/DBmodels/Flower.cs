using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppBackend.Models.DBmodels
{
    public class Flower
    {
        public Flower( string flower_name, string flower_name_latin, string flower_info, int watering_interval)
        {
            Flower_name = flower_name;
            Flower_name_latin = flower_name_latin;
            Flower_info = flower_info;
            Watering_interval = watering_interval;
        }

        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Flower_name { get; set; }
        public string Flower_name_latin { get; set; }
        public string Flower_info { get; set; }
        public int Watering_interval { get; set; }
    }
}
