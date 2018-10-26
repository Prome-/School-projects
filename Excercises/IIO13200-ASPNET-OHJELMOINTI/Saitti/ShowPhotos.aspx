<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowPhotos.aspx.cs" Inherits="ShowPhotos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Photo Gallery</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="myLabel" runat="server" />
    <asp:Repeater ID="Repeater1" runat="server" >
        <ItemTemplate>
            <asp:Image ID="Image1" Width="150px" ImageUrl='<%# Container.DataItem  %>' runat="server" /> 
        </ItemTemplate>
    </asp:Repeater>
    </div>
    </form>
</body>
</html>
