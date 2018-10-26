<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RSSFeedit.aspx.cs" Inherits="RSSFeedit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:XmlDataSource ID="xdsFeedit" runat="server" XPath="rss/channel/item"></asp:XmlDataSource>
    <asp:Button ID="getFeeds" runat="server" Text="Hae Iltasanomat" OnClick="getFeeds_Click" />
    <asp:Button ID="getYleFeeds" runat="server" Text="Hae Yle" OnClick="getYleFeeds_Click" />
    <asp:Literal ID="ltMessages" runat="server" />
    <asp:Literal ID="ltFeed" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

