<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="MemberInbox.aspx.cs" Inherits="Lab3.MemberInbox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Button ID="SendtoStud" runat="server" Text="Email Students" OnClick="SendtoStud_Click" /><asp:Button ID="SendtoMem" runat="server" Text="Email Members" OnClick="SendtoMem_Click" />
    <br />
    <asp:Label ID="Emaillbl" runat="server" Text="Send Message to Student?"></asp:Label>
    <asp:Button ID="SendEmail" runat="server" Text="Send Message" OnClick="SendEmail_Click" />
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="Emaillbl2" runat="server" Text="Send Message to Member?"></asp:Label>
    <asp:Button ID="SendEmail2" runat="server" Text="Send Message" OnClick="SendEmail2_Click" />
    <br />

            &nbsp;&nbsp;&nbsp;
    <div style="margin-left: 40px">
        <asp:GridView ID="MemberMessages" runat="server" AutoGenerateColumns="false" DataValueField="MessageID" DataKeyNames="MessageID" >
            <Columns>
                <asp:BoundField HeaderText="Sender" DataField="FullName" SortExpression="FullName" />
                <asp:BoundField HeaderText="Title" DataField="Header" SortExpression="Header" />
                <asp:TemplateField>
                    <itemtemplate>
                        <asp:LinkButton ID="MemberMessage" Text="More Info" runat="server" CommandArgument='<%# Eval("MessageID") %>' Onclick="MemberMessage_Click"/>
                    </itemtemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div style="margin-left: 40px">
        <asp:GridView ID="StudentMasseges" runat="server" AutoGenerateColumns="false" DataValueField="MessageID" DataKeyNames="MessageID"  >
            <Columns>
                <asp:BoundField  DataField="Header"  />
                <asp:TemplateField>
                    <itemtemplate>
                        <asp:LinkButton ID="StudentMessage" Text="More Info" runat="server" CommandArgument='<%# Eval("MessageID") %>' Onclick="StudentMessage_Click"/>
                    </itemtemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
