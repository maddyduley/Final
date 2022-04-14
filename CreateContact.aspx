<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="CreateContact.aspx.cs" Inherits="Lab3.CreateContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Namelbl" runat="server" Text="Contact Name:"></asp:Label>
    <asp:TextBox ID="Named" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Named" Text="Required"></asp:RequiredFieldValidator>
    <asp:Label ID="Phonelbl" runat="server" Text="Phone Number:"></asp:Label>
    <asp:TextBox ID="ContactPhone" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ContactPhone" Text="Required"></asp:RequiredFieldValidator>
        <asp:Label ID="Emaillbl" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="ContactEmail" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ContactEmail" Text="Required"></asp:RequiredFieldValidator>
    <asp:DropDownList ID="CompanyList" runat="server" AutoPostBack="True" DataSourceID="CompList" DataTextField="CompanyName" DataValueField="CompanyID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="CompList" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select CompanyID, CompanyName from Company"></asp:SqlDataSource>
        


    <asp:Button ID="AddContact" runat="server" Text="Add Contact" OnClick="AddContact_Click" CausesValidation="false" />

    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
</asp:Content>
