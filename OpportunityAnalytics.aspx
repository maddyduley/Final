<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="OpportunityAnalytics.aspx.cs" Inherits="Lab3.OpportunityAnalytics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:Label ID="JobLable" runat="server" Text=""></asp:Label>
    <asp:Label ID="TotalViewlbl" runat="server" Text="Total Views"></asp:Label>
    <asp:Label ID="ScholarCount" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="Signup" runat="server" Text="People Sign Up"></asp:Label>
    <asp:GridView ID="StudentGrid" runat="server"></asp:GridView>
    <asp:GridView ID="MemberGrid" runat="server"></asp:GridView>
    <asp:Button ID="CloseOpp" runat="server" Text="Close Opportunity" OnClick="CloseOpp_Click" />
</asp:Content>
