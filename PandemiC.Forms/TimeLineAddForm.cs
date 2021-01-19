using System;
using System.ComponentModel.DataAnnotations;

namespace PandemiC.Forms
{
    public class TimeLineAddForm
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public DateTime DinerDate { get; set; }
        [Required]
        public int NbrGuests { get; set; }
    }

}
