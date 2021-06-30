using Cars.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace Cars.Models
{
    public class Car
    {
        public int Id { get; set; }
        [DisplayName("Car Name")]
        public String CarTitle { get; set; }
        [DisplayName("Car Description")]
        [AllowHtml]
        public String CarContent { get; set; }
        [DisplayName("Car Image")]
        public string CarImage { get; set; }
        public string UserId { get; set; }

        public int CategoryId { get; set; }
        public virtual Category category { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}