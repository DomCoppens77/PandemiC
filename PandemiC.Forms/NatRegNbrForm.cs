using System.ComponentModel.DataAnnotations;

namespace PandemiC.Forms
{
    public class NatRegNbrForm
    {
            
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string NatRegNbr { get; set; }
    }
}
