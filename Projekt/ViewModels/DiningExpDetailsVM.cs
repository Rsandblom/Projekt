using FlickrNet;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.ViewModels
{
    public class DiningExpDetailsVM
    {
        public DiningExperience DinExp { get; set; }
        public PhotoCollection Photos { get; set; }
    }
}
