<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="StudentInbox.aspx.cs" Inherits="Lab3.StudentInbox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label ID="Emaillbl" runat="server" Text="Send Message to Student?"></asp:Label>
    <asp:Button ID="SendEmail" runat="server" Text="Send Message" OnClick="SendEmail_Click" />
    <asp:Label ID="Emaillbl2" runat="server" Text="Send Message to Member?"></asp:Label>
    <asp:Button ID="SendEmail2" runat="server" Text="Send Message" OnClick="SendEmail2_Click" />


            <asp:GridView ID="MemberMessages" runat="server" AutoGenerateColumns="false" DataValueField="MessageID" DataKeyNames="MessageID"  >
         <Columns>
                <asp:BoundField HeaderText="Title" DataField="Header" SortExpression="Header" />
             <asp:TemplateField HeaderText="ViewMessageMem">   
             <itemtemplate>
                 <asp:LinkButton ID="MemberMessage" Text="More Info" runat="server" CommandArgument='<%# Eval("MessageID") %>' Onclick="MemberMessage_Click"/>
             </itemtemplate> 
                
                 </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <asp:GridView ID="StudentMasseges" runat="server" AutoGenerateColumns="false" DataValueField="MessageID" DataKeyNames="MessageID"  >
         <Columns>
                <asp:BoundField HeaderText="Title" DataField="Header" SortExpression="Header" />
             <asp:TemplateField HeaderText="ViewMessageStu">   
             <itemtemplate>
                 <asp:LinkButton ID="StudentMessage" Text="More Info" runat="server" CommandArgument='<%# Eval("MessageID") %>' Onclick="StudentMessage_Click"/>
             </itemtemplate> 
                
                 </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
