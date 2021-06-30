using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace Cars.Models
{
    public class buyCar
    {
        public int Id { get; set; }
        public string message { get; set; }
        public DateTime ApplyDate { get; set; }
        public int CarId { get; set; }
        public string UserId { get; set; }

        public virtual Car car { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}