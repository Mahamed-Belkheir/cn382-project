using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CN382_Project.controllers;
using CN382_Project.exceptions;
using CN382_Project.database;

namespace CN382_Project
{
    public partial class view : System.Web.UI.Page
    {
        protected Item itemToDisplay;

        protected void Page_Load(object sender, EventArgs e)
        {
            UserController userController = new UserController(Request, Response);
            var itemController = new ItemController();
            string itemId = Request.QueryString.Get("item");
            int x;
            if (itemId == null || itemId == "" || !Int32.TryParse(itemId, out x))
            {
                Response.Redirect("/notfound.aspx", true);
                return;
            }
            try
            {
                itemToDisplay = itemController.fetchById(itemId);
            }
            catch (NotFound)
            {
                Response.Redirect("/notfound.aspx", true);
                return;
            }

            try
            {
                int userId = userController.checkSession();
                if (itemController.isFavorited(userId, itemToDisplay.Id))
                {
                    FavBtn.HRef = "unfav.aspx?item=" + itemToDisplay.Id.ToString();
                    FavBtn.InnerText = "</3";
                    
                }
                else
                {
                    FavBtn.HRef = "fav.aspx?item=" + itemToDisplay.Id.ToString();
                    FavBtn.InnerText = "<3";
                }
            }
            catch (Exception)
            {
                FavBtn.HRef = "signin.aspx";
            }
        }
    }
}