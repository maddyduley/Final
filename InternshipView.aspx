<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="InternshipView.aspx.cs" Inherits="Lab3.InternshipView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="TypeList" runat="server">
        <asp:ListItem Text="A-Z" Value=" Ints.InternshipTitle ASC"></asp:ListItem>
        <asp:ListItem Text="Z-A" Value=" Ints.InternshipTitle Desc"></asp:ListItem>
        <asp:ListItem Text="Newest" Value=" Ints.Upload ASC"></asp:ListItem>
        <asp:ListItem Text="Oldest" Value=" Ints.Upload Desc"></asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="refresh" runat="server" Text="Update" Onclick="RefreshResults" />
    <asp:GridView ID="IntView" runat="server" AutoGenerateColumns="false" DataValueField="InternshipID" DataKeyNames="InternshipID" GridLines="None"  >
         <Columns>
                          <asp:TemplateField HeaderText="">   
                  <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="150px" Height="150px" ImageUrl='<%# "/Company/" + Eval("Image")%>' />
                        </ItemTemplate>
             </asp:TemplateField>
                <asp:BoundField HeaderText="Title" DataField="InternshipTitle" SortExpression="InternshipTitle" />
                <asp:BoundField HeaderText="Description" DataField="InternshipDescription" SortExpression="InternshipDescription" />
                <asp:BoundField HeaderText="Start Date" DataField="DateStart" SortExpression="DateStart" />
             <asp:BoundField HeaderText="End Date" DataField="DateEnd" SortExpression="DateEnd" />
             <asp:TemplateField HeaderText="Additional Info">   
             <itemtemplate>
                 <asp:LinkButton ID="lnkSelect" Text="More Info" runat="server" CommandArgument='<%# Eval("InternshipID") %>' Onclick="NavigateClick"/>
             </itemtemplate> 
                
                 </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
