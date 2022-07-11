<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalibrateList.aspx.cs"
    Inherits="PE2.Assets.CalibrateList" %>

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
            win1 = $.ligerDialog.open({ height: 580, url: 'CalibrateSearch.aspx', width: 800, title: '' });
        }

    }

    function OpenEditDialog(val, change) {
        if (edit) {
            edit = $.ligerDialog.open({ height: 580, url: 'CalibrateEdit.aspx?Mode=' + val + '&change=' + change, width: 800, title: '' });
        }
        else {
            edit = $.ligerDialog.open({ height: 580, url: 'CalibrateEdit.aspx?Mode=' + val + '&change=' + change, width: 800, title: '' });
        }
        edit = null;
        return false;
    }

    function OpenCpDialog(val,edit) {
        if (edit) 
        {
            edit = $.ligerDialog.open({ height: 370, url: 'CalibrateTo.aspx?Mode=' + val, width: 500, title: '' });
        }
        else 
        {
            edit = $.ligerDialog.open({ height: 370, url: 'CalibrateReturn.aspx?Mode=' + val, width: 500, title: '' });
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
        gridView1 = $('#gvCalibrate').gridviewScroll({
            width: width - 80,
            height: height - 120,
            railcolor: "#F0F0F0",
            barcolor: "#CDCDCD",
            barhovercolor: "#606060",
            bgcolor: "#F0F0F0",
            freezesize: 5,
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
        &nbsp;<input id="btnAdd" runat="server" type="button" value="新增校驗儀器" class="enjoy-css"
            onclick="OpenEditDialog(0.0)" />
        <input id="btnSearch" type="button" value="查詢" class="enjoy-css" onclick="OpenDialog()" />
        &nbsp;<asp:Button ID="btnExport" CssClass="enjoy-css" runat="server" Text="匯出EXCEL" 
            Visible="true" onclick="btnExport_Click" />
             &nbsp;<asp:Button ID="btnExportWord" CssClass="enjoy-css" runat="server" Text="匯出校驗單" 
            Visible="true" onclick="btnExportWord_Click" />
        &nbsp;<asp:Button ID="btnHideSearch" CssClass="enjoy-css" runat="server" OnClick="btnHideSearch_Click"
            Style="display: none;" Text="查詢" Visible="true" />
        &nbsp;共<asp:Label ID="lbCount" runat="server" Text="0"></asp:Label>筆資料
    </div>
    <asp:GridView ID="gvCalibrate" runat="server" CellPadding="3" CssClass="EU_DataTable"
        Style="font-size: small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
        BorderWidth="1px" ShowFooter="True" AutoGenerateColumns="False" OnRowDataBound="gvAssets_RowDataBound"
        AllowPaging="True" PageSize="40" 
        OnPageIndexChanging="gvAssets_PageIndexChanging" 
        onprerender="gvCalibrate_PreRender">
        <Columns>
            <asp:TemplateField HeaderText="功能">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:HiddenField ID="hfCp_Status" runat="server" Value='<%# Eval("Cp_Status") %>' />
                     <asp:HiddenField ID="hfCp_Type" runat="server" Value='<%# Eval("Cp_Type") %>' />
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="RowDelete" CommandArgument='<%# Eval("Assets_sn") %>'
                        OnClientClick='<%# @"return OpenEditDialog("""+ Eval("Calibrate_sn") + @""",0);" %>'>
                        修改</asp:LinkButton>
                    <asp:LinkButton ID="btnToCalibrate" runat="server"  
                        OnClientClick='<%# @"return OpenCpDialog("""+ Eval("Calibrate_sn") + @""",true);" %>'>
                        校驗</asp:LinkButton>
                    <asp:LinkButton ID="btnReturnCalibrate" runat="server" 
                        OnClientClick='<%# @"return OpenCpDialog("""+ Eval("Calibrate_sn") + @""",false);" %>'>
                        送回</asp:LinkButton>
                 
                </ItemTemplate>
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:TemplateField>
            <asp:BoundField DataField="Assts_no" HeaderText="標籤代碼" DataFormatString="">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Assts_id" HeaderText="資產編號">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Eq_id" HeaderText="校驗編號">
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
            <asp:BoundField DataField="Eq_name" HeaderText="設備名稱">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Assts_Quantity" HeaderText="數量">
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
            <asp:BoundField DataField="Place_Assets_Detail_sn" HeaderText="關聯儲位">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Assts_Station" HeaderText="測試站別">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Last_Cp_Date" HeaderText="上次校驗日期" DataFormatString="{0:yyyy/MM/dd}">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Next_Cp_Date" HeaderText="下次校驗日期" DataFormatString="{0:yyyy/MM/dd}">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Cp_Date_Range" HeaderText="校驗期間">
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
