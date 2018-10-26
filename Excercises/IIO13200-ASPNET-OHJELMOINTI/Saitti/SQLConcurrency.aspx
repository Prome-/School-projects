<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SQLConcurrency.aspx.cs" Inherits="SQLConcurrency" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DemoxOyConnectionString %>" SelectCommand="SELECT [id], [name], [description] FROM [testi]" DeleteCommand="DELETE FROM [testi] WHERE [id] = @id" InsertCommand="INSERT INTO [testi] ([name], [description]) VALUES (@name, @description)" UpdateCommand="UPDATE [testi] SET [name] = @name, [description] = @description WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="description" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="description" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
    <h1 class="w3-container w3-indigo">Datalista</h1>
    <div class="w3-row">
        <div class="w3-container w3-half">
            <asp:GridView runat="server" ID="gvStuff" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="gvStuff_SelectedIndexChanged" DataKeyNames="id">
                <Columns>
                    <asp:ButtonField DataTextField="id" Text="Button" HeaderText="Id" CommandName="Select" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                </Columns>
            </asp:GridView>
        </div>
         <div class="w3-container w3-half">
             <h2 class="w3-container w3-blue">Muokattava tietue: <asp:Label ID="lblEditable" runat="server"/></h2>
             <asp:DetailsView runat="server" ID="dvStuff" AutoGenerateRows="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
                 <Fields>
                     <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                     <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                     <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                     <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                 </Fields>
             </asp:DetailsView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

