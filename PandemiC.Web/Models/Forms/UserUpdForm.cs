
using Microsoft.AspNetCore.Mvc;
using PandemiC.Web.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PandemiC.Web.Models.Forms
{
    public class UserUpdForm
    {
        [Required]
        [HiddenInput]
        public int Id { get; set; }

        [DisplayName("National Register Number")]
        [Required(ErrorMessage = "Required Field")]
        [StringLength(50, MinimumLength = 1)]
        [CheckNatRegNbrUnique("Id")]
        public string NatRegNbr { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Required Field")]
        [StringLength(320, MinimumLength = 1)]
        [DataType(DataType.EmailAddress)]
        [RegExEMAIL]
        [CheckEmailUnique("Id")]
        public string Email { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Required Field")]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Required Field")]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [DisplayName("User Status")]
        [Required(ErrorMessage = "Required Field")]
        [Range(0,2)]
        public int UserStatus { get; set; }
    }
}
