<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="ScholarshipInvestigate.aspx.cs" Inherits="Lab3.ScholarshipInvestigate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lblYear" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lblAmount" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="Like" runat="server" Text="Like" OnClick="Like_Click" />
    <asp:Button ID="Apply" runat="server" Text="Apply" OnClick="Apply_Click" />
    <asp:Button ID="goBack" runat="server" Text="Back" OnClick="goBack_Click" />

</asp:Content>
