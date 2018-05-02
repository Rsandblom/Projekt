using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class SearchTag
    {
        public int Id { get; set; }
        public string Tag { get; set; }

        public int DiningExperienceId { get; set; }
        public DiningExperience DiningExperience { get; set; }
    }
}
