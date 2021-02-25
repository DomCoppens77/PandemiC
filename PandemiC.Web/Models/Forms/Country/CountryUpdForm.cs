using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PandemiC.Web.Models.Forms.Country
{
    public class CountryUpdForm
    {
        [DisplayName("Country ISO")]
        public string ISO { get; set; }

        [DisplayName("Country Name")]
        public string Ctry { get; set; }

        [DisplayName("Is In EU ?")]
        public bool IsEU { get; set; }
    }
}
