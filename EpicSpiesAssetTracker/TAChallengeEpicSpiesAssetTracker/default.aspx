<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TAChallengeEpicSpiesAssetTracker._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" ImageUrl="epic-spies-logo.jpg" />
            <br />
            <br />
            <h3>Asset Performance Tracker</h3>
            <br />
            Asset Name:&nbsp;
            <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Elections Rigged:&nbsp;
            <asp:TextBox ID="rigBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Acts of Subterfuge Performed:&nbsp;
            <asp:TextBox ID="subBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="Add Asset" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
