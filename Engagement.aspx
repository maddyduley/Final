<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="Engagement.aspx.cs" Inherits="Lab3.Engagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:Button ID="Analytics" runat="server" Text="Analytics" OnClick="Analytics_Click" />

    <asp:Button ID="AccountApplication" runat="server" Text="Check Account Applications" OnClick="AccountApplication_Click" />
</asp:Content>
