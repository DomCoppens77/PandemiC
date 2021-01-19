using PandemiC.Web.Client.Models;
using GResto = PandemiC.Web.Global.Models.Restaurant;

namespace PandemiC.Web.Client.Mappers
{
    static class RestaurantServiceMappers
    {
        internal static GResto ToGlobal(this Restaurant e)
        {
            return new GResto() { Id = e.Id, Name = e.Name, VAT = e.VAT, Address1 = e.Address1, Address2 = e.Address2, Zip = e.Zip, City = e.City, Country = e.Country, Email = e.Email, Closed = e.Closed };
        }

        internal static Restaurant ToClient(this GResto e)
        {
            if (e is null) return null;
            else return new Restaurant() { Id = e.Id, Name = e.Name, VAT = e.VAT, Address1 = e.Address1, Address2 = e.Address2, Zip = e.Zip, City = e.City, Country = e.Country, Email = e.Email, Closed = e.Closed };
        }
    }
}
