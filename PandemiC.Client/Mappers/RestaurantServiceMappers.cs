using PandemiC.Client.Models;
using GM = PandemiC.Global.Models;

namespace PandemiC.Client.Mappers
{
    internal static class RestaurantServiceMappers
    {
        internal static GM.Restaurant ToGlobal(this Restaurant e)
        {
            return new GM.Restaurant() { Id = e.Id, Name = e.Name, VAT = e.VAT, Address1 = e.Address1,Address2 = e.Address2,Zip = e.Zip,City = e.City,Country = e.Country,Email = e.Email,Closed = e.Closed};
        }

        internal static Restaurant ToClient(this GM.Restaurant e)
        {
            if (e is null) return null;
            else return new Restaurant() { Id = e.Id, Name = e.Name, VAT = e.VAT, Address1 = e.Address1, Address2 = e.Address2, Zip = e.Zip, City = e.City, Country = e.Country, Email = e.Email, Closed = e.Closed };
        }
    }
}
