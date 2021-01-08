using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CN382_Project.database;
using CN382_Project.exceptions;
using System.Data;

namespace CN382_Project.controllers
{
    public class ItemController
    {
        ItemModel items;
        FavoriteModel favorites;

        public ItemController()
        {
            items = new ItemModel();
            favorites = new FavoriteModel();
        }

        public Item[] fetchAlItems() {
            return items.Find();
        }

        public Item[] fetchUserItems(int userId)
        {
            return items.Find(null, new Dictionary<string, string>(){
                {"user_id", userId.ToString()}
            });
        }

        public Item[] fetchUserFavorites(int userId)
        {
            return favorites.GetFavorites(userId);
        }

        public Item fetchById(string Id)
        {
            var results = items.Find(null, new Dictionary<string, string>(){
                {"id", Id}
            });
            if (results.Length == 0)
            {
                throw new NotFound("item");
            }
            return results[0];
        }

        public void addItem(string name, string location, string description, string price, string image, int userId)
        {
            items.Add(new Dictionary<string, string>(){
                {"name", name},
                {"location", location},
                {"description", description},
                {"price", price.ToString()},
                {"image_url", image},
                {"user_id", userId.ToString()},
            });
        }

        public void deleteById(string Id, int userId)
        {
            var results = items.Find(null, new Dictionary<string, string>(){
                {"id", Id},
                {"user_id", userId.ToString()}
            });
            if (results.Length == 0)
            {
                throw new NotFound("item");
            }
            items.Delete(new Dictionary<string, string>() { 
                {"id", Id}
            });
        }

        public void editItem(int Id, int userId, Dictionary<string, string> data)
        {
            var results = items.Find(null, new Dictionary<string, string>(){
                {"id", Id.ToString()},
                {"user_id", userId.ToString()}
            });
            if (results.Length == 0)
            {
                throw new NotFound("item");
            }
            items.Patch(data, new Dictionary<string, string>() { 
                {"id", Id.ToString()}
            });
        }

        public void addFavorite(int userId, int itemId)
        {
            var results = items.Find(null, new Dictionary<string, string>(){
                {"user_id", userId.ToString()}
            });
            if (results.Length == 0)
            {
                throw new NotFound("item");
            }
            if (favorites.IsFavorited(userId, itemId))
            {
                throw new NotPermitted("already favorited");
            }
            favorites.Add(new Dictionary<string, string>(){
                {"user_id", userId.ToString()},
                {"item_id", itemId.ToString()}
            });
        }

        public void removeFavorite(int userId, int itemId)
        {
            if (!favorites.IsFavorited(userId, itemId))
            {
                throw new NotPermitted("not favorited");
            }
            favorites.DeleteFavorite(userId, itemId);
        }

        public Boolean isFavorited(int userId, int itemId)
        {
            return favorites.IsFavorited(userId, itemId);
        }
    }
}