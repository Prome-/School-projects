<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookShop.aspx.cs" Inherits="BookShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div class="w3-half">
            <asp:Button runat="server" ID="btnGetBooks" Text="Hae kirjat" OnClick="btnGetBooks_Click" />
            <asp:Button runat="server" ID="btnGetCustomers" Text="Hae asiakkaat" OnClick="btnGetCustomers_Click" />
            <h1 style="w3-container">Kirjakaupan kirjat</h1>
            <asp:GridView ID="gvBooks" runat="server" />
            <h1 style="w3-container">Kirjakaupan Asiakkaat</h1>
            <asp:GridView ID="gvCustomers" runat="server" />
       
            <h3>Asiakkaan tilaukset</h3>
            <asp:DropDownList ID="ddlOrders" runat="server" AutoPostBack="true" />
            <asp:GridView ID="gvOrders" runat="server" />
        </div>
        <div class="w3-half w3-content">
            <h2>Uuden luonti ja muokkaus</h2>
            <asp:DropDownList ID="ddlCustomers" runat="server" OnSelectedIndexChanged="ddlCustomers_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            <div>
                <asp:Label runat="server" Text="etunimi:" />
                <asp:TextBox runat="server" ID="tbFirstName" />
            </div>
            <div>
                 <asp:Label runat="server" Text="sukunimi:" />
                <asp:TextBox runat="server" ID="tbLastName" />
            </div>
            <asp:Button runat="server" Text="Luo uusi asiakas" ID="btnAddCustomer" OnClick="btnAddCustomer_Click" />
            <asp:Button runat="server" Text="Tallenna" ID="btnSaveModifiedCustomer" OnClick="btnSaveModifiedCustomer_Click" />
            <asp:Button runat="server" Text="Poista" ID="btnDeleteCustomer" OnClick="btnDeleteCustomer_Click" />
        </div>
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
    <asp:Label runat="server" ID="lblFooter" />
</asp:Content>

