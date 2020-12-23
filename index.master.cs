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
    public partial class index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserController userController = new UserController(Request, Response);
            
            try
            {
                userController.checkSession();
                SignInButton.Visible = false;
                SignUpButton.Visible = false;
            }
            catch (Exception)
            {
                SignOutButton.Visible = false;
            }


        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {

        }
    }
}