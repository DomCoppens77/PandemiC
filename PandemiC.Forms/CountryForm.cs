using System.ComponentModel.DataAnnotations;

namespace PandemiC.Forms
{
    public class CountryForm
    {
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string ISO { get; set; }

        [MaxLength(20)]
        [MinLength(1)]
        public string Ctry { get; set; }
        public bool IsEU { get; set; }
    }
}
