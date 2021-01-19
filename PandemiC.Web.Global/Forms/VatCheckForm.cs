using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandemiC.Web.Global.Forms
{
    public class VatCheckForm
    {
        [Required]
        public string VAT { get; set; }
    }
}
