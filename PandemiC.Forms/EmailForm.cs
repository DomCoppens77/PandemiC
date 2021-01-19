using PandemiC.Forms.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PandemiC.Forms
{
    public class EmailForm
    {
        [Required]
        [StringLength(320, MinimumLength = 1)]
        [RegExEMAIL]
        public string Email { get; set; }
    }
}
