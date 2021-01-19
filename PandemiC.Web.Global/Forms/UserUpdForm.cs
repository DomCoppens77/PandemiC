using System.ComponentModel.DataAnnotations;

namespace PandemiC.Web.Global.Forms
{
    public class UserUpdForm
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string NatRegNbr { get; set; }

        [Required]
        [StringLength(320, MinimumLength = 1)]
        public string Email { get; set; }

        public int UserState { get; set; }
    }
}
