using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PandemiC.Web.Models.Forms.TimeLine
{
    public class TimeLineAddForm
    {
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Restaurant")]
        public int SelectedResaurant { get; set; }
        public IEnumerable<SelectListItem> Restaurants { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Date)]
        public DateTime DinerDate { get; set; }

        [DisplayName("Number of Guest(s)")]
        [Required(ErrorMessage = "Required Field")]
        [Range(1, 6)]
        public int NbrGuests { get; set; }
    }
}
