using PandemiC.Global.Models;
using System.Data;

namespace PandemiC.Global.Mappers
{
    internal static class CountryServiceMappers
    {
        internal static Country ToCtry(this IDataRecord dr)
        {
            return new Country()
            {
                ISO = dr["ISO"].ToString(),
                Ctry = dr["Ctry"].ToString(),
                IsEU = (bool)dr["IsEU"]
            };

        }
    }
}
