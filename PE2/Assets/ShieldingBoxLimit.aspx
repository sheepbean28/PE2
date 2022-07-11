<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShieldingBoxLimit.aspx.cs" Inherits="PE2.Assets.ShieldingBoxLimit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="../../PE2/Scripts/jquery-ui-1.11.4/external/jquery/jquery.js" type="text/javascript"></script>
    <script src="../Scripts/ligerUI/js/ligerui.all.js" type="text/javascript"></script>
    <script src="../../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.js" type="text/javascript"></script>
    <script src="../../PE2/Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="../Scripts/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../Styles/Grid.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Item.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/GridviewScroll.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<script type="text/javascript">
    var win1;
    var result = false
    $(function () {
        var height = ($(document).height() - 20);

        //  $("#tbStartDate").datepicker({ dateFormat: 'yy-mm-dd' });
        //   $("#tbEndDate").datepicker({ dateFormat: 'yy-mm-dd' });
        gridviewScroll();

    });
    function gridviewScroll() {
        var height = $(window).height();
        var width = $(window).width();
        gridView1 = $('#gvCalibrate').gridviewScroll({
            width: width + 15,
            height: height,
            railcolor: "#F0F0F0",
            barcolor: "#CDCDCD",
            barhovercolor: "#606060",
            bgcolor: "#F0F0F0",
            freezesize: 2,
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
    
</script>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="gvCalibrate" runat="server" CellPadding="3" CssClass="EU_DataTable"
        Style="font-size: small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
        BorderWidth="1px" ShowFooter="True" AutoGenerateColumns="False" 
        onrowdatabound="gvFixture_RowDataBound">
        <Columns>
      
            <asp:BoundField DataField="Limit_date" HeaderText="下次校驗日期" DataFormatString="{0:yyyy/MM/dd}" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
        <asp:BoundField DataField="Assts_no" HeaderText="標籤代碼" DataFormatString="">
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

            <asp:BoundField DataField="Place_Assets_sn" HeaderText="儲位代碼">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
              <asp:BoundField DataField="Assts_eq_id" HeaderText="資產管制編號">
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
    &nbsp;&nbsp;&nbsp;&nbsp;共<asp:Label ID="lbTOtal" runat="server" Text="0"></asp:Label>筆資料
    </form>
</body>
</html>