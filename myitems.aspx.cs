using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CN382_Project.exceptions;
using CN382_Project.controllers;
using System.Data;

namespace CN382_Project
{
    public partial class myitems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userId;
            UserController userController = new UserController(Request, Response);
            try
            {
                userId = userController.checkSession();
            }
            catch (Exception)
            {
                Response.Redirect("/index.aspx", true);
                return;
            }
            ItemController itemController = new ItemController();
            var items = itemController.fetchUserItems(userId);
            DataTable table = new DataTable("items");
            table.Columns.Add("name");
            table.Columns.Add("price");
            table.Columns.Add("location");
            table.Columns.Add("image");
            table.Columns.Add("id");
            foreach (var item in items)
            {
                DataRow row = table.NewRow();
                row.SetField("name", item.Name);
                row.SetField("price", item.Price);
                row.SetField("location", item.Location);
                row.SetField("image", item.Image);
                row.SetField("id", item.Id);
                table.Rows.Add(row);
            }
            RepeaterList.DataSource = table;
            RepeaterList.DataBind();
        }
    }
}