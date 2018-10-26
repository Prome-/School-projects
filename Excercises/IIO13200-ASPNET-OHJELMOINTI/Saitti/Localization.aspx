<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Localization.aspx.cs" Inherits="Localization" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Lokalisointitesti (staattinen h1-teksti)</h1>
    <!-- eka tapa -->
    <h2><asp:Literal runat="server" Text="<%$ Resources:Tervehdys %>" /></h2>
    <asp:Image runat="server" ImageUrl="<%$ Resources:Lippu %>" Width="200px" Height="100px" />
    <!-- toka tapa -->
    <asp:Button runat="server" ID="buttonA" Text="asd" meta:resourcekey="buttonA" OnClick="buttonA_Click" />
    <asp:Label ID="lblMessage" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

