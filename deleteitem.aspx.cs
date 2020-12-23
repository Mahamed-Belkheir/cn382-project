using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CN382_Project.controllers;
using CN382_Project.exceptions;


namespace CN382_Project
{
    public partial class deleteitem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var itemController = new ItemController();
            string itemId = Request.QueryString.Get("item");
            int x;
            
            int userId;
            UserController userController = new UserController(Request, Response);
            try
            {
                if (itemId == null || itemId == "" || !Int32.TryParse(itemId, out x))
                {
                    throw new NotFound("item");
                }
                userId = userController.checkSession();
                itemController.deleteById(itemId, userId);
            }
            catch (Exception err)
            {

                MessageBox.Attributes.Add("class", "alert alert-warning");
                MessageBox.Attributes.Add("role", "alert");
                MessageBox.InnerText = err.Message;                
                return;
            }
            MessageBox.Attributes.Add("class", "alert alert-success");
            MessageBox.Attributes.Add("role", "alert");
            MessageBox.InnerText = "Item deleted successfully"; 
        }
    }
}