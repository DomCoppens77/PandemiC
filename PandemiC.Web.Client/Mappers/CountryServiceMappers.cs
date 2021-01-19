using PandemiC.Web.Client.Models;
using GCtry = PandemiC.Web.Global.Models.Country;

namespace PandemiC.Web.Client.Mappers
{
    static class CountryServiceMappers
    {
        internal static GCtry ToGlobal(this Country ctry)
        {
            return new GCtry() { ISO = ctry.ISO, Ctry = ctry.Ctry, IsEU = ctry.IsEU };
        }

        internal static Country ToClient(this GCtry ctry)
        {
            if (ctry is null) return null;
            else return new Country() { ISO = ctry.ISO, Ctry = ctry.Ctry, IsEU = ctry.IsEU };
        }
    }
}
