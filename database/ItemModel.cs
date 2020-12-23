using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CN382_Project.database
{
    public class Item
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
    }

    public class ItemModel: BaseModel<Item>
    {
        public override string tableName { get; set; }
        public override string[] attributes { get; set; }

        public ItemModel() {
            tableName = "items";
            attributes = new string[]{"id", "user_id", "name", "price", "description", "location", "image_url" };
        }
        
        public override Item[] Find(string[] select = null, Dictionary<string, string> query = null)
        {
            return base.Find((object[] row) =>
            {
                Item item = new Item();
                item.Id = (int)row[0];
                item.UserId = (int)row[1];
                item.Name = (string)row[2];
                item.Price = (float)row[3];
                item.Description = (string)row[4];
                item.Location = (string)row[5];
                item.Image = (string)row[6];
                return item;
            }, select, query);
        }

    }
}