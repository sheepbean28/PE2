<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetSuppliesLog.aspx.cs"
    Inherits="PE2.Supplies.GetSuppliesLog" %>

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
            win1 = $.ligerDialog.open({ height: 420, url: 'SuppliesSearch.aspx', width: 800, title: '' });
        }S

    }
    function OpenEditDialog(val, change) {
        if (edit) {
            edit = $.ligerDialog.open({ height: 580, url: 'AssetsEdit.aspx?Mode=' + val + '&change=' + change, width: 800, title: '' });
        }
        else {
            edit = $.ligerDialog.open({ height: 580, url: 'AssetsEdit.aspx?Mode=' + val + '&change=' + change, width: 800, title: '' });
        }
        edit = null;
        return false;
    }
    function OpenAdd() {

        location.href = 'AssetsGroupAdd.aspx';
    }
    function gridviewScroll() {
        var height = $(window).height();
        var width = $(window).width();
        gridView1 = $('#gvList').gridviewScroll({
            width: width - 80,
            height: height - 120,
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

        return result;
    }

    function IsFix(val) {

        return result;
    }
    function IsChange(val) {

        return result;
    }
    function CloseAndreFresh() {

        //location.reload();
        $("#btnHideSearch").click();
        //alert("關閉喔");
        //win1.hide();
    }
    
</script>
<body>
    <form id="form1" runat="server">
    <div style="text-align: left">
        <asp:Button ID="btnExport" runat="server" Text="匯出" class="enjoy-css" 
            onclick="btnExport_Click"  />
        &nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="btnHideSearch" CssClass="enjoy-css" runat="server"
            OnClick="btnHideSearch_Click" Style="display: none;" Text="查詢" Visible="true" />
        &nbsp;共<asp:Label ID="lbCount" runat="server" Text="0"></asp:Label>筆資料
    </div>
    <asp:GridView ID="gvList" runat="server" CellPadding="3" CssClass="EU_DataTable"
        Style="font-size: small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
        BorderWidth="1px" ShowFooter="True" AutoGenerateColumns="False" OnRowDataBound="gvList_RowDataBound"
        AllowPaging="True" PageSize="40" OnPageIndexChanging="gvList_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="Supplies_no" HeaderText="條碼編號" DataFormatString="">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplies_Name" HeaderText="耗材名稱">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="異動原因">
                <ItemTemplate>
                    <asp:Label ID="lbType" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:TemplateField>
            <asp:BoundField DataField="Quantity" HeaderText="異動數量">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplies_date" HeaderText="異動日期" DataFormatString="{0:yyyy/MM/dd HH:mm:ss}">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="User_name" HeaderText="異動人員">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="StockBefore" HeaderText="庫存數量">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="狀態" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lbLimit" runat="server" Text='<%# Bind("Supplies_Limit") %>' Visible="false"></asp:Label>
                    <asp:Label ID="lbWarm" runat="server" Text='<%# Bind("Supplies_Warm") %>' Visible="false"></asp:Label>
                    <asp:Label ID="lbStock" runat="server" Text='<%# Bind("Supplies_Stock") %>' Visible="false"></asp:Label>
                    <asp:Label ID="lbResult" runat="server" Text="庫存充足"></asp:Label>
                </ItemTemplate>
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:TemplateField>
            <asp:BoundField DataField="Note" HeaderText="備註">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <PagerStyle CssClass="GridPager"></PagerStyle>
        <SelectedRowStyle BackColor="#669999" ForeColor="White" Font-Bold="True" />
    </asp:GridView>
    <br />
    </form>
</body>
</html>
