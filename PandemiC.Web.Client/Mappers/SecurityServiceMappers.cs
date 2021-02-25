using PandemiC.Web.Client.Models;
using GKeyInfo = PandemiC.Web.Global.Models.KeyInfo;

namespace PandemiC.Web.Client.Mappers
{
    static class SecurityServiceMappers
    {

        internal static KeyInfo ToClient(this GKeyInfo k)
        {
            if (k is null) return null;
            else return new KeyInfo() { PublicKey = k.PublicKey };
        }
    }
}
