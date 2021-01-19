    using PandemiC.Web.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PandemiC.Web.Models.Forms
{
    public class UserAddForm
    {
        [DisplayName("National Register Number")]
        [Required(ErrorMessage = "Required Field")]
        [StringLength(50, MinimumLength = 1)]
        [CheckNatRegNbrUnique("")]
        public string NatRegNbr { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Required Field")]
        [StringLength(320, MinimumLength = 1)]
        [DataType(DataType.EmailAddress)]
        //[RegExEMAIL]
        [CheckEmailUnique("")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Required Field")]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegExPasswd]
        public string Passwd { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Required Field")]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }
        
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Required Field")]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }
    }
}
