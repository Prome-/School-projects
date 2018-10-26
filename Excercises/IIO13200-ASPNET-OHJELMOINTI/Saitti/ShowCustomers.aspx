<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowCustomers.aspx.cs" Inherits="ShowCustomers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Salaiset ViiniAsiakkaamme SQl Serveriltä</title>
    <link href="CSS/demo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="Button1" runat="server" Text="Show customers" 
           onclick="Button1_Click" />
    <div runat="server" id="tulokset">...</div>

    </div>
    </form>
</body>
</html>
