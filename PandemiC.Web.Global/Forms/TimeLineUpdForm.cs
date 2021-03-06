﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PandemiC.Web.Global.Forms
{
    public class TimeLineUpdForm
    {
        [Required]
        public int Id { get; set; }
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
