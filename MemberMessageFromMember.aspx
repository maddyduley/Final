<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="MemberMessageFromMember.aspx.cs" Inherits="Lab3.MemberMessageFromMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
        <br />

        <asp:Label ID="Headerlbl" runat="server" Text=""></asp:Label>
        <br />
        <br />
    <asp:Label ID="Label1" runat="server" Text="From:"></asp:Label>
    <asp:Label ID="Senderlbl" runat="server" Text=""></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Date Sent"></asp:Label>
    <asp:Label ID="Datelbl" runat="server" Text=""></asp:Label>
        <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Message"></asp:Label>
    <br />
    <asp:Label ID="Infolbl" runat="server" Text=""></asp:Label>

        <br />

    <br />

    <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" />
</asp:Content>
