<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Työntekijät.aspx.cs" Inherits="Työntekijät" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnSearch" runat="server" Text="Hae työntekijät" OnClick="btnSearch_Click" />
        <div id="presentation">
            <h2>Työntekijämme</h2>
            <asp:GridView ID="gvData" runat="server"></asp:GridView>
        </div>
        <div id="footer">
            <asp:Label ID="lblMessages" runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
