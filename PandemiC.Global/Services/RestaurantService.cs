using DCODatabase.ToolBox.Database;
using PandemiC.Global.Mappers;
using PandemiC.Global.Models;
using PandemiC.Repo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemiC.Global.Services
{
    public class RestaurantService : IRestaurantService<Restaurant>
    {
        private readonly string where = "GRESTO";
        private readonly string Str_Get = "Select * From [PandUser].[V_Restaurant]";

        private readonly IConnection _connection;

        public RestaurantService(IConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Restaurant> Get()
        {
            DBCommand command = new DBCommand(Str_Get + ";");
            return _connection.ExecuteReader(command, dr => dr.ToRestaurant());
        }

        public Restaurant Get(int id)
        {
            DBCommand command = new DBCommand(Str_Get + " Where [Id] = @Id;");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToRestaurant()).SingleOrDefault();
        }
        public Restaurant Add(Restaurant restaurant)
        {
            if (restaurant is null) throw new NullReferenceException($"Restaurant Data empty ({where}) (ADD)");
            DBCommand command = new DBCommand("[PandUser].[DCOSP_AddResto]", true);
            command.AddParameter("VAT", restaurant.VAT);
            command.AddParameter("Name", restaurant.Name);
            command.AddParameter("Address1", restaurant.Address2);
            command.AddParameter("Address2", restaurant.Address1);
            command.AddParameter("Zip", restaurant.Zip);
            command.AddParameter("City", restaurant.City);
            command.AddParameter("Country", restaurant.Country);
            command.AddParameter("Email", restaurant.Email);
            command.AddParameter("Closed", restaurant.Closed);
                
            restaurant.Id = (int)_connection.ExecuteScalar(command);
            return restaurant;
        }

        public bool Upd(Restaurant restaurant)
        {
            if (restaurant is null) throw new NullReferenceException($"Restaurant Data empty ({where}) (UPD)");
            DBCommand command = new DBCommand("[PandUser].[DCOSP_UpdResto]", true);
            command.AddParameter("Id", restaurant.Id);
            command.AddParameter("VAT", restaurant.VAT);
            command.AddParameter("Name", restaurant.Name);
            command.AddParameter("Address1", restaurant.Address2);
            command.AddParameter("Address2", restaurant.Address1);
            command.AddParameter("Zip", restaurant.Zip);
            command.AddParameter("City", restaurant.City);
            command.AddParameter("Country", restaurant.Country);
            command.AddParameter("Email", restaurant.Email);
            command.AddParameter("Closed", restaurant.Closed);
            return _connection.ExecuteNonQuery(command) == 1;
        }
        public bool Del(int id)
        {
            DBCommand command = new DBCommand("[PandUser].[DCOSP_DelResto]", true);
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public int IsUsed(int id)
        {
            DBCommand command = new DBCommand("[PandUser].[DCOSP_ChkResto]", true);
            command.AddParameter("Id", id);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool VATIsUsed(string vat, int id)
        {
            DBCommand command = new DBCommand("[PandUser].[DCOSP_CheckVAT]", true);
            command.AddParameter("VAT", vat);
            command.AddParameter("Id", id);
            return (bool)_connection.ExecuteScalar(command);
        }
    }
}
