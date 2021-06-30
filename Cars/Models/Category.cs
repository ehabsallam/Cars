using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cars.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display( Name ="Car Type")]
        public string CategoryName { get; set; }
        [Required]
        [Display(Name = "Car Description")]
        public string CategoryDescription { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}