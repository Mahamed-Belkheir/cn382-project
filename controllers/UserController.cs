using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CN382_Project.database;
using CN382_Project.exceptions;
using System.Runtime.Caching;
using System.Runtime;
using System.Security.Cryptography;
using System.Security;

namespace CN382_Project.controllers
{
    public class UserController
    {
        private UserModel userModel;
        private MemoryCache sessions;
        private HttpRequest request;
        private HttpResponse response;
        private string cookieId = "CN382SESSIONID"; 

        public UserController(HttpRequest req, HttpResponse res)
        {
            userModel = new UserModel();
            sessions = MemoryCache.Default;
            request = req;
            response = res;
        }

        public string sign_in(string username, string password)
        {
            User[] users = userModel.Find(null, new Dictionary<string, string>(){
                {"username", username}
            });
            if (users.Length == 0)
            {
                throw new NotFound("username");
            }
            User user = users[0];
            if (user.Password != password)
            {
                throw new NotPermitted("wrong password");
            }
            return addSession(user.Id);

        }

        public string sign_up(string username, string password, string phone)
        {
            User[] users = userModel.Find(null, new Dictionary<string, string>(){
                {"username", username}
            });
            if (users.Length > 0)
            {
                throw new NotPermitted("username already in use");
            }
            userModel.Add(new Dictionary<string, string>(){
                {"username", username},
                {"password", password},
                {"phone", phone}
            });
            users = userModel.Find(null, new Dictionary<string, string>(){
                {"username", username}
            });
            return addSession(users[0].Id);
        }


        private string addSession(int userId)
        {
            string key = keyGen();
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.SlidingExpiration = TimeSpan.FromHours(5);
            sessions.Add(key, userId, policy);
            HttpCookie cookie = new HttpCookie(cookieId);
            cookie.Value = key;
            response.AppendCookie(cookie);
            return key;

        }

        public int checkSession()
        {
            var cookie = request.Cookies[cookieId];
            if (cookie == null)
            {
                throw new NotFound("cookie");
            }

            string key = cookie.Value;
            if (sessions.Contains(key))
            {
                return (int)sessions.Get(key);
            }
            throw new NotFound("session");
        }

        public void removeSession()
        {
            var cookie = request.Cookies[cookieId];
            if (cookie == null)
            {
                return;
            }
            string key = cookie.Value;
            if (sessions.Contains(key))
            {
                sessions.Remove(key);
            }
        }


        private string keyGen()
        {
            Byte[] bytes = new Byte[32];
            Random rnd = new Random();
            rnd.NextBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}