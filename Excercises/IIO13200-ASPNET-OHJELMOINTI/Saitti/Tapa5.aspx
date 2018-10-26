<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tapa5.aspx.cs" Inherits="Tapa5" %>
<!-- määritetään previouspagen osoite-->
<%@ PreviousPageType VirtualPath="~/Source.aspx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tapa 5, tiedon välitys</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Tapa 5, public property</h2>
            <p>
                Teksti luettu kutsuvan sivun ominaisuudesta:
                <%=PreviousPage.Messu %>
                
                <div style="font-style:italic" id="targetDiv" runat="server" />
            </p>
        </div>
    </form>
</body>
</html>
