using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PandemiC.Web.Models.Forms.Restaurant
{
    public class RestaurantAddForm
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string VAT { get; set; }

        [StringLength(255)]
        public string Address1 { get; set; }

        [StringLength(255)]
        public string Address2 { get; set; }

        [StringLength(15)]
        public string Zip { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Restaurant")]
        public string SelectedCountry { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

        [StringLength(320)]
        public string Email { get; set; }

        [Required]
        public bool Closed { get; set; }
    }
}
