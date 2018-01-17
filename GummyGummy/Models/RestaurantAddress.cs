using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GummyGummy.Models
{
    public class RestaurantAddress
    {

        public string Name { get; set; }
        [Required(ErrorMessage ="Please provide a street address")]
        public string Street { get; set; }
        [Required(ErrorMessage ="Please provide a city")]
        public string City { get; set; }
        [Required(ErrorMessage ="Please provide a State")]
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}