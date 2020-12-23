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
    public partial class additem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            UserController userController = new UserController(Request, Response);
            int userId;
            try
            {
                userId = userController.checkSession();
            }
            catch (Exception)
            {
                Response.Redirect("/index.aspx", true);
                return;
            }
            string name = nameInput.Value;
            string description = descriptionInput.Value;
            string price = priceInput.Value;
            string location = locationInput.Value;
            string image = imageInput.Value;
            try
            {
                validateItemAdd(name, description, price, location, image);
                ItemController itemController = new ItemController();
                itemController.addItem(name, location, description, price, image, userId);
            }
            catch (Exception err)
            {
                MessageBox.InnerText = err.Message;
                MessageBox.Attributes.Add("class", "alert alert-warning mt-3");
                MessageBox.Attributes.Add("role", "alert");
                return;
            }
            MessageBox.InnerText = "Item added successfully";
            MessageBox.Attributes.Add("class", "alert alert-success mt-3");
            MessageBox.Attributes.Add("role", "alert");
            nameInput.Value = "";
            descriptionInput.Value ="";
            priceInput.Value ="" ;
            locationInput.Value ="";
            imageInput.Value = "";
            
        }



        private void validateItemAdd(string name, string description, string price, string location, string image)
        {
            if ( name == null || name == "" ) {
                throw new NotPermitted("name is missing");
            }
            if ( description == null || description == "" ) {
                throw new NotPermitted("description is missing");
            }
            if ( price == null || price == "" ) {
                throw new NotPermitted("price is missing");
            }
            float x;
            if (!float.TryParse(price, out x))
            {
                throw new NotPermitted("price is not a valid number");
            }
            if ( location == null || location == "" ) {
                throw new NotPermitted("location is missing");
            }
            if ( image == null || image == "" ) {
                throw new NotPermitted("image is missing");
            }
           
        }
    }
}