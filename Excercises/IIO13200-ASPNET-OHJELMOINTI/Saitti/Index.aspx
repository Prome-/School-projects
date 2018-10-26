<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index"  MasterPageFile="~/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Tralala</title>
    <!-- tällä tyyliasetuksella saa kuvan koon automaattisesti oikeaksi -->
    <style>
        img 
        {
            width:100%;
            height:auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <title>IIO13200 .NET Ohjelmointi</title>
    <link href="CSS/demo.css" rel="stylesheet" type="text/css" />

        <div>
            <h1>IIO13200. NET Ohjelmointi</h1>
            <h2>1.kontaktikerta</h2>
            <p>Uberwebbisaitti</p>
            <h3>Perus HTML kontrolleja</h3>
            <a href="Testi.html">Testi html-sivu</a>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Hello.aspx">LinkButton</asp:LinkButton>
            <p>
                Esimerkki ASP.NET DataKontrollista
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ShowPhotos.aspx">Show Photos</asp:HyperLink>
            </p>
            <p>
                Esimerkki kuinka koodissa rakennetaan HTML:ää
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ShowCustomers.aspx">Show WineCustomers</asp:HyperLink>
            </p>
            <h2>To.22.9.2016</h2>
            <h3>Tiedon välitys sivolta toiselle:</h3>
            <p>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Source.aspx">Tiedon välitys 6 tapaa</asp:HyperLink>
            </p>
            <h2>To.29.9</h2>
            <h3>Masterpage hommia</h3>
            <p>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/FordMustang.aspx">Fordmustang</asp:HyperLink>
            </p>
            <h2>To.29.9</h2>
            <h3>XML hommia</h3>
            <p>
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/MoviesFromXML.aspx">Elokuvat XML-tiedostosta</asp:HyperLink>
            </p>
            <h2>To.29.9</h2>
            <h3>SQL hommia</h3>
            <p>
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/MoviesFromSQL.aspx">Elokuvat SQL-kannasta</asp:HyperLink>
            </p>
            <h2>To.6.10.2016</h2>
            <h3>Lisää SQL hommia</h3>
            <p>
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Oppilaat.aspx">Oppilaat SQL-kannasta</asp:HyperLink>
            </p>
        </div>      
    </asp:Content>
