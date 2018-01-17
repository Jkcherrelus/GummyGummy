using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GummyGummy.Models
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Restuarant Name")]
        public string Name { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number is not valid")]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address is not valid")]
        public string Email { get; set; }
        [NotMapped]
        public decimal AvgRating
        { get
            {
                decimal total = 0;
                foreach (var item in Review)
                {
                    total += item.Rating;
                }
                return total/=Review.Count;
            }
        }
        public ICollection<RestaurantReview> Review { get; set; }
        public RestaurantAddress Address { get; set; }


    }
}