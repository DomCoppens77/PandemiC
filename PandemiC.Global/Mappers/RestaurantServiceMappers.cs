using PandemiC.Global.Models;
using System.Data;

namespace PandemiC.Global.Mappers
{
    internal static class RestaurantServiceMappers
    {
        internal static Restaurant ToRestaurant(this IDataRecord dr)
        {
            return new Restaurant()
            {
                Id = (int)dr["Id"],
                Name = dr["Name"].ToString(),
                VAT = dr["VAT"].ToString(),
                Address1 = dr["Address1"].ToString(),
                Address2 = dr["Address2"].ToString(),
                Zip = dr["Zip"].ToString(),
                City = dr["City"].ToString(),
                Email = dr["Email"].ToString(),
                Country = dr["Country"].ToString(),
                Closed = (bool)dr["Closed"]
            };
        }
    }
}
