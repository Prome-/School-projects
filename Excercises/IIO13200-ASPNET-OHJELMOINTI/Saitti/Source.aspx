<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Source.aspx.cs" Inherits="Source" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tiedonvälitys demo</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Source -sivu</h1>
            
            <table>
                <tr>
                    <td>Lähetettävä viesti: </td>
                    <td><asp:TextBox ID="txtMessage" runat="server"/></td>                   
                </tr>
                <!-- Autopostback falsella event ei laukea välittömästi, koska kutsua ei lähetetä heti palvelimelle. Siihen tarvitaan silloin erillinen kontrolli. 
                    Tämä on requestien määrän pienentämistä varten.  Truella se reagoi heti käyttäjän klikkailuihin ja tuottaa suuremman määrän requesteja-->
                <asp:DropDownList ID="ddlMessages" runat="server" OnSelectedIndexChanged="ddlMessages_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <tr>
                    <!--Tapa 1, query string-->
                    <td><asp:Button ID="btnQueryString" runat="server" Text="Käytä queryString" OnClick="btnQueryString_Click"/></td>
                </tr>
                <tr>
                     <!-- Tapa 2: http post -->
                    <td><asp:Button ID="btnHttpPost" runat="server" Text="Käytä HttpPost" OnClick="btnHttpPost_Click" PostBackUrl="~/Tapa2.aspx" /></td>
                </tr>
                <tr>
                    <!-- Tapa 3: Session muuttuja -->
                    <td><asp:Button ID="btnSession" runat="server" Text="Käytä Session" OnClick="btnSession_Click" /></td>
                </tr>
                <tr>
                    <!-- Tapa 4: Cookie -->
                    <td><asp:Button ID="btnCookie" runat="server" Text="Käytä Cookieta" OnClick="btnCookie_Click" /></td>
                </tr>
                <tr>
                    <!-- Tapa 5: Property -->
                    <td><asp:Button ID="btnProperty" runat="server" Text="Käytä ominaisuutta (public property)" onclick="btnProperty_Click" /></td>
                </tr>
            </table>   
           

             <!--Tähän myöhemmin lista josta voi valita sopivan valmiin lauseen-->            
        </div>
    </form>
</body>
</html>
