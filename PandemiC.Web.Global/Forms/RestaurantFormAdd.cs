using System.ComponentModel.DataAnnotations;

namespace PandemiC.Web.Global.Forms
{
    public class RestaurantFormAdd
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

        [StringLength(2, MinimumLength = 2)]
        public string Country { get; set; }

        [StringLength(320)]
        public string Email { get; set; }
        
        [Required]
        public bool Closed { get; set; }
    }
}
