<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TAChallengePostageCalculator._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Postal Calculator<br />
            <br />
            Width:&nbsp;
            <asp:TextBox ID="widthBox" runat="server" AutoPostBack="True" OnTextChanged="handleChange"></asp:TextBox>
            <br />
            Height:&nbsp;
            <asp:TextBox ID="heightBox" runat="server" AutoPostBack="True" OnTextChanged="handleChange"></asp:TextBox>
            <br />
            Length:&nbsp;
            <asp:TextBox ID="lengthBox" runat="server" AutoPostBack="True" OnTextChanged="handleChange"></asp:TextBox>
            <br />
            <br />
            <asp:RadioButton ID="groundRadio" runat="server" AutoPostBack="True" GroupName="typeRadio" OnCheckedChanged="handleChange" Text="Ground" />
            <br />
            <asp:RadioButton ID="airRadio" runat="server" AutoPostBack="True" GroupName="typeRadio" OnCheckedChanged="handleChange" Text="Air" />
            <br />
            <asp:RadioButton ID="nextDayRadio" runat="server" AutoPostBack="True" GroupName="typeRadio" OnCheckedChanged="handleChange" Text="Next Day" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
