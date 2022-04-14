<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="JobMiddle.aspx.cs" Inherits="Lab3.JobMiddle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Button ID="EditJob" runat="server" Text="Edit Job" OnClick="EditJob_Click" />   
    <asp:Button ID="AssignJob" runat="server" Text="Assign Job" OnClick="AssignJob_Click" />
       


</asp:Content>
