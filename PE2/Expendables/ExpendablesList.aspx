<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpendablesList.aspx.cs" Inherits="PE2.Expendables.ExpendablesList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="../../PE2/Scripts/jquery-ui-1.11.4/external/jquery/jquery.js" type="text/javascript"></script>
    <script src="../Scripts/ligerUI/js/ligerui.all.js" type="text/javascript"></script>
    <script src="../../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.js" type="text/javascript"></script>
    <script src="../../PE2/Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Scripts/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Grid.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Item.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/GridviewScroll.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<script type="text/javascript">
    var win1;
    var edit;
    var result = false;
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
        var height = ($(document).height() - 20);

        //  $("#tbStartDate").datepicker({ dateFormat: 'yy-mm-dd' });
        //   $("#tbEndDate").datepicker({ dateFormat: 'yy-mm-dd' });
        gridviewScroll();

    });
    function OpenDialog() {
        if (win1) {
            win1.show();
        }
        else {
            win1 = $.ligerDialog.open({ height: 420, url: 'FixtureSearch.aspx', width: 550, title: '' });
        }

    }
    function OpenEditDialog(val) {
        if (edit) {
            edit = $.ligerDialog.open({ height: 600, url: 'FixtureEdit.aspx?Mode=' + val, width: 800, title: '' });
        }
        else {
            edit = $.ligerDialog.open({ height: 600, url: 'FixtureEdit.aspx?Mode=' + val, width: 800, title: '' });
        }
        edit = null;
        return false;
    }

    function gridviewScroll() {
        var height = $(window).height();
        var width = $(window).width();
        gridView1 = $('#gvFixture').gridviewScroll({
            width: width,
            height: height - 60,
            railcolor: "#F0F0F0",
            barcolor: "#CDCDCD",
            barhovercolor: "#606060",
            bgcolor: "#F0F0F0",
            freezesize: 4,
            arrowsize: 30,
            varrowtopimg: "../Images/arrowvt.png",
            varrowbottomimg: "../Images/arrowvb.png",
            harrowleftimg: "../Images/arrowhl.png",
            harrowrightimg: "../Images/arrowhr.png",
            headerrowcount: 2,
            railsize: 16,
            barsize: 8
        });
    }
    function IsRemove(val) {
        $.ligerDialog.confirm("確定報廢此治具嗎?", function (yes) {
            if (yes) {
                $.ajax({
                    url: '/PE2/Ashx/ChangeRemove.ashx',
                    data: { Fixture_sn: val },
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (result) {

                        location.reload();
                    },
                    error: function () {
                        alert('error');
                    }
                });
            }
        });
        return result;
    }

    function IsFix(val) {
        $.ligerDialog.confirm("確定送修此治具嗎?", function (yes) {
            if (yes) {
                $.ajax({
                    url: '/PE2/Ashx/ChangeLimitDate.ashx',
                    data: { Fixture_sn: val },
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (result) {
                        //$.ligerDialog.waitting('正在保存中,请稍候...'); setTimeout(function () { $.ligerDialog.closeWaitting(); }, 4000);
                        location.reload();
                    },
                    error: function () {
                        alert('error');
                    }
                });
            }
        });
        return result;
    }
    function CloseAndreFresh() {

        location.reload();
        //alert("關閉喔");
        //win1.hide();
    }

</script>
<body>
    <form id="form1" runat="server">
    <div style="text-align: left">
        <%--<asp:Button ID="btnSearch" runat="server" CssClass="enjoy-css" runat="server" OnClick="btnExport_Click" Text="查詢"  />--%>
        <input id="btnAdd" runat="server" type="button" value="新增治具" class="enjoy-css" onclick="OpenEditDialog(0)" />
        <input id="btnSearch" type="button" value="查詢" class="enjoy-css" onclick="OpenDialog()" />
        &nbsp;<asp:Button ID="btnExport" CssClass="enjoy-css" runat="server" OnClick="btnExport_Click"
            Text="匯出" Visible="true" />
        &nbsp;&nbsp;共<asp:Label ID="lbCount" runat="server" Text="0"></asp:Label>筆資料
    </div>
    <asp:GridView ID="gvFixture" runat="server" CellPadding="3" CssClass="EU_DataTable"
        Style="font-size: small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
        BorderWidth="1px" ShowFooter="True" AutoGenerateColumns="False" OnPreRender="gvFixture_PreRender">
        <Columns>
            <asp:TemplateField HeaderText="功能">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="RowDelete" CommandArgument='<%# Eval("Fixture_no") %>'
                        OnClientClick='<%# @"return OpenEditDialog("""+ Eval("Fixture_sn") + @""");" %>'>
                        修改</asp:LinkButton>
                    <asp:LinkButton ID="btnRemove" runat="server" CommandName="RowDelete" CommandArgument='<%# Eval("Fixture_no") %>'
                        OnClientClick='<%# @"return IsRemove("""+ Eval("Fixture_sn") + @""");" %>'>
                        報廢</asp:LinkButton>
                    <%--   <asp:LinkButton ID="btnFix" runat="server" CommandName="RowDelete" CommandArgument='<%# Eval("Fixture_no") %>'
                            OnClientClick='<%# @"return IsFix("""+ Eval("Fixture_sn") + @""");" %>'>送修</asp:LinkButton>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Fixture_no" HeaderText="治具代碼" DataFormatString="">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Fixture_car" HeaderText="治具位置">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Fixture_car1" HeaderText="車次">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Fixture_car2" HeaderText="位置">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Fixture_name" HeaderText="治具名稱">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Fixture_usefor" HeaderText="治具用途">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Fixture_no_old" HeaderText="舊治具代碼">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Fixture_lic_old" HeaderText="舊治具資產編號">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Fixture_sn_old" HeaderText="舊治具流水號">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="治具狀態">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Quantity" HeaderText="數量">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Create_date" HeaderText="收到日期" DataFormatString="{0:yyyy/MM/dd}">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Limit_date" HeaderText="使用期限" DataFormatString="{0:yyyy/MM/dd}">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" ForeColor="White" Font-Bold="True" />
    </asp:GridView>
    <br />
    </form>
</body>
</html>
