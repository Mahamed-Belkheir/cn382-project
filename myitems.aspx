<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeBehind="myitems.aspx.cs" Inherits="CN382_Project.myitems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container d-flex flex-column justify-content-center">
        <div class="d-flex p-4 w-100 justify-content-between align-items-center  bg-white shadow-sm" style="color: #424242">
            <h4>Your items</h4>
            <span>
                <a 
                    style="text-decoration: none; font-weight: 500; color: #61b1e2"
                    href="additem.aspx"
                    >
                    Add Item
                </a>
            </span>
        </div>
        <form runat="server" class="bg-white shadow-sm mt-5">
            <asp:Repeater ID="RepeaterList" runat="server">
                <HeaderTemplate>
                    <div class="row-12 d-flex align-items-center text-center justify-content-center p-4"
                        style="font-size:120%; font-weight: 600;"
                        >
                        <div class="col-2">
                           
                        </div>
                        <div class="col-2">
                            Name
                        </div>
                        <div class="col-2">
                            Price
                        </div>
                        <div class="col-2">
                            Location
                        </div>
                        <div class="col-4">
                            
                        </div>
                    </div>
                </HeaderTemplate> 
                
                <ItemTemplate>
                    <div class="row-12 d-flex text-black-50 text-center align-items-center justify-content-center border border-light p-4">
                        <div class="col-2">
                            <asp:Image runat="server" AlternateText="product image"
                                Width="100px"
                                ImageUrl='<%#DataBinder.Eval(Container.DataItem, "image")%>'
                            />
                        </div>
                        <div class="col-2">
                            <%#DataBinder.Eval(Container.DataItem, "name")%> 
                        </div>
                        <div class="col-2">
                            <%#DataBinder.Eval(Container.DataItem, "price") %> LYD
                        </div>
                        <div class="col-2">
                            <%#DataBinder.Eval(Container.DataItem, "location") %>
                        </div>
                        <div class="col-2">
                            <asp:HyperLink runat="server"
                                NavigateUrl='<%# "/edititem.aspx?item=" + DataBinder.Eval(Container.DataItem, "id")%>'
                                Text="Edit"
                                style="text-decoration: none; font-weight: 500"
                                CssClass="text-warning"
                                >
                            </asp:HyperLink>
                            </div>
                            <div class="col-2">
                            <asp:HyperLink runat="server"
                                NavigateUrl='<%# "/deleteitem.aspx?item=" + DataBinder.Eval(Container.DataItem, "id")%>'
                                Text="Delete"
                                style="text-decoration: none; font-weight: 500"
                                CssClass="text-danger"
                                >
                            </asp:HyperLink>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </form>
    </div>
</asp:Content>
