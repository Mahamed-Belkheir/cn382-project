using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CN382_Project.database
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

    }

    public class UserModel : BaseModel<User>
    {
        public override string tableName { get; set; }
        public override string[] attributes { get; set; }

        public UserModel() {
            tableName = "users";
            attributes = new string[]{"id", "username", "password", "phone"};
        }
        
        public override User[] Find(string[] select = null, Dictionary<string, string> query = null)
        {
            return base.Find((object[] row) =>
            {
                User user = new User();
                user.Id = (int)row[0];
                user.Username = (string)row[1];
                user.Password = (string)row[2];
                user.Phone = (string)row[3];
                return user;
            }, select, query);
        }
    }
}