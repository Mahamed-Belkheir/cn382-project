using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace CN382_Project.database
{

    public class Favorite
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
    }

    public class FavoriteModel: BaseModel<Favorite>
    {

        public override string tableName { get; set; }
        public override string[] attributes { get; set; }

        public FavoriteModel() {
            tableName = "favorites";
            attributes = new string[]{ "user_id", "item_id" };
        }

        public override Favorite[] Find(string[] select = null, Dictionary<string, string> query = null)
        {
            return base.Find(Factory, select, query);
        }

        public static Favorite Factory(object[] rows)
        {
            Favorite fav = new Favorite();
            fav.UserId = (int)rows[0];
            fav.ItemId = (int)rows[1];
            return fav;
        }

        public Item[] GetFavorites(int userId) {
            string sqlQuery = @"SELECT i.id, i.user_id, i.name, i.price, i.description, i.location, i.image_url
            from items as i
            join favorites as f
            on i.id = f.item_id
            where f.user_id = @1;
            ";
            var cmd = new SqlCommand(sqlQuery, conn);
            cmd.Parameters.AddWithValue("@1", userId);
            conn.Open();
            var reader = cmd.ExecuteReader();
            List<Item> returningResult = new List<Item>();

            while (reader.Read())
            {
                object[] row = new object[reader.FieldCount];
                reader.GetValues(row);
                returningResult.Add(ItemModel.Factory(row));
            }
            conn.Close();
            return returningResult.ToArray();
        }

        public void AddFavorite(int userId, int itemId) {
            base.Add(new Dictionary<string, string>(){
                {"user_id", userId.ToString()},
                {"item_id", itemId.ToString()},
            });
        }

        public void DeleteFavorite(int userId, int itemId)
        {
            base.Delete(new Dictionary<string, string>(){
                {"user_id", userId.ToString()},
                {"item_id", itemId.ToString()},
            });
        }

        public bool IsFavorited (int userId, int itemId) {
            var result = Find(null, new Dictionary<string, string>(){
                {"user_id", userId.ToString()},
                {"item_id", itemId.ToString()},
            });
            if (result.Length == 0)
            {
                return false;
            }
            return true;
        }
    }
}