<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShieldingBoxList.aspx.cs"
    Inherits="PE2.Assets.ShieldingBoxList" %>

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
    var edit = false;
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
            win1 = $.ligerDialog.open({ height: 580, url: 'ShieldingBoxSearch.aspx', width: 800, title: '' });
        }

    }

    function OpenEditDialog(val, change) {
        if (edit) {
            edit = $.ligerDialog.open({ height: 580, url: 'ShieldingBoxEdit.aspx?Mode=' + val + '&change=' + change, width: 800, title: '' });
        }
        else {
            edit = $.ligerDialog.open({ height: 580, url: 'ShieldingBoxEdit.aspx?Mode=' + val + '&change=' + change, width: 800, title: '' });
        }
        edit = null;
        return false;
    }
    function OpenCpDialog(val, edit) {
        if (edit) {
            edit = $.ligerDialog.open({ height: 590, url: 'ShieldingBoxCp.aspx?Mode=' + val, width: 800, title: '' });
        }
        else {
            edit = $.ligerDialog.open({ height: 590, url: 'ShieldingBoxCp.aspx?Mode=' + val, width: 800, title: '' });
        }
        edit = null;
        return false;
    }

    //ShieldingBoxCp.aspx

    function OpenAdd() {
        location.href = 'AssetsGroupAdd.aspx';
    }
    function gridviewScroll() {
        var height = $(window).height();
        var width = $(window).width();
        gridView1 = $('#gvShieldingBox').gridviewScroll({
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
        &nbsp;<input id="btnAdd" runat="server" type="button" value="隔離箱校驗" class="enjoy-css"
            onclick="OpenEditDialog(0.0)" />
        <input id="btnSearch" type="button" value="查詢" class="enjoy-css" onclick="OpenDialog()" />
        &nbsp;<asp:Button ID="btnExport" CssClass="enjoy-css" runat="server" Text="匯出" Visible="true" />
        &nbsp;<asp:Button ID="btnHideSearch" CssClass="enjoy-css" runat="server" OnClick="btnHideSearch_Click"
            Style="display: none;" Text="查詢" Visible="true" />
        &nbsp;共<asp:Label ID="lbCount" runat="server" Text="0"></asp:Label>筆資料
    </div>
    <asp:GridView ID="gvShieldingBox" runat="server" CellPadding="3" CssClass="EU_DataTable"
        Style="font-size: small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
        BorderWidth="1px" ShowFooter="True" AutoGenerateColumns="False" OnRowDataBound="gvAssets_RowDataBound"
        AllowPaging="True" PageSize="40" OnPageIndexChanging="gvAssets_PageIndexChanging"
        OnPreRender="gvCalibrate_PreRender">
        <Columns>
            <asp:TemplateField HeaderText="功能">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" OnClientClick='<%# @"return OpenEditDialog("""+ Eval("ShieldingBox_sn") + @""",true);" %>'>
                        修改</asp:LinkButton>
                    <asp:LinkButton ID="btnToCalibrate" runat="server" OnClientClick='<%# @"return OpenCpDialog("""+ Eval("ShieldingBox_sn") + @""",true);" %>'>
                        校驗</asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:TemplateField>
            <asp:BoundField DataField="Cp_date" HeaderText="上次校驗日期" DataFormatString="{0:yyyy/MM/dd}">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Limit_date" HeaderText="下次校驗日期" DataFormatString="{0:yyyy/MM/dd}">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Assts_no" HeaderText="標籤代碼" DataFormatString="">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Assts_id" HeaderText="資產編號">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Assts_name" HeaderText="資產名稱">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Assts_eq_id" HeaderText="資產管制編號">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Assts_eq_name" HeaderText="資產管制名稱">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Place_name" HeaderText="存放位置">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Place_sn" HeaderText="所在位置">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Place_Assets_sn" HeaderText="儲位代碼">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Cp2G_Open" HeaderText="2G開啟">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Cp2G_Close" HeaderText="2G關閉">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Cp2G_Shileld" HeaderText="2G隔離度">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Cp5G_Open" HeaderText="5G開啟">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Cp5G_Close" HeaderText="5G關閉">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Cp5G_Shileld" HeaderText="5G隔離度">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Leakage" HeaderText="漏電流">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Leakage_no" HeaderText="漏電流單位">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="ShieldingBox_Note" HeaderText="備註">
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
