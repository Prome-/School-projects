<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MoviesFromXML.aspx.cs" Inherits="MoviesFromXML" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>XML Movies</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- XMLDatasource määrittely -->
    <asp:XmlDataSource ID="srcMovies" runat="server" DataFile="~/App_Data/Movies.xml" XPath="//Movie"></asp:XmlDataSource>
    <!-- näytetään data gridview-kontrollissa -->
    <div>
        <h2 class="w3-container w3-indigo">Elokuvat XML-tiedostosta gridviewissä</h2>
        <asp:GridView ID="gvMovies" runat="server" DataSourceID="srcMovies" />
    </div>
    <!-- näytetään movie-data html:ssä repeater kontrollilla -->
    <div>
        <h2 class="w3-container w3-indigo">Elokuvat XML-tiedostosta html taulussa</h2>
        <asp:Repeater ID="Repeater1" DataSourceID="srcMovies" runat="server">
            <HeaderTemplate>
                <table border="1" style="width:50%">  
                    <tr>
                        <td>Nimi</td>
                        <td>Ohjaaja</td>
                        <td>Maa</td>
                    </tr>              
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Director") %></td>
                    <td><%# Eval("Country") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

