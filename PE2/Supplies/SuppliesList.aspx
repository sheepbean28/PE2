<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuppliesList.aspx.cs" Inherits="PE2.Supplies.SuppliesList" %>

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
    var Add;
    var edit;
    var PICS;
    var Export;
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
            win1 = $.ligerDialog.open({ height: 450, url: 'SuppliesSearch.aspx', width: 800, title: '' });
        }

    }
    function OpenEditDialog(val, change) {
        if (edit) 
        {
            edit = $.ligerDialog.open({ height: 650, url: 'SuppliesEdit.aspx?Mode=' + val + '&change=' + change, width: 700, title: '' });
        }
        else 
        {
            edit = $.ligerDialog.open({ height: 650, url: 'SuppliesEdit.aspx?Mode=' + val + '&change=' + change, width: 700, title: '' });
        }
        edit = null;
        return false;
    }
    function OpenExportDialog() {
        if (Export) {
            Export = $.ligerDialog.open({ height: 400, url: 'Export.aspx', width: 600, title: '' });
        }
        else {
            Export = $.ligerDialog.open({ height: 400, url: 'Export.aspx', width: 600, title: '' });
        }
        Export = null;
        return false;
    }
    function OpenPICSDialog(val) 
    {
        if (PICS) {
            PICS = $.ligerDialog.open({ height: 650, url: 'PICS.aspx?Mode=' + val + '&change=1', width: 700, title: '' });
        }
        else {
            PICS = $.ligerDialog.open({ height: 650, url: 'PICS.aspx?Mode=' + val + '&change=1', width: 700, title: '' });
        }
        edit = null;
        return false;
    }
    function OpenAdd() 
    {
        if (Add) {
            Add.show();
        }
        else {
            Add = $.ligerDialog.open({ height: 650, url: 'SuppliesEdit.aspx?Mode=0', width: 700, title: '' });
        }

    }
    function IsChange(val) 
    {
        $.ligerDialog.prompt("入庫數量?", function (yes, value) {
            if (yes) {
                $.ajax({
                    url: '/PE2/Ashx/SuppliesAdd.ashx',
                    data: { Supplies_sn: val, Note: value },
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
        &nbsp;<input id="btnAdd" runat="server" type="button" value="耗材新增" class="enjoy-css"
            onclick="OpenAdd()" />
        <input id="btnSearch" type="button" value="查詢" class="enjoy-css" onclick="OpenDialog()" />
        &nbsp;
        <%--<asp:Button ID="btnExport" CssClass="enjoy-css" runat="server" Text="匯出" 
            Visible="true" onclick="btnExport_Click" OnClientClick="OpenExportDialog();" />--%>
             <input id="btnExport" type="button" value="匯出" class="enjoy-css" onclick="OpenExportDialog()" />
        &nbsp;<asp:Button ID="btnHideSearch" CssClass="enjoy-css" runat="server" OnClick="btnHideSearch_Click"
            Style="display: none;" Text="查詢" Visible="true" />
        &nbsp;共<asp:Label ID="lbCount" runat="server" Text="0"></asp:Label>筆資料
    </div>
    <asp:GridView ID="gvList" runat="server" CellPadding="3" CssClass="EU_DataTable"
        Style="font-size: small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
        BorderWidth="1px" ShowFooter="True" AutoGenerateColumns="False" OnRowDataBound="gvList_RowDataBound"
        AllowPaging="True" PageSize="40" 
        OnPageIndexChanging="gvList_PageIndexChanging" onprerender="gvList_PreRender">
        <Columns>
            <asp:TemplateField HeaderText="圖片">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Supplies_File") %>' Width="50" Height="50"  onclick='<%# @"return OpenPICSDialog("""+ Eval("Supplies_sn") + @""");" %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="功能">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="RowDelete" CommandArgument='<%# Eval("Supplies_sn") %>'
                        OnClientClick='<%# @"return OpenEditDialog("""+ Eval("Supplies_sn") + @""",0);" %>'>
                        修改</asp:LinkButton>
                   <asp:LinkButton ID="btnChange" runat="server" CommandName="RowDelete" CommandArgument='<%# Eval("Supplies_sn") %>'
                        OnClientClick='<%# @"return IsChange("""+ Eval("Supplies_sn") + @""");" %>'>
                        進貨入庫</asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:TemplateField>
            <asp:BoundField DataField="Supplies_no" HeaderText="條碼編號" DataFormatString="">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplies_Class" HeaderText="類別">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplies_C_No" HeaderText="群組代碼">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplies_Name" HeaderText="耗材名稱">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <%--<asp:BoundField DataField="Code_name" HeaderText="存放位置">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>--%>
            <asp:BoundField DataField="Supplies_Add" HeaderText="入庫數量">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplies_In" HeaderText="退庫">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplies_Out" HeaderText="領用">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplies_R_OUT" HeaderText="外借">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplies_R_IN" HeaderText="歸還">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplies_Stock" HeaderText="庫存數量">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
             <asp:TemplateField HeaderText="狀態">
                <ItemTemplate>
                     <asp:Label ID="lbLimit" runat="server" Text='<%# Bind("Supplies_Limit") %>' Visible="false"></asp:Label>
                     <asp:Label ID="lbWarm" runat="server" Text='<%# Bind("Supplies_Warm") %>' Visible="false"></asp:Label>
                      <asp:Label ID="lbStock" runat="server" Text='<%# Bind("Supplies_Stock") %>' Visible="false" ></asp:Label>
                      <asp:Label ID="lbResult" runat="server" Text="庫存充足" ></asp:Label>
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
