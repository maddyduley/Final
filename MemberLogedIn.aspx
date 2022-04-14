<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="MemberLogedIn.aspx.cs" Inherits="Lab3.MemberLogedIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />

    
    <div class="rightside">
        <asp:Button ID="Search" runat="server" Text="Search for Student" OnClick="Search_Click" CssClass="rightbuttons" Height="65px" Width="200px"/>
        <br />
        <br />
    <asp:Button ID="SignupOpp" runat="server" Text="Sign up for Opportunities" OnClick="SignupOpp_Click" CssClass="rightbuttons" Height="65px" Width="200px" />
    <br />
    <br />
    <asp:Button ID="Analytics" runat="server" Text="Analytics" OnClick="Analytics_Click" CssClass="rightbuttons" Height="65px" Width="200px" />
        <br />
        <br />
    <asp:Button ID="Calandar" runat="server" Text="View Dates on Calendar" OnClick="Calandar_Click" CssClass="rightbuttons" Height="65px" Width="200px"/>
    <br />
    <br />
    <asp:Button ID="Messages" runat="server" Text="View Messages" OnClick="Messages_Click" CssClass="rightbuttons" Height="65px" Width="200px"/>
    </div>
                
    



    
    <br />
        <asp:Button ID="EditMemberUser" runat="server" Text="Edit User" OnClick="EditMemberUser_Click" />
    <br />
                <asp:GridView ID="grdvMemberTable" runat="server" DataSourceID="sqlsrc" allowsorting="true" AutoGenerateColumns="false" DataKeyNames="MemberID" Width="1093px" GridLines="None">
            <Columns>
                   <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="150px" Height="150px" ImageUrl='<%# "/Images/" + Eval("Image")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:BoundField  DataField="FirstName"  />
                <asp:BoundField  DataField="LastName"  />
                <asp:BoundField  DataField="Email"  />
                <asp:BoundField  DataField="PhoneNumber"  />
                <asp:BoundField  DataField="GradYear"  />
                <asp:BoundField  DataField="Title"  />
        </Columns>
            </asp:GridView>
        <asp:SqlDataSource ID="sqlsrc" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" 
            SelectCommand="Select * from Member WHERE UserName=@UserNamed">
            <SelectParameters>
                <asp:SessionParameter Name="UserNamed" SessionField="Username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>



    
    
    
</asp:Content>
