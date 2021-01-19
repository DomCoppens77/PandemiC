using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PandemiC.Web.Models.Forms.TimeLine
{
    public class TimeLineUpdForm
    {
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Restaurant")]
        public int SelectedResaurant { get; set; }
        public IEnumerable<SelectListItem> Restaurants { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Date)]
        // [Range(typeof(DateTime), "2020-6-1", "2050-1-1", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime DinerDate { get; set; }
        
        [DisplayName("Number of Guest(s)")]
        [Required(ErrorMessage = "Required Field")]
        [Range(1, 6)]
        public int NbrGuests { get; set; }
    }
}
