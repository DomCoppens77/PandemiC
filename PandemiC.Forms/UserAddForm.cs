using PandemiC.Forms.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PandemiC.Forms
{
    public class UserAddForm
    {
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [CheckNatRegNbrUnique("")]
        public string NatRegNbr { get; set; }

        [Required]
        [StringLength(320, MinimumLength = 1)]
        [DataType(DataType.EmailAddress)]
        [RegExEMAIL]
        [CheckEmailUnique("")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegExPasswd]
        public string Passwd { get; set; }

        [DisplayName("Confirmation")]
        [Required]
        [Compare(nameof(Passwd))]
        [DataType(DataType.Password)]
        public string Passwd2 { get; set; }
    }
}
