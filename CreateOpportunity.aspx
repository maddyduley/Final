<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="CreateOpportunity.aspx.cs" Inherits="Lab3.CreateOpportunity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <br />
            Opportunity Title:
            <asp:TextBox ID="TitleText" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TitleText" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Opportunity Description:
            <asp:TextBox ID="DescText" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DescText" Text="Required"></asp:RequiredFieldValidator>
            <br />
            Date:
            <asp:TextBox ID="Date" runat="server" placeholder="XX/XX/XXXX XX:XX:XX XM"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Date" Text="Required"></asp:RequiredFieldValidator>
            <br />
             Location:
            <asp:TextBox ID="Locationtext" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Locationtext" Text="Required"></asp:RequiredFieldValidator>
            <br />
        
    <br />    
    <asp:Label ID="Emailsend" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <asp:Button ID="CreateJobs" runat="server" Text="Create" OnClick="CreateJob_Click" />
    <br />
    <asp:Button ID="Goback" runat="server" Text="Home" OnClick="Goback_Click" CausesValidation="false" />
</asp:Content>
