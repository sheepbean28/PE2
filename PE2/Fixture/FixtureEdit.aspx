<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FixtureEdit.aspx.cs" Inherits="PE2.Fixture.FixtureEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="../../PE2/Scripts/jquery-ui-1.11.4/external/jquery/jquery.js" type="text/javascript"></script>
    <script src="../Scripts/ligerUI/js/ligerui.all.js" type="text/javascript"></script>
    <script src="../../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.js" type="text/javascript"></script>
    <link href="../../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../PE2/Scripts/ligerUI/skins/Aqua/css/ligerui-dialog.css" rel="stylesheet"
        type="text/css" />
    <link href="../Styles/Form.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Item.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script type="text/javascript">

        $.datepicker.regional['zh-TW'] = {
            dayNames: ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"],
            dayNamesMin: ["日", "一", "二", "三", "四", "五", "六"],
            monthNames: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
            monthNamesShort: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
            prevText: "上月",
            nextText: "次月",
            weekHeader: "週"
        };
        //將預設語系設定為中文
        $.datepicker.setDefaults($.datepicker.regional["zh-TW"]);
        $(function () {
            $("#txtCreateDate").datepicker({ dateFormat: 'yy-mm-dd' });
            $("#txtLimitDate").datepicker({ dateFormat: 'yy-mm-dd' });
        });

        function refresh() 
        {
            window.parent.CloseAndreFresh();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hfFixture_sn" runat="server" />
    <div>
    <asp:HiddenField ID="hfFixture_no" runat="server" />
        <fieldset>
            <legend>治具管理</legend>
            <p>
                治具新增</p>
            <div class="elements">
                <label for="question">
                    治具編號:</label>&nbsp;<asp:TextBox ID="txtFixture_no" required runat="server"></asp:TextBox>
            </div>
            <div class="elements">
                <label for="question">
                    治具位置:</label>
                <asp:DropDownList ID="ddlFixture_car" runat="server">
                </asp:DropDownList>
                &nbsp;<asp:DropDownList ID="ddlFixture_car2" runat="server">
                    <asp:ListItem Value="0">第0層</asp:ListItem>
                    <asp:ListItem Value="1">第1層</asp:ListItem>
                    <asp:ListItem Value="2">第2層</asp:ListItem>
                    <asp:ListItem Value="3">第3層</asp:ListItem>
                    <asp:ListItem Value="4">第4層</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:DropDownList ID="ddlFixture_car3" runat="server">
                    <asp:ListItem Value="Ⅰ">I</asp:ListItem>
                    <asp:ListItem Value="Ⅱ">Ⅱ</asp:ListItem>
                    <asp:ListItem Value="Ⅲ">Ⅲ</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="elements">
                <label for="question">
                    治具名稱:</label>
                <asp:TextBox ID="txtFixture_name" required runat="server"></asp:TextBox>
            </div>
            <div class="elements">
                <label for="question">
                    用途:</label>
                <asp:TextBox ID="txtFixture_usefor" required runat="server"></asp:TextBox>
            </div>
            <div class="elements">
                <label for="question">
                    數量:</label>
                <asp:TextBox ID="txtQuantity" type="number" required Width="60" runat="server" Text="1">1</asp:TextBox>
            </div>
            <div class="elements">
                <label for="question">
                    收到日期:</label>
                <asp:TextBox ID="txtCreateDate" runat="server" required CssClass="calendar"></asp:TextBox>
            </div>
            <div class="elements">
                <label for="question">
                    使用期限:</label>
                <asp:TextBox ID="txtLimitDate" runat="server" required CssClass="calendar"></asp:TextBox>
            </div>
            <div class="elements">
                <label for="question">
                    備註:</label>
                <asp:TextBox ID="txtNote" runat="server" Height="53px" TextMode="MultiLine" Width="720px"></asp:TextBox>
            </div>
            <div class="submit">
                <asp:Button ID="btnConfirm" runat="server" Text="新增" OnClick="btnConfirm_Click" />
                <%--<input id="btnConfirm" type="button" value="查詢" onclick="refresh()" />--%>
            </div>
        </fieldset>
    </div>
    </form>
</body>
</html>
