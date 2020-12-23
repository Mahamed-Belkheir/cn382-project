using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CN382_Project.controllers;

namespace CN382_Project
{
    public partial class signout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserController userController = new UserController(Request, Response);
            userController.removeSession();
        }
    }
}