<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThreadTest.aspx.cs" Inherits="WebApplication2.ThreadTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lab_state" runat="server"></asp:Label><br>
            <asp:Button ID="btn_startwork" runat="server" Text="运行一个长时间的任务" OnClick="btn_startwork_Click"></asp:Button>
        </div>
    </form>
</body>
</html>
