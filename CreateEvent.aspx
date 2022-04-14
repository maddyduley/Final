<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="Lab3.CreateEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label ID="Namelbl" runat="server" Text="Event Title:"></asp:Label>
    <asp:TextBox ID="Named" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Named" Text="Required"></asp:RequiredFieldValidator>
    <asp:Label ID="lblDate" runat="server" Text="Event Date:"></asp:Label>
    <asp:TextBox ID="Datetxt" runat="server" placeholder="XX/XX/XXXX XX:XX:XX XM"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Datetxt" Text="Required"></asp:RequiredFieldValidator>
        <asp:Label ID="Descritpion" runat="server" Text="Description"></asp:Label>
    <asp:TextBox ID="EventDesc" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EventDesc" Text="Required"></asp:RequiredFieldValidator>
    <asp:Label ID="Locationlbl" runat="server" Text="Location:"></asp:Label>
    <asp:TextBox ID="EvenLoc" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="EvenLoc" Text="Required"></asp:RequiredFieldValidator>
    <br />    
    <asp:Label ID="Emailsend" runat="server" Text=""></asp:Label>
    <br />

    <asp:Button ID="AddEvent" runat="server" Text="Add Event" OnClick="AddEvent_Click" />

    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
</asp:Content>
