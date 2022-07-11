﻿<%@ Page Title="首頁" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="PE2._Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link href="../PE2/Images/image053.ico" rel="SHORTCUT ICON">
    <title>PE2業務管理系統</title>
    <link href="../PE2/Scripts/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet"
        type="text/css" />
    <script src="../PE2/Scripts/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../PE2/Scripts/ligerUI/js/ligerui.all.js" type="text/javascript"></script>
    <script src="../PE2/Scripts/indexdata2.js" type="text/javascript"></script>
    <script type="text/javascript">
        var tab = null;
        var accordion = null;
        var tree = null;
        $(function () {
            $("#home").attr("src", "Main.aspx");
            //布局
            $("#layout1").ligerLayout({ leftWidth: 190, height: '100%', heightDiff: -34, space: 4, onHeightChanged: f_heightChanged });

            var height = $(document).height();

            //Tab
            $("#framecenter").ligerTab({ height: height });

            //面板
            $("#accordion1").ligerAccordion({ height: height - 24, speed: null });

            $(".l-link").hover(function () {
                $(this).addClass("l-link-over");
            }, function () {
                $(this).removeClass("l-link-over");
            });
            //树
            $("#tree1").ligerTree({
                data: indexdata2,
                checkbox: false,
                slide: false,
                nodeWidth: 120,
                attribute: ['nodename', 'url'],
                onSelect: function (node) {
                    if (!node.data.url) return;
                    var tabid = $(node.target).attr("tabid");
                    if (!tabid) {
                        tabid = new Date().getTime();
                        $(node.target).attr("tabid", tabid)
                    }
                    f_addTab(tabid, node.data.text, node.data.url);
                }
            });
              
            tab = $("#framecenter").ligerGetTabManager();
            accordion = $("#accordion1").ligerGetAccordionManager();
            tree = $("#tree1").ligerGetTreeManager();
            $("#pageloading").hide();

        });
        function f_heightChanged(options) {
            if (tab)
                tab.addHeight(options.diff);
            if (accordion && options.middleHeight - 24 > 0)
                accordion.setHeight(options.middleHeight - 24);
        }
        function f_addTab(tabid, text, url) {
            tab.addTabItem({ tabid: tabid, text: text, url: url });
        }
        function ReturnLogin() 
        {
            $.ligerDialog.warn('登入過期，已登出系統', '警告', function () {
                location.href = '/PE2/Login.aspx';
             });
            
            //alert("關閉喔");
            //win1.hide();
        }  
            
    </script>
    <style type="text/css">
        body, html
        {
            height: 100%;
        }
        body
        {
            padding: 0px;
            margin: 0;
            overflow: hidden;
        }
        .l-link
        {
            display: block;
            height: 26px;
            line-height: 26px;
            padding-left: 10px;
            text-decoration: underline;
            color: #333;
        }
        .l-link2
        {
            text-decoration: underline;
            color: white;
            margin-left: 2px;
            margin-right: 2px;
        }
        .l-layout-top
        {
            background: #102A49;
            color: White;
        }
        .l-layout-bottom
        {
            background: #E5EDEF;
            text-align: center;
        }
        #pageloading
        {
            position: absolute;
            left: 0px;
            top: 0px;
            background: white url('loading.gif') no-repeat center;
            width: 100%;
            height: 100%;
            z-index: 99999;
        }
        .l-link
        {
            display: block;
            line-height: 22px;
            height: 22px;
            padding-left: 16px;
            border: 1px solid white;
            margin: 4px;
        }
        .l-link-over
        {
            background: #FFEEAC;
            border: 1px solid #DB9F00;
        }
        .l-winbar
        {
            background: #2B5A76;
            height: 30px;
            position: absolute;
            left: 0px;
            bottom: 0px;
            width: 100%;
            z-index: 99999;
        }
        .space
        {
            color: #E7E7E7;
        }
        /* 顶部 */
        .l-topmenu
        {
            margin: 0;
            padding: 0;
            height: 31px;
            line-height: 31px;
            background: url('lib/images/top.jpg') repeat-x bottom;
            position: relative;
            border-top: 1px solid #1D438B;
        }
        .l-topmenu-logo
        {
            color: #E7E7E7;
            padding-left: 35px;
            line-height: 26px;
            background: url('lib/images/topicon.gif') no-repeat 10px 5px;
        }
        .l-topmenu-welcome
        {
            position: absolute;
            height: 24px;
            line-height: 24px;
            right: 30px;
            top: 2px;
            color: #070A0C;
        }
        .l-topmenu-welcome a
        {
            color: #E7E7E7;
            text-decoration: underline;
        }
    </style>
</head>
<body style="padding: 0px; background: #EAEEF5;">
    <form runat="server">
    <div id="pageloading">
    </div>
    <div id="topmenu" class="l-topmenu" runat="server">
        <div style="width:100%; text-align: right;"  >
            <asp:Label ID="lbName" runat="server" Text="Label"></asp:Label> 歡迎登入
            <asp:LinkButton ID="lbLogout" runat="server" OnClick="lbLogout_Click">登出</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </div>
    <div id="layout1" style="width: 99.2%; margin: 0 auto; margin-top: 4px;">
        <div position="left" title="主選單" id="accordion1">
            <div title="PE2業務管理系統" class="l-scroll">
                <ul id="tree1" style="margin-top: 3px;">
            </div>
        </div>
        <div position="center" id="framecenter">
            <div tabid="home" title="首頁" style="height: 300px">
                <iframe frameborder="0" name="home" id="home" src="Main"></iframe>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
