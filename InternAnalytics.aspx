<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="InternAnalytics.aspx.cs" Inherits="Lab3.InternAnalytics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="InternLabel" runat="server" Text=""></asp:Label>
    <asp:Label ID="TotalViewlbl" runat="server" Text="Total Views"></asp:Label>
    <asp:Label ID="ScholarCount" runat="server" Text=""></asp:Label>
    <asp:Label ID="IndividualViews" runat="server" Text="Individual User Views"></asp:Label>
    <asp:Label ID="IndividualViewCount" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblLikedNumber" runat="server" Text="Number of Likes"></asp:Label>
    <asp:Label ID="LikeCounter" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="lblViewed" runat="server" Text="People Viewed"></asp:Label>
    <asp:GridView ID="DropViews" runat="server"></asp:GridView>
    <asp:Label ID="lblLiked" runat="server" Text="People Liked"></asp:Label>
    <asp:GridView ID="DropLiked" runat="server"></asp:GridView>
</asp:Content>
