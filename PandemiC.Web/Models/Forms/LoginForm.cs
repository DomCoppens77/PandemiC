using PandemiC.Web.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PandemiC.Web.Models.Forms
{
    public class LoginForm
    {
        [Required]
        [StringLength(320, MinimumLength = 1)]
        [RegExEMAIL]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegExPasswd]
        public string Passwd { get; set; }
    }
}
