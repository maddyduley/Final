<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="JobVIew.aspx.cs" Inherits="Lab3.JobVIew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:DropDownList ID="TypeList" runat="server">
        <asp:ListItem Text="A-Z" Value=" Jo.JobTitle ASC"></asp:ListItem>
        <asp:ListItem Text="Z-A" Value=" Jo.JobTitle Desc"></asp:ListItem>
        <asp:ListItem Text="Newest" Value=" Jo.Upload ASC"></asp:ListItem>
        <asp:ListItem Text="Oldest" Value=" Jo.Upload Desc"></asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="refresh" runat="server" Text="Update" Onclick="RefreshResults" />
    <asp:GridView ID="JobView" runat="server" AutoGenerateColumns="false" DataValueField="JobID" DataKeyNames="JobID" GridLines="None" >
         <Columns>
             <asp:TemplateField HeaderText="">   
                  <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="150px" Height="150px" ImageUrl='<%# "/Company/" + Eval("Image")%>' />
                        </ItemTemplate>
             </asp:TemplateField>
                <asp:BoundField HeaderText="Title" DataField="JobTitle" SortExpression="JobTitle" />
                <asp:BoundField HeaderText="Company" DataField="CompanyName" SortExpression="CompanyName" />
                <asp:BoundField HeaderText="Start Date" DataField="DateStart" SortExpression="DateStart" />
             <asp:TemplateField HeaderText="Additional Info">   
             <itemtemplate>
                 <asp:LinkButton ID="lnkSelect" Text="More Info" runat="server" CommandArgument='<%# Eval("JobID") %>' Onclick="NavigateClick"/>
             </itemtemplate> 
                
                 </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
