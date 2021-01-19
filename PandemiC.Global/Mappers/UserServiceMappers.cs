using PandemiC.Global.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandemiC.Global.Mappers
{
    internal static class UserServiceMappers
    {
        internal static User ToUser(this IDataRecord dr)
        {
            return new User()
            {
                Id = (int)dr["Id"],
                FirstName = (dr["FirstName"] == DBNull.Value) ? "" : dr["FirstName"].ToString(),
                LastName = (dr["LastName"] == DBNull.Value) ? "" : dr["LastName"].ToString(),
                Email = dr["Email"].ToString(),
                NatRegNbr = dr["NatRegNbr"].ToString(),
                UserStatus = (int)dr["UserStatus"],
                Passwd = "" ,
                Token = ""
            };
        }
    }
}
