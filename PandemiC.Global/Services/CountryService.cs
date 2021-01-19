using DCODatabase.ToolBox.Database;
using PandemiC.Global.Mappers;
using PandemiC.Global.Models;
using PandemiC.Repo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemiC.Global.Services
{
    public class CountryService : ICountryService<Country>
    {
        private readonly string where = "GCTRY";
        private readonly string Str_Get = "Select * From [PandUser].[V_Country]";

        private readonly IConnection _connection;

        public CountryService(IConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Country> Get()
        {
            DBCommand command = new DBCommand(Str_Get + ";");
            return _connection.ExecuteReader(command, dr => dr.ToCtry());
        }

        public Country Get(string ISO)
        {
            DBCommand command = new DBCommand(Str_Get + " Where [ISO] = @ISO;");
            command.AddParameter("ISO", ISO);
            return _connection.ExecuteReader(command, dr => dr.ToCtry()).SingleOrDefault();
        }
        public void Add(Country ctry)
        {
            if (ctry is null) throw new NullReferenceException($"Country Data empty ({where}) (ADD)");
            DBCommand command = new DBCommand("[PandUser].[DCOSP_AddCtry]", true);
            command.AddParameter("ISO", ctry.ISO);
            command.AddParameter("Ctry", ctry.Ctry);
            command.AddParameter("IsEu", ctry.IsEU);
            _connection.ExecuteScalar(command);
        }
        public bool Upd(Country ctry)
        {
            if (ctry is null) throw new NullReferenceException($"Country Data empty ({where}) (UPD)");
            DBCommand command = new DBCommand("[PandUser].[DCOSP_UpdCtry]", true);
            command.AddParameter("ISO", ctry.ISO);
            command.AddParameter("Ctry", ctry.Ctry);
            command.AddParameter("IsEu", ctry.IsEU);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Del(string ISO)
        {
            DBCommand command = new DBCommand("[PandUser].[DCOSP_DelCtry]", true);
            command.AddParameter("ISO", ISO);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public int IsUsed(string ISO)
        {
            DBCommand command = new DBCommand("[PandUser].[DCOSP_ChkCtry]", true);
            command.AddParameter("ISO", ISO);
            return (int)_connection.ExecuteScalar(command);
        }
    }
}
