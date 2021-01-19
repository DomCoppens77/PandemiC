using System.ComponentModel.DataAnnotations;


namespace PandemiC.Web.Global.Forms
{
    public class LoginForm
    {
        [Required]
        [StringLength(320, MinimumLength = 1)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }
    }
}
