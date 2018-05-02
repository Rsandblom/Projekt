using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class DiningExperience
    {
        public int Id { get; set; }
        public string Restaurant { get; set; }
        public string Dish { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public List<SearchTag> SearchTagsList { get; set; }

      
    }
}
