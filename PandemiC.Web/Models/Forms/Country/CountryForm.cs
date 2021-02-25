using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PandemiC.Web.Models.Forms.Country
{
    public class CountryForm
    {

        [DisplayName("Country ISO")]
        [Required]
        public string ISO { get; set; }
        
        [DisplayName("Country Name")]
        public string Ctry { get; set; }

        [DisplayName("Is In EU ?")]
        public bool IsEU { get; set; }
    }
}
