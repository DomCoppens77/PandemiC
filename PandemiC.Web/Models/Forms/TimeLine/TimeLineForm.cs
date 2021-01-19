using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PandemiC.Web.Models.Forms.TimeLine
{
    public class TimeLineForm
    {
        [DisplayName("Restaurant")]
        [Required]
        public string RestaurantName { get; set; }

        [DisplayName("Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DinerDate { get; set; }

        [DisplayName("Number of Guest(s)")]
        [Required]
        [Range(1, 6)]
        public int NbrGuests { get; set; }
    }
}
