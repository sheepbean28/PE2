<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PE2.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link href="../PE2/Scripts/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../PE2/Scripts/ligerUI/skins/Aqua/css/ligerui-dialog.css"
            rel="stylesheet" type="text/css" />
    <script src="../PE2/Scripts/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../PE2/Scripts/ligerUI/js/ligerui.all.js" type="text/javascript"></script>
    <script src="../PE2/Scripts/indexdata.js" type="text/javascript"></script>
    <link href="../PE2/Styles/Login.css" rel="stylesheet" type="text/css" />
    <link href="../PE2/Images/image053.ico" rel="SHORTCUT ICON">
    <title>PE2業務管理系統</title>
    <style type="text/css">
        .Title-css
        {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            -webkit-box-sizing: content-box;
            -moz-box-sizing: content-box;
            box-sizing: content-box;
            margin: 0 10px 0 0;
            padding: 10px 0 10px 10px;
            -webkit-border-radius: 7px;
            border-radius: 7px;
            font: normal normal bold 26px/1 "Times New Roman" , Times, serif;
            color: rgba(247,239,239,1);
            -o-text-overflow: ellipsis;
            text-overflow: ellipsis;
            background: #3498db;
            -webkit-box-shadow: 5px 5px 8px 2px rgba(0,0,0,0.4);
            box-shadow: 5px 5px 8px 2px rgba(0,0,0,0.4);
            text-shadow: 4px 4px 6px rgba(0,0,0,0.5);
            -webkit-transition: all 200ms cubic-bezier(0.42, 0, 0.58, 1) 10ms;
            -moz-transition: all 200ms cubic-bezier(0.42, 0, 0.58, 1) 10ms;
            -o-transition: all 200ms cubic-bezier(0.42, 0, 0.58, 1) 10ms;
            transition: all 200ms cubic-bezier(0.42, 0, 0.58, 1) 10ms;
            width: 404px;
        }
        .body-css
        {
          height:100%;    
          background-color:#cbe4f7;
        }
        .style1
        {
            width: 80px;
            height: 69px;
        }
        .style2
        {
            font-size: 26pt;
            font-family: 微軟正黑體;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            var height = ($(document).height() - 20);
            //alert(height);
           // $("body").height(height);
           // $("body").offset({ top:0, left:0})
        });
    </script>
</head>
<body class="body-css">
    <form id="form1" runat="server">
    <div class="container">
        <div id="signin-block">
            <div id="singin-title">
                <div class="Title-css">
                    &nbsp;<img alt="" class="style1" src="Images/image053.jpg" />&nbsp;&nbsp;
                    <span class="style2">PE2業務管理系統</span></div>
            </div>
            <div id="singin-word-1" class="text_02">
                &nbsp;<asp:TextBox ID="tbUsername" CssClass="InputBar" Style="border: 0; margin-top: 10px"
                    placeholder="工號" runat="server" required></asp:TextBox>
            </div>
            <div id="singin-word-1" class="text_03">
                <asp:TextBox ID="tbPassword" CssClass="InputBar" Style="border: 0; margin-top: 10px"
                    placeholder="密碼" runat="server" required TextMode="Password"></asp:TextBox>
            </div>
            <div id="sing-bt">
                <div style="float: right">
                    <asp:Button ID="btnConfirm" CssClass="css_btn_class" runat="server" Text="登入系統" Style="width: 100px"
                        OnClick="btnConfirm_Click" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
