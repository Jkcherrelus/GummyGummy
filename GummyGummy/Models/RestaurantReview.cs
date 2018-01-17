using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GummyGummy.Models
{
    public class RestaurantReview
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Rating { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateRated { get; set; } = DateTime.Now;
        public string UserID { get; set;}
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}