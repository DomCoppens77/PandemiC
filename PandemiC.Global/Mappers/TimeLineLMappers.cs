using PandemiC.Global.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandemiC.Global.Mappers
{
    internal static class TimeLineLMappers
    {
        internal static TimeLine ToTimeLine(this IDataRecord dr)
        {
            return new TimeLine()
            {
                Id = (int)dr["Id"],
                UserId = (int)dr["UserId"],
                RestaurantId = (int)dr["RestaurantId"],
                RestaurantName = dr["RestaurantName"].ToString(),
                DinerDate = (DateTime)dr["DinerDate"],
                NbrGuests = (int)dr["NbrGuests"],
            };
        }
    }
}
