<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FixtureListOut.aspx.cs" Inherits="PE2.Fixture.FixtureListOut" %>

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
        $("#tbOutDate").datepicker({ dateFormat: 'yy-mm-dd' });
        gridviewScroll();

    });
    function OpenDialog() {
        if (win1) {
            win1.show();
        }
        else {
            win1 = $.ligerDialog.open({ height: 420, url: 'FixtureSearch.aspx?M=Out', width: 550, title: '' });
        }

    }
 
    function gridviewScroll() {
        var height = $(window).height();
        var width = $(window).width();
        gridView1 = $('#gvFixture').gridviewScroll({
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
    function CloseAndreFresh()
    {
        $("#btnSearch").click();
        //document.getElementById("myCheck").click();
        //location.reload();
        //alert("關閉喔");
        //win1.hide();
    }

</script>
<body>
    <form id="form1" runat="server">
    <asp:Button ID="btnSearch" runat="server" Text="Button" OnClick="btnSearch_Click" style="display:none;" />
    <div style="text-align: left">
        <%--<asp:Button ID="btnSearch" runat="server" CssClass="enjoy-css" runat="server" OnClick="btnExport_Click" Text="查詢"  />--%>&nbsp;<input id="btnSearch" type="button" value="查詢" class="enjoy-css" onclick="OpenDialog()" /> 共<asp:Label ID="lbCount" runat="server" Text="0"></asp:Label>筆資料&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <label for="question">
        位置:</label>&nbsp;
        <asp:DropDownList ID="ddlPlace_sn" runat="server" AutoPostBack="True" DataTextField="Place_name" DataValueField="Place_sn" OnSelectedIndexChanged="ddlPlace_sn_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;<asp:DropDownList ID="ddlPlace_sn1" runat="server" DataTextField="Place_name" DataValueField="Place_sn">
        </asp:DropDownList>
        &nbsp;借出日期:
        <asp:TextBox ID="tbOutDate" runat="server" CssClass="calendar" ></asp:TextBox>
&nbsp;<asp:Button ID="btnIn" CssClass="enjoy-css" runat="server"
            Text="列表借出" Visible="true" onclick="btnIn_Click" />
        &nbsp; &nbsp;</div>
    <asp:GridView ID="gvFixture" runat="server" CellPadding="3" CssClass="EU_DataTable"
        Style="font-size: small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
        BorderWidth="1px" ShowFooter="True" AutoGenerateColumns="False"  AllowPaging="True" PageSize="40" OnPageIndexChanging="gvList_PageIndexChanging"
        OnPreRender="gvFixture_PreRender" onrowdatabound="gvFixture_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Fixture_no" HeaderText="治具代碼" DataFormatString="">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Place_name" HeaderText="治具位置">
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
            <asp:BoundField DataField="Note" HeaderText="治具備註">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
      
           
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle CssClass="GridPager"></PagerStyle>
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" ForeColor="White" Font-Bold="True" />
    </asp:GridView>
    <br />
    </form>
</body>
</html>
