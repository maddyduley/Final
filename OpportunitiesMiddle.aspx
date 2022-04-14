<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="OpportunitiesMiddle.aspx.cs" Inherits="Lab3.OpportunitiesMiddle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Button ID="Opportunities" runat="server" Text="Edit Opportunities" Onclick="Opportunities_Click" />
    <asp:Button ID="SignupOpp" runat="server" Text="Sign up for Opportunities" Onclick="SignupOpp_Click" />
</asp:Content>
