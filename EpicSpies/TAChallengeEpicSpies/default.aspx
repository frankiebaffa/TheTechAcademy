<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TAChallengeEpicSpies._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" Height="190px" ImageUrl="epic-spies-logo.jpg" />
            <br />
            <br />
            <h2>Spy New Assignment Form</h2>
            <br />
            Spy Code Name:&nbsp; <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
            <br />
            <br />
            New Assignment Name:&nbsp; <asp:TextBox ID="assignName" runat="server"></asp:TextBox>
            <br />
            <br />
            End Date of Previous Assignment<br />
            <asp:Calendar ID="prevCalendar" runat="server"></asp:Calendar>
            <br />
            <br />
            Start Date of New Assignment<br />
            <asp:Calendar ID="startCalendar" runat="server"></asp:Calendar>
&nbsp;<br />
            <br />
            End Date of New Assignment<br />
            <asp:Calendar ID="endCalendar" runat="server"></asp:Calendar>
            <br />
            <asp:Button ID="assignButton" runat="server" OnClick="assignButton_Click" Text="Assign Spy" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
