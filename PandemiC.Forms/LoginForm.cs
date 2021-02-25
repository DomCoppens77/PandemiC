using PandemiC.Forms.Attributes;
using System.ComponentModel.DataAnnotations;


namespace PandemiC.Forms
{
    public class LoginForm
    {
        [Required]
        [StringLength(320, MinimumLength = 1)]
        [RegExEMAIL]
        public string Email { get; set; }

        [Required]
        //[StringLength(50, MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[RegExPasswd]
        public string Passwd { get; set; }
    }
}
