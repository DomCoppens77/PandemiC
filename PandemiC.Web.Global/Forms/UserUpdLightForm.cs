using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandemiC.Web.Global.Forms
{
    public class UserUpdLightForm
    {
        [Required]
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
    }
}
