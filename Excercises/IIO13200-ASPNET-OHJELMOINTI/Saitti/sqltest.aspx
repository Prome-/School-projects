<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="sqltest.aspx.cs" Inherits="sqltest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="pi" SelectCommand="SELECT * FROM user"  providerName="MySql.Data.MySqlClient"></asp:SqlDataSource>
    <asp:GridView ID="asd" runat="server"></asp:GridView>
    <asp:Label runat="server" ID="lblMessage" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

