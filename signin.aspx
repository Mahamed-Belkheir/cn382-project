<%@ Page Title="" Language="C#" MasterPageFile="~/signform.master" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="CN382_Project.signin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SignForm" runat="server">
    <form class="flex-column d-flex justify-content-center align-items-center mt-2" runat="server">
        <h4>Sign In</h4>
        <div class="form-group mt-1">
            <label for="usernameInput"> Username </label>
            <input class="form-control" id="usernameInput" name="usernameInput" runat="server">
        </div>
        <div class="form-group mt-1">
            <label for="passwordInput"> Password </label>
            <input type="password" class="form-control" id="passwordInput" name="passwordInput" runat="server">
        </div>
        <asp:Button id="signinBtn" OnClick="signinBtn_Click" class="btn shadow-sm text-dark mt-3" runat="server" Text="Sign In"></asp:Button>
        <div id="MessageBox" runat="server">

        </div>
        <div style="font-weight: 300; color: #808080;  margin-top: 10px;" 
            >No Account? <a style="font-weight: 500; color: #61b1e2" 
                class="text-decoration-none"
             href="signup.aspx">Sign Up</a> instead</div>
        <div style="font-weight: 300; color: #808080;  margin-top: 10px;" >
            <a style="font-weight: 500; color: #61b1e2" 
                class="text-decoration-none"
             href="index.aspx">back to store</a>
        </div>
    </form>
</asp:Content>
