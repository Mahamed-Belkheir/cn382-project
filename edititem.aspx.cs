using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CN382_Project.controllers;
using CN382_Project.database;

namespace CN382_Project
{
    public partial class edititem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack)
            {
                return;
            }
            
            Item itemToDisplay;

            try
            {
                itemToDisplay = fetchItem();
            }
            catch (Exception)
            {
                Response.Redirect("/notfound.aspx", true);
                return;
            }
           
            

            nameInput.Value = itemToDisplay.Name;
            descriptionInput.Value = itemToDisplay.Description;
            priceInput.Value = itemToDisplay.Price.ToString();
            locationInput.Value = itemToDisplay.Location;
            imageInput.Value = itemToDisplay.Image;

        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            Item itemToEdit;
            int userId;
            var data = new Dictionary<string, string>(){
                    {"name", nameInput.Value},
                    {"description", descriptionInput.Value},
                    {"price", priceInput.Value},
                    {"location", locationInput.Value},
                    {"image_url", imageInput.Value}
                };
            var userController = new UserController(Request, Response);
            try
            {
                userId = userController.checkSession();
                itemToEdit = fetchItem();
                var itemController = new ItemController();
                itemController.editItem(itemToEdit.Id, userId, data);
            }
            catch (Exception)
            {
               
                Response.Redirect("/notfound.aspx", true);
                return;
            
            }

            MessageBox.InnerText = "Item edited successfully";
            MessageBox.Attributes.Add("class", "alert alert-success");
            MessageBox.Attributes.Add("role", "alert");
            
        }


        private Item fetchItem()
        {
            Item itemToDisplay;
            var itemController = new ItemController();
            string itemId = Request.QueryString.Get("item");
            int x;
            if (itemId == null || itemId == "" || !Int32.TryParse(itemId, out x))
            {
                throw new Exception();
            }
            
            itemToDisplay = itemController.fetchById(itemId);
            
            return itemToDisplay;
        }
    }
}