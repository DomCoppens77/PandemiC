using DCODatabase.ToolBox.Database;
using PandemiC.Global.Mappers;
using PandemiC.Global.Models;
using PandemiC.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PandemiC.Global.Services
{
    public class UserService : IUserService<User>
    {
        private readonly string where = "GUser";
        private readonly string Str_Get = "Select * From [PandUser].[V_User]";
        private readonly IConnection _connection;

        public UserService(IConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<User> Get()
        {
            DBCommand command = new DBCommand(Str_Get + ";");
            return _connection.ExecuteReader(command, dr => dr.ToUser());
        }

        public User Get(int id)
        {
            DBCommand command = new DBCommand(Str_Get + " Where [Id] = @Id;");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
        }
        public User Add(User user)
        {
            if (user is null) throw new NullReferenceException($"User Data empty ({where}) (ADD)");
            if (user.Email.Length == 0 || user.Passwd.Length == 0) throw new DataException("Email &/or Password Data empty (" + where + ") ADD)");

            if (EmailIsUsed(user.Email,0)) throw new DataException("$Email Is already Used ({where}) ADD)");
            if (NatRegNbrIsUsed(user.NatRegNbr,0)) throw new DataException($"National Register Nbr Is already Used ({where}) ADD)");

            DBCommand command = new DBCommand("[PandUser].[DCOSP_AddUser]", true);
            command.AddParameter("Email", user.Email);
            command.AddParameter("NatRegNbr", user.NatRegNbr);
            command.AddParameter("Passwd", user.Passwd);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            user.Id = (int)_connection.ExecuteScalar(command);
            user.Passwd = "";

            return user;
        }

        public bool Upd(User user)
        {
            if (user is null) throw new NullReferenceException($"Upd User Data empty ({where}) (UPD)");

            if (EmailIsUsed(user.Email, user.Id)) throw new DataException($"Email Is already Used {user.Id} ({where}) UPD)");
            if (NatRegNbrIsUsed(user.NatRegNbr, user.Id)) throw new DataException($"National Register Nbr Is already Used {user.Id} ({where}) UPD)");

            DBCommand command = new DBCommand("[PandUser].[DCOSP_UpdUser]", true);
            command.AddParameter("Id", user.Id);
            command.AddParameter("Email", user.Email);
            command.AddParameter("NatRegNbr", user.NatRegNbr);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("UserStatus", user.UserStatus);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Del(int id)
        {
            DBCommand command = new DBCommand("[PandUser].[DCOSP_DelUser]", true);
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public User Login(string email, string passwd)
        {
            if (email.Length == 0 || passwd.Length == 0) throw new DataException($"Email &/or Password Data empty ({where}) (LOGIN))");

            DBCommand command = new DBCommand("[PandUser].[DCOSP_CheckUser]", true);
            command.AddParameter("Email", email);
            command.AddParameter("Passwd", passwd);
            return _connection.ExecuteReader(command, r => r.ToUser()).SingleOrDefault();
        }

        public bool NatRegNbrIsUsed(String natRegNbr, int userId)
        {
            if (natRegNbr.Length == 0) throw new DataException($"National Register Nbr Data empty ({where}) (USED)");

            DBCommand command = new DBCommand("[PandUser].[DCOSP_CheckNatRegNbr]", true);
            command.AddParameter("natRegNbr", natRegNbr ?? (object)DBNull.Value);
            command.AddParameter("Id", userId);
            return (bool)_connection.ExecuteScalar(command);
        }

        public bool EmailIsUsed(string email, int userId)
        {
            if (email.Length == 0) throw new DataException($"EMAIL Data empty ({where}) (USED)");

            DBCommand command = new DBCommand("[PandUser].[DCOSP_CheckEmail]", true);
            command.AddParameter("Email", email ?? (object)DBNull.Value);
            command.AddParameter("Id", userId);
            return (bool)_connection.ExecuteScalar(command);
        }

        public bool UpdLight(User user)
        {
            if (user is null) throw new NullReferenceException($"Upd User Data empty ({where}) (UPDLGHT)");
            if (EmailIsUsed(user.Email, user.Id)) throw new DataException($"Email Is already Used {user.Id} ({where}) UPD)");

            DBCommand command = new DBCommand("[PandUser].[DCOSP_UpdUserUser]", true);
            command.AddParameter("Id", user.Id);
            command.AddParameter("Email", user.Email);
            command.AddParameter("NatRegNbr", user.NatRegNbr);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public User LoginNRN(string natRegNbr, string passwd)
        {
            if (natRegNbr.Length == 0 || passwd.Length == 0) throw new DataException($"NatRegNbr &/or Password Data empty ({where}) (LOGIN))");

            DBCommand command = new DBCommand("[PandUser].[DCO_CheckUserNatRegNbr]", true);
            command.AddParameter("NatRegNbr", natRegNbr);
            command.AddParameter("Passwd", passwd);
            return _connection.ExecuteReader(command, r => r.ToUser()).SingleOrDefault();
        }
    }
}
