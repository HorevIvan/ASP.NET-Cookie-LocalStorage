<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cookie.aspx.cs" Inherits="ASPNET_Cookie_LocalStorage.Cookie" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="CookieForm" runat="server">
            <% if (!IsKnownUser) { %>
            <div>  
                Я тебя не знаю, представься:  
                <asp:TextBox runat="server" ID="NameTextBox" /><br />
                <asp:Button runat="server" ID="EnterButton" Text="Послать" OnClick="EnterButton_Click" />
            </div>
            <% } else { %>
                Привет <%=UserName %><br />
                знаю тебя до: <%=UserCookieExpiries.ToLongDateString() %>  <%=UserCookieExpiries.ToLongTimeString() %>
            <% } %>
        </form>
    </body>
</html>
