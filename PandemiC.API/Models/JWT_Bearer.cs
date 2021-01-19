using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandemiC.API.Models
{
    public class JWT_Bearer
    {
        public int id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public DateTime ExpirationDateTime { get; set; }
        public string BearerJWT { get; set; }

    }
}
