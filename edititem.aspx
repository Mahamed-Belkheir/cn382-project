<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeBehind="edititem.aspx.cs" Inherits="CN382_Project.edititem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="col-12 d-flex flex-column align-items-center">
            <form class="flex-column d-flex justify-content-center p-5 align-items-center mt-2 bg-white shadow-sm" runat="server">
                <h4>Edit Item</h4>
                <div class="form-group mt-1">
                    <label for="nameInput">Name </label>
                    <input class="form-control" id="nameInput" name="nameInput" runat="server">
                </div>
                <div class="form-group mt-1">
                    <label for="descriptionInput">Description </label>
                    <input class="form-control" id="descriptionInput" name="descriptionInput" runat="server">
                </div>
                <div class="form-group mt-1">
                    <label for="priceInput">Price </label>
                    <input type="number" step="0.1" min="0" class="form-control" id="priceInput" name="priceInput" runat="server">
                </div>
                <div class="form-group mt-1">
                    <label for="locationInput">Location </label>
                    <input type="text" min="0" class="form-control" id="locationInput" name="locationInput" runat="server">
                </div>
                <div class="form-group mt-1">
                    <label for="imageInput">Image link </label>
                    <input type="text" min="0" class="form-control" id="imageInput" name="imageInput" runat="server">
                </div>

                <asp:Button ID="editBtn" OnClick="editBtn_Click" class="btn shadow-sm text-dark mt-3" runat="server" Text="Edit Item"></asp:Button>
                <div id="MessageBox" runat="server">
                </div>

                <div style="font-weight: 300; color: #808080; margin-top: 10px;">
                    <a style="font-weight: 500; color: #61b1e2"
                        class="text-decoration-none"
                        href="index.aspx">back to store</a>
                </div>
            </form>
        </div>

    </div>

</asp:Content>
