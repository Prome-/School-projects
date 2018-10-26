<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Oppilaat.aspx.cs" Inherits="Oppilaat" MasterPageFile="~/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>XML Movies</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Button ID="btnGetStudents" runat="server" Text="Hae oppilaat" OnClick="btnGetStudents_Click"/>
        <asp:GridView ID="gvOppilaat" runat="server"></asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

