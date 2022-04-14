<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="EmailStudents.aspx.cs" Inherits="Lab3.EmailStudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <br />

    <asp:Label runat="server" Text="Title:"></asp:Label>
    <asp:TextBox ID="Titlelbl" runat="server"></asp:TextBox>
      <br />
    <asp:Label runat="server" Text="Message"></asp:Label>
      <br />
    <asp:TextBox ID= "Messagelbl" runat="server" Height="214px" Width="1022px"></asp:TextBox>
      <br />
      <br />
    <asp:Button ID="Send" runat="server" Text="Send" onclick="Send_Click" />
    <asp:Label ID="Result" runat="server" Text=""></asp:Label>
</asp:Content>
