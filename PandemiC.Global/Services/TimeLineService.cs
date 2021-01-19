using DCODatabase.ToolBox.Database;
using PandemiC.Global.Mappers;
using PandemiC.Global.Models;
using PandemiC.Repo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemiC.Global.Services
{
    public class TimeLineService : ITimeLineService<TimeLine>
    {
        private readonly string where = "GTL";
        private readonly string Str_Get = "Select * From [PandUser].[V_TimeLine]";

        private readonly IConnection _connection;

        public TimeLineService(IConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<TimeLine> Get(int userId)
        {
            DBCommand command = new DBCommand(Str_Get + "WHERE [UserId] = @UserID;");
            command.AddParameter("UserId", userId);
            return _connection.ExecuteReader(command, dr => dr.ToTimeLine());
        }

        public TimeLine Get(int userId,int id)
        {

            DBCommand command = new DBCommand(Str_Get + " Where [Id] = @Id AND [UserId] = @UserID;");
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);
            return _connection.ExecuteReader(command, dr => dr.ToTimeLine()).SingleOrDefault();
        }
        public TimeLine Add(TimeLine tl)
        {
            if (tl is null) throw new NullReferenceException($"TimeLine Data empty ({where}) (ADD)");
            DBCommand command = new DBCommand("[PandUser].[DCOSP_AddTimeLine]", true);
            command.AddParameter("UserId", tl.UserId);
            command.AddParameter("RestaurantId", tl.RestaurantId);
            command.AddParameter("DinerDate", tl.DinerDate);
            command.AddParameter("NbrGuests", tl.NbrGuests);

            tl.Id = (int)_connection.ExecuteScalar(command);
            return tl;
        }
        public bool Upd(int id, TimeLine tl)
        {
            if (tl is null) throw new NullReferenceException($"TimeLine Data empty ({where}) (UPD)");
            DBCommand command = new DBCommand("[PandUser].[DCOSP_UpdTimeLine]", true);
            command.AddParameter("Id", id);
            command.AddParameter("UserId", tl.UserId);
            command.AddParameter("RestaurantId", tl.RestaurantId);
            command.AddParameter("DinerDate", tl.DinerDate);
            command.AddParameter("NbrGuests", tl.NbrGuests);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Del(int userId, int id)
        {
            DBCommand command = new DBCommand("[PandUser].[DCOSP_DelTimeLine]", true);
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);
            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
