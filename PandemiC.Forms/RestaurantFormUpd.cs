using PandemiC.Forms.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandemiC.Forms
{
    public class RestaurantFormUpd
    {
        [Required]
        [JsonIgnore]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [CheckVATUnique("id")]
        public string VAT { get; set; }

        [StringLength(255)]
        public string Address1 { get; set; }

        [StringLength(255)]
        public string Address2 { get; set; }

        [StringLength(15)]
        public string Zip { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(2, MinimumLength = 2)]
        public string Country { get; set; }

        [StringLength(320)]
        [RegExEMAILIfFilled]
        public string Email { get; set; }

        [Required]
        public bool Closed { get; set; }
    }
}
