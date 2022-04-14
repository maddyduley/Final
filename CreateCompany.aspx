<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="CreateCompany.aspx.cs" Inherits="Lab3.CreateCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
            
    <asp:Label ID="Label1" runat="server" Text="Choose Logo"></asp:Label>
    <asp:FileUpload Id="fileUploadText" runat="server"></asp:FileUpload>
    <asp:Label ID="txtDisplay" runat="server" Text=""></asp:Label>
    <br />        
    
    <asp:Label ID="Namelbl" runat="server" Text="Company Name:"></asp:Label>
    <asp:TextBox ID="Named" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Named" Text="Required"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="AddressLbl" runat="server" Text="Company Address:"></asp:Label>
    <asp:TextBox ID="Addressed" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Addressed" Text="Required"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Phonelbl" runat="server" Text="Company Phone"></asp:Label>
    <asp:TextBox ID="Phoned" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Phoned" Text="Required"></asp:RequiredFieldValidator>


    <br />
<br />


    <asp:Button ID="AddCompany" runat="server" Text="Add Company" OnClick="AddCompany_Click" CausesValidation="false" />

    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
</asp:Content>
