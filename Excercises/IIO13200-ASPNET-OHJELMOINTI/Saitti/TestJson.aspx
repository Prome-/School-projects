<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TestJson.aspx.cs" Inherits="TestJson" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="btnGet" Text="Hae JSON teksti" OnClick="btnGet_Click" runat="server" />
    <asp:Button ID="btnGetPerson" Text="Hae JSON ja muuta olioksi" runat="server" OnClick="btnGetPerson_Click" />
    <asp:Button ID="btnGetPolitician" Text="Hae JSON ja muuta poliitikko olioiksi" runat="server" OnClick="btnGetPolitician_Click" />
    <h2>Tulokset</h2>
    <asp:Literal ID="ltResult" Text="..." runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

