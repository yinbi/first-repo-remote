<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="/Scripts/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-1.8.2.TESTDEMO.js"></script>
    <script type="text/javascript">
        //!function a() {
        //    alert('iifksp');
        //}();
        $(document).ready(function () {
            //$.fun1();
            //$(this).fun2();
            //$('#btnTest').easySlider({});
            //alert($('#jlwerew a').attr('href'));
        });

        function TestFun() {
            //var defaults = {
            //    prevId: 'prevBtn',
            //    prevText: 'Previous',
            //    nextId: 'nextBtn',
            //    nextText: 'Next'
            //    //……
            //};
            $("#jlwerew").easySlider({ prevId: "", prevText: "" }).css({ "border-width": "1", "border-color": "red", "border-bottom-style": "dotted" });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input id="btnTest" type="button" value="测试" onclick="TestFun()" />
            <br />

            <div id="jlwerew" href="abc">
            </div>
        </div>
    </form>
</body>
</html>
