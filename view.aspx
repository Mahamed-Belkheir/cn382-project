<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="CN382_Project.view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="col-12 w-100 h-100 mt-2 justify-content-center">
            <div class="row-12 w-100 h-100 d-flex flex-row bg-white shadow-sm justify-content-center">
                <img
                    src="<%=itemToDisplay.Image%>"
                    style="width: 30%"
                 />
                <div class="row-12 w-100 h-100 d-flex mt-4 p-5 flex-column align-content-center justify-items-center">
                    
                    <div class="mt-2 p-2"> 
                        <strong>Product Name:</strong>
                        <%= itemToDisplay.Name %></div>
                    <div class="mt-2 p-2">
                        <strong>Description:</strong>
                        <br />
                        <%= itemToDisplay.Description %>
                    </div>
                    <div class="mt-2 p-2">
                        <strong>Price:</strong>
                        <%= itemToDisplay.Price + " LYD" %>
                    </div>
                    <div class="mt-2 p-2">
                        <strong>Available in:</strong>
                        <%= itemToDisplay.Location  %>
                    </div>
                    <div class="mt-2 p-2">
                        <a style="font-weight: 500; color: #61b1e2" 
                        class="text-decoration-none"
                        href="index.aspx">back</a>
                    </div>
                </div>  
            </div>    
        </div>
    </div>
</asp:Content>
