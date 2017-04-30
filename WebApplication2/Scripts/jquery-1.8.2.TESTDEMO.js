$.extend({ fun1: function () { alert("执行方法一"); } });
$.fn.extend({ fun2: function () { alert("执行方法2"); } });

//step01 定义JQuery的作用域
(function ($) {
    //step03-a 插件的默认值属性
    var defaults = {
        prevId: 'prevBtn',
        prevText: 'Previous',
        nextId: 'nextBtn',
        nextText: 'Next'
        //……
    };
    //step06-a 在插件里定义方法
    var showLink = function (obj) {
        //$(obj).append(function () { return "(" + $(obj).attr("href") + ")" });
        if (typeof ($(obj).attr("href")) == "undefined") {
            alert('undefined');
        }
        else {
            $(obj).append(function () { return "(" + $(obj).attr("href") + ")" });
        }
        //alert($(obj).text());
        //alert($(obj).attr("href"));
    }
    //step02 插件的扩展方法名称
    $.fn.easySlider = function (options) {
        //alert('easySlider调用一下');
        //step03-b 合并用户自定义属性，默认属性
        var options = $.extend(defaults, options);
        //step4 支持JQuery选择器
        //step5 支持链式调用
        return this.each(function () {
            //step06-b 在插件里定义方法
            showLink(this);
        });
    }
})(jQuery);