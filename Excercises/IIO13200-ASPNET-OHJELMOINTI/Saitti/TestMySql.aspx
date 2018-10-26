<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TestMySql.aspx.cs" Inherits="TestMySql" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- HUOM MAHDOLLISTA ETTÄ TÄTÄ KÄYTETÄÄN KOKEESSA!-->
    <asp:SqlDataSource ID="srcMysli" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Oppilaat %>" 
        SelectCommand="SELECT * FROM Pelaaja" 
        UpdateCommand="UPDATE Pelaaja SET Nimi=@Nimi, Seura=@Seura, Pelipaikka=@Pelipaikka, Nro=@Nro, Maalit=@Maalit, Syotot=@Syotot WHERE (PelaajaID=@PelaajaID)" 
        DeleteCommand="DELETE FROM Pelaaja WHERE PelaajaID=@PelaajaID"
        ProviderName="MySql.Data.MySqlClient"></asp:SqlDataSource>
    <h2>Pelaajat liigassa</h2>
    <asp:GridView ID="gvPlayers" runat="server" DataSourceID="srcMysli" >
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

