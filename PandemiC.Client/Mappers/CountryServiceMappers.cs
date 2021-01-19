using PandemiC.Client.Models;
using GM = PandemiC.Global.Models;

namespace PandemiC.Client.Mappers
{
    internal static class CountryServiceMappers
    {
        internal static GM.Country ToGlobal(this Country ctry)
        {
            return new GM.Country() { ISO = ctry.ISO, Ctry = ctry.Ctry, IsEU = ctry.IsEU };
        }

        internal static Country ToClient(this GM.Country ctry)
        {
            if (ctry is null) return null;
            else return new Country() { ISO = ctry.ISO, Ctry = ctry.Ctry, IsEU = ctry.IsEU };
        }
    }
}
