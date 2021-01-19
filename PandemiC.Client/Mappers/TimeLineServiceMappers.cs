using PandemiC.Client.Models;
using GM = PandemiC.Global.Models;

namespace PandemiC.Client.Mappers
{
    internal static class TimeLineServiceMappers
    {
        internal static GM.TimeLine ToGlobal(this TimeLine tl)
        {
            return new GM.TimeLine() { Id = tl.Id, UserId = tl.UserId, RestaurantId = tl.RestaurantId, RestaurantName = tl.RestaurantName, DinerDate = tl.DinerDate, NbrGuests = tl.NbrGuests };
        }

        internal static TimeLine ToClient(this GM.TimeLine tl)
        {
            if (tl is null) return null;
            else return new TimeLine() { Id = tl.Id, UserId = tl.UserId, RestaurantId = tl.RestaurantId, RestaurantName = tl.RestaurantName, DinerDate = tl.DinerDate, NbrGuests = tl.NbrGuests };
        }
    }
}
