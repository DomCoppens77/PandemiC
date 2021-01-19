using System;

namespace PandemiC.Client.Models
{
    public class TimeLine
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public DateTime DinerDate { get; set; }
        public int NbrGuests { get; set; }
    }
}

