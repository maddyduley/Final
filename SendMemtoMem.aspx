<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="SendMemtoMem.aspx.cs" Inherits="Lab3.SendMemtoMem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
      <asp:Label runat="server" Text="To:"></asp:Label>
    <asp:DropDownList ID="MemberList" runat="server" AutoPostBack="True" DataSourceID="Mentors" DataTextField="FullName" DataValueField="MemberID" />

      <asp:SqlDataSource ID="Mentors" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="Select MemberID, FirstName+' '+LastName AS FullName from Member Where Type='Leader' OR Type='Admin'"></asp:SqlDataSource>

    <asp:Label runat="server" Text="Title:"></asp:Label>
    <asp:TextBox ID="Titlelbl" runat="server"></asp:TextBox>
      <br />
    <asp:Label runat="server" Text="Message"></asp:Label>
      <br />
    <asp:TextBox ID= "Messagelbl" runat="server" Height="214px" Width="1022px" TextMode="MultiLine"></asp:TextBox>
      <br />
      <br />
    <asp:Button ID="Send" runat="server" Text="Send" onclick="Send_Click" />
    <asp:Label ID="Result" runat="server" Text=""></asp:Label>

</asp:Content>
