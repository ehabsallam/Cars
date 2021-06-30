using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars.Models
{
    public class CarsViewModel
    {
        public string CarTitle { get; set; }
        public IEnumerable<buyCar> Items { get; set; }
    }
}