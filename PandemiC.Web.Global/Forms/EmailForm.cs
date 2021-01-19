using PandemiC.Forms.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PandemiC.Web.Global.Forms
{
    public class EmailForm
    {
        [Required]
        [StringLength(320, MinimumLength = 1)]
        public string Email { get; set; }
    }
}
