using Microsoft.AspNetCore.Mvc;
using PandemiC.Forms.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PandemiC.Forms
{
    public class UserUpdForm
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [CheckNatRegNbrUnique("Id")]
        public string NatRegNbr { get; set; }

        [Required]
        [StringLength(320, MinimumLength = 1)]
        [RegExEMAIL]
        [CheckEmailUnique("Id")]
        public string Email { get; set; }

        public int UserState { get; set; }
    }
}
