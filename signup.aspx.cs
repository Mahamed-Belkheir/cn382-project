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
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        

        protected void signupBtn_Click(object sender, EventArgs e)
        {
            string username = usernameInput.Value;
            string password = passwordInput.Value;
            string phone = phoneInput.Value;

            UserController userController = new UserController(Request, Response);

            try
            {
                ValidateSignup(username, password, phone);
                userController.sign_up(username, password, phone);
            }
            catch (NotPermitted err)
            {
                MessageBox.InnerText = err.Message;
                MessageBox.Attributes.Add("class", "alert alert-warning mt-3");
                MessageBox.Attributes.Add("role", "alert");
                return;
            }
            catch (Exception)
            {
                MessageBox.InnerText = "internal server error";
                MessageBox.Attributes.Add("class", "alert alert-danger mt-3");
                MessageBox.Attributes.Add("role", "alert");
                return;
            }

            MessageBox.InnerText = "signed up successfully!";
            MessageBox.Attributes.Add("class", "alert alert-success mt-3");
            MessageBox.Attributes.Add("role", "alert");
            
        }


        private void ValidateSignup(string username, string password, string phone)
        {
            if (username == "")
            {
                throw new NotPermitted("username can not be empty");
            }
            if (username.Length < 3)
            {
                throw new NotPermitted("username can not be less than 3 characters");
            }
            if (password == "")
            {
                throw new NotPermitted("password can not be empty");
            }
            if (password.Length < 5)
            {
                throw new NotPermitted("password can not be less than 5 characters");
            }
            if (phone == "")
            {
                throw new NotPermitted("phone can not be empty");
            }
            if (phone.Length != 10)
            {
                throw new NotPermitted("phone must be 10 numbers long, in 09* format");
            }
        }
    }


}