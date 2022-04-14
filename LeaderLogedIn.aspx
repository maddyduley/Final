<%@ Page Title="" Language="C#" MasterPageFile="~/DukeGroups.Master" AutoEventWireup="true" CodeBehind="LeaderLogedIn.aspx.cs" Inherits="Lab3.LeaderLogedIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                              <br />
    <div class="center">
                          <asp:Button ID="Button1" runat="server" Text="Inbox" Onclick="Messages_Click" Height="48px" Width="133px"  />    </div>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Leader"></asp:Label>
    <br />
      <asp:Button ID="ScholarAdmin" runat="server" Text="Scholarship" OnClick="Scholar_Click" CssClass="topbuttons" />
    <asp:Button ID="JobAdmin" runat="server" Text="Job" OnClick="JobAdmin_Click" CssClass="topbuttons" />
    <asp:Button ID="InternAdmin" runat="server" Text="Internship" OnClick="InternAdmin_Click" CssClass="topbuttons"  />
    
    <div class="rightside">
    <asp:Button ID="EditInfo" runat="server" Text="Edit Info" OnClick="EditInfo_Click" CssClass="rightbuttons" Height="65px" Width="200px"/>
        <br />
        <br />
    <asp:Button ID="StudentInfo" runat="server" Text="Student Info" OnClick="StudentInfo_Click" CssClass="rightbuttons" Height="65px" Width="200px" />
    <br />
    <br />
            <asp:Button ID="Analytics" runat="server" Text="Analytics" OnClick="Analytics_Click"  CssClass="rightbuttons" Height="65px" Width="200px" />
        <br />
        <br />
    <asp:Button ID="Opportunitiesbtn" runat="server" Text="Opportunities" OnClick="Opportunitiesbtn_Click" CssClass="rightbuttons" Height="65px" Width="200px"/>
    <br />
    <br />
    <asp:Button ID="Calandars" runat="server" Text="Calendar" OnClick="Calandars_Click" CssClass="rightbuttons" Height="65px" Width="200px"/>
    </div>




                 
    <br />
          <asp:Button ID="EditMemberUser" runat="server" Text="Edit User" OnClick="EditMemberUser_Click" />
    <br />

            <asp:GridView ID="grdvMemberTable" runat="server" DataSourceID="sqlsrc" allowsorting="true" AutoGenerateColumns="false" DataKeyNames="MemberID" Width="1093px" GridLines="None">
            <Columns>
                                   <asp:TemplateField >
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
        <asp:Label ID="lblStudent" runat="server" Text="Students Mentoring"></asp:Label>
    <asp:GridView ID="StudentGrid" runat="server" GridLines="None" AutoGenerateColumns="false">
                <Columns>
            <asp:BoundField  DataField="Student_Name"  />
        </Columns>
    </asp:GridView>

</asp:Content>
