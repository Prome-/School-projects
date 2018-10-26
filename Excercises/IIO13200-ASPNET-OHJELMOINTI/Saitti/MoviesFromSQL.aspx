<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MoviesFromSQL.aspx.cs" Inherits="MoviesFromSQL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Elokuvat SQL-kannasta</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Datasource SQLServeriltä -->
    <asp:SqlDataSource ID="srcMovies" runat="server" ConnectionString="<%$ ConnectionStrings:Muuvit %>" SelectCommand="SELECT [title], [director], [year], [url] FROM [Movies]" />
    <!-- gridview esittää haetun tiedon -->
     <div>
        <h2 class="w3-container w3-indigo">Elokuvat SQL-kannasta gridviewissä</h2>
        <asp:GridView ID="gvMovies" runat="server" DataSourceID="srcMovies" />
    </div>

    <!-- data HTML:ssä -->
    <!-- näytetään movie-data html:ssä repeater kontrollilla -->
    <div>
        <h2 class="w3-container w3-indigo">Elokuvat HTML:ssä reapeaterilla</h2>
        <asp:Repeater ID="Repeater1" DataSourceID="srcMovies" runat="server">            
            <ItemTemplate>
                <p><%# Eval("title") %> by <%# Eval("director") %>, <%# Eval("year") %></p>
                <img src='<%# Eval("url") %>' alt="kuva puuttuu" runat="server" />
            </ItemTemplate>
        </asp:Repeater>        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

