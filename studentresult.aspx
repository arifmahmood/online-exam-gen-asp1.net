﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentresult.aspx.cs" Inherits="final_alpha.studentresult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="marks:"></asp:Label>
    
    </div>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="home" />
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="logout" />
    </p>
    </form>
</body>
</html>
