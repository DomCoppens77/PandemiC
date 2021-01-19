using PandemiC.Web.Client.Models;
using GTL = PandemiC.Web.Global.Models.TimeLine;

namespace PandemiC.Web.Client.Mappers
{
    static class TimeLineServiceMappers
    {
        internal static GTL ToGlobal(this TimeLine tl)
        {
            return new GTL() { Id = tl.Id, UserId = tl.UserId, RestaurantId = tl.RestaurantId, RestaurantName = tl.RestaurantName, DinerDate = tl.DinerDate, NbrGuests = tl.NbrGuests };
        }

        internal static TimeLine ToClient(this GTL tl)
        {
            if (tl is null) return null;
            else return new TimeLine() { Id = tl.Id, UserId = tl.UserId, RestaurantId = tl.RestaurantId, RestaurantName = tl.RestaurantName, DinerDate = tl.DinerDate, NbrGuests = tl.NbrGuests };
        }
    }
}
