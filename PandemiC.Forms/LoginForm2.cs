using PandemiC.Forms.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandemiC.Forms
{
    public class LoginForm2
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string NatRegNbr { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegExPasswd]
        public string Passwd { get; set; }
    }
}
