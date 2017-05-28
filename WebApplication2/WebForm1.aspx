<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="/Scripts/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="/Scripts/xmljson.js"></script>
    <%--<script type="text/javascript" src="/Scripts/jquery-1.8.2.TESTDEMO.js"></script>--%>
    <script type="text/javascript">
        //!function a() {
        //    alert('iifksp');
        //}();
        //$(document).ready(function () { });

        $(document).ready(function () {
            //$.fun1();
            //$(this).fun2();
            //$('#btnTest').easySlider({});
            //alert($('#jlwerew a').attr('href'));
            TestXmlToJson();
        });

        function TestFun() {
            //var defaults = {
            //    prevId: 'prevBtn',
            //    prevText: 'Previous',
            //    nextId: 'nextBtn',
            //    nextText: 'Next'
            //    //……
            //};
           // $("#jlwerew").easySlider({ prevId: "", prevText: "" }).css({ "border-width": "1", "border-color": "red", "border-bottom-style": "dotted" });
        }

        //function xmltojson(xmlObj, nodename, isarray) {
        //    var obj = $(xmlObj);
        //    var itemobj = {};
        //    var nodenames = "";
        //    var getAllAttrs = function (node) {//递归解析xml 转换成json对象
        //        var _itemobj = {};
        //        var notNull = false;
        //        var nodechilds = node.childNodes;
        //        var childlenght = nodechilds.length;
        //        var _attrs = node.attributes;
        //        var firstnodeName = "#text";
        //        try {
        //            firstnodeName = nodechilds[0].nodeName;
        //        } catch (e) { }
        //        if ((childlenght > 0 && firstnodeName != "#text") || _attrs.length > 0) {
        //            var _childs = nodechilds;
        //            var _childslength = nodechilds.length;
        //            var _fileName_ = "";
        //            if (undefined != _attrs) {
        //                var _attrslength = _attrs.length;
        //                for (var i = 0; i < _attrslength; i++) {//解析xml节点属性
        //                    var attrname = _attrs[i].nodeName;
        //                    var attrvalue = _attrs[i].nodeValue;
        //                    _itemobj[attrname] = attrvalue;
        //                }
        //            }
        //            for (var j = 0; j < _childslength; j++) {//解析xml子节点
        //                var _node = _childs[j];
        //                var _fildName = _node.nodeName;
        //                if ("#text" == _fildName) { break; };
        //                if (_itemobj[_fildName] != undefined) {//如果有重复的节点需要转为数组格式
        //                    if (!(_itemobj[_fildName] instanceof Array)) {
        //                        var a = _itemobj[_fildName];
        //                        _itemobj[_fildName] = [a];//如果该节点出现大于一个的情况 把第一个的值存放到数组中
        //                    }
        //                }
        //                var _fildValue = getAllAttrs(_node);
        //                try {
        //                    _itemobj[_fildName].push(_fildValue);
        //                } catch (e) {
        //                    _itemobj[_fildName] = _fildValue;
        //                    _itemobj["length"] = 1;
        //                }
        //            }
        //        } else {
        //            _itemobj = (node.textContent == undefined) ? node.text : node.textContent;
        //        }
        //        return _itemobj;
        //    };
        //    if (nodename) {
        //        nodenames = nodename.split("/")
        //    }
        //    for (var i = 0; i < nodenames.length; i++) {
        //        obj = obj.find(nodenames[i]);
        //    }
        //    $(obj).each(function (key, item) {
        //        if (itemobj[item.nodeName] != undefined) {
        //            if (!(itemobj[item.nodeName] instanceof Array)) {
        //                var a = itemobj[item.nodeName];
        //                itemobj[item.nodeName] = [a];
        //            }
        //            itemobj[item.nodeName].push(getAllAttrs(item));
        //        } else {
        //            if (nodenames.length > 0) {
        //                itemobj[item.nodeName] = getAllAttrs(item);
        //            } else {
        //                itemobj[item.firstChild.nodeName] = getAllAttrs(item.firstChild);
        //            }
        //        }
        //    });
        //    if (nodenames.length > 1) {
        //        itemobj = itemobj[nodenames[nodenames.length - 1]];
        //    }
        //    if (isarray && !(itemobj instanceof Array) && itemobj != undefined) {
        //        itemobj = [itemobj];
        //    }
        //    return itemobj;
        //};

        //xml字符串转xml对象
        function loadXml(str) {
            if (str == null) {
                return null;
            }
            var doc = str;
            try {
                doc = createXMLDOM();
                doc.async = false;
                doc.loadXML(str);
            } catch (e) {
                doc = $.parseXML(str);
            }
            return doc;
        }
        

        
        function TestXmlToJson() {
            var xmlstr = "<itemData><redItem><limitGameId>121212</limitGameId><State>0</State><limitUserId>85175</limitUserId><limitNickName>Timhoe11</limitNickName><RedContent>测试1</RedContent></redItem><redItem><limitGameId>212121</limitGameId><State>0</State><limitUserId>98685</limitUserId><limitNickName>zxdfjdjt</limitNickName><RedContent>测试2</RedContent></redItem></itemData>";
            //xmlobj = loadXML(xmlstr);
            //alert(xmlobj);
            var xmldoc = loadXml(xmlstr);
           // var obj=xml2json(xmlobj,)
            //alert(xmlobj._childs);
            //var obj = xmltojson(xmlobj,);
            //alert(obj);
            //alert(obj.item.Length);
            //alert(xmldoc);
            var elements = xmldoc.getElementsByTagName("itemData");
            alert(elements.length);

            for (var i = 0; i < elements.length; i++) {
                var _elements = xmldoc.getElementsByTagName("redItem");
                for (var j = 0; j < _elements.length; j++) {
                    var limitGameId = _elements[j].getElementsByTagName("limitGameId")[0].firstChild.nodeValue;
                    var State = _elements[j].getElementsByTagName("State")[0].firstChild.nodeValue;
                    var limitUserId = _elements[j].getElementsByTagName("limitUserId")[0].firstChild.nodeValue;
                    var limitNickName = _elements[j].getElementsByTagName("limitNickName")[0].firstChild.nodeValue;
                    var RedContent = _elements[j].getElementsByTagName("RedContent")[0].firstChild.nodeValue;
                    alert("limitGameId:"+limitGameId);
                    alert("State:"+State);
                    alert("limitUserId:"+limitUserId);
                    alert("limitNickName:"+limitNickName);
                    alert("RedContent:" + RedContent);
                }

            }

            //for (var i = 0; i < elements.length; i++) {
            //    var name = elements[i].getElementsByTagName("cNname")[0].firstChild.nodeValue;
            //    var ip = elements[i].getElementsByTagName("cIP")[0].firstChild.nodeValue;

            //}
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%--<asp:Button ID="Button1" runat="server" Text="lockTest" OnClick="Button1_Click" />--%>
        <br />
        <br />
        <div>
            <%--<input id="btnTest" type="button" value="测试" onclick="TestFun()" />
            <br />

            <div id="jlwerew" href="abc">
            </div>--%>
        </div>
    </form>
</body>
</html>
