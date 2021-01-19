using System.ComponentModel.DataAnnotations;

namespace PandemiC.Forms
{
    public class VatCheckForm
    {
        [Required]
        public string VAT { get; set; }
    }
}
