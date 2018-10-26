<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Hello.aspx.cs" Inherits="Hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
    <div>
        <asp:TextBox ID="txtNimi" runat="server"></asp:TextBox>
        <asp:Button ID="btnNimi" Text="say Hello" runat="server" OnClick="btnHello_Click" />
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
