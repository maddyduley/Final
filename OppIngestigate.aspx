<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="OppIngestigate.aspx.cs" Inherits="Lab3.OppIngestigate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblDDescrip" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="Apply" runat="server" Text="Signup" OnClick="Apply_Click" />
    <asp:Button ID="goBack" runat="server" Text="Back" OnClick="goBack_Click" />
</asp:Content>
