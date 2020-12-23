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
    public partial class signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void signinBtn_Click(object sender, EventArgs e)
        {
            string username = usernameInput.Value;
            string password = passwordInput.Value;

            UserController userController = new UserController(Request, Response);

            try
            {
                ValidateSignin(username, password);
                userController.sign_in(username, password);
            }

            catch (Exception err)
            {

                if (err is NotPermitted || err is NotFound) {
                    MessageBox.InnerText = err.Message;
                    MessageBox.Attributes.Add("class", "alert alert-warning mt-3");
                    MessageBox.Attributes.Add("role", "alert");
                } else {
                    MessageBox.InnerText = "internal server error";
                    MessageBox.Attributes.Add("class", "alert alert-danger mt-3");
                    MessageBox.Attributes.Add("role", "alert");
                }

                return;
            }

            MessageBox.InnerText = "signed in successfully!";
            MessageBox.Attributes.Add("class", "alert alert-success mt-3");
            MessageBox.Attributes.Add("role", "alert");
            
        }


        private void ValidateSignin(string username, string password)
        {
            if (username == "")
            {
                throw new NotPermitted("username can not be empty");
            }
           
            if (password == "")
            {
                throw new NotPermitted("password can not be empty");
            }
            
        }
    }
    
}