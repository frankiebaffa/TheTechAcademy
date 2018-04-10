<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TAChallengeSimpleCalculator._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <h1>
        Simple Calculator
    </h1>
    <p>
        &nbsp;</p>
    <form id="form1" runat="server">
        <p>
            <span class="auto-style1">Value 1:</span>&nbsp;
            <asp:TextBox ID="oneValue" runat="server"></asp:TextBox>
    </p>
        <p>
            <span class="auto-style1">Value 2:</span>&nbsp;
            <asp:TextBox ID="twoValue" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
    </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="+" />
&nbsp;
            <asp:Button ID="subtractButton" runat="server" OnClick="subtractButton_Click" Text="-" />
&nbsp;
            <asp:Button ID="multiplyButton" runat="server" OnClick="multiplyButton_Click" Text="*" />
&nbsp;
            <asp:Button ID="divideButton" runat="server" OnClick="divideButton_Click" Text="/" />
    </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="resultLabel" runat="server" style="font-weight: 700; font-size: x-large; background-color: #66CCFF"></asp:Label>
    </p>
        <p>
            &nbsp;</p>
        <div>
        </div>
    </form>
</body>
</html>
