<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tapa1.aspx.cs" Inherits="Tapa1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tapa 1: Query string</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Kohde 1: Query String -tapa</h1>
            <p>Sivulle lähetettiin parametrina viesti:
                <%=Request.QueryString["Data"] %>
                <br />
            </p>
    </div>
    </form>
</body>
</html>
