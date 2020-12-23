<%@ Page Title="" Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CN382_Project.index1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex flex-column justify-content-center">
        <div class="d-flex justify-content-between align-items-center p-4 w-100  bg-white shadow-sm" style="color: #424242">
            <h4>Items on the Market</h4>
            <span>
                <a 
                    style="text-decoration: none; font-weight: 500; color: #61b1e2"
                    href="myitems.aspx"
                    runat="server"
                    id="YourItems"
                    >
                    Your Items
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
                        <div class="col-5">
                            Price
                        </div>
                        <div class="col-2">
                            Location
                        </div>
                        <div class="col-1">
                            
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
                        <div class="col-5">
                            <%#DataBinder.Eval(Container.DataItem, "price") %> LYD
                        </div>
                        <div class="col-2">
                            <%#DataBinder.Eval(Container.DataItem, "location") %>
                        </div>
                        <div class="col-1">
                            <asp:HyperLink runat="server"
                                NavigateUrl='<%# "/view.aspx?item=" + DataBinder.Eval(Container.DataItem, "id")%>'
                                Text="View"
                                 style="text-decoration: none; font-weight: 500; color: #61b1e2"
                                >

                            </asp:HyperLink>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </form>
    </div>
</asp:Content>
