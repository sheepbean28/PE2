<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FixtureLimit.aspx.cs" Inherits="PE2.Fixture.FixtureLimit1" %>

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
        gridView1 = $('#gvFixture').gridviewScroll({
            width: width + 15,
            height: height - 20,
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
    function IsUpdate(val) {
        $.ligerDialog.confirm("確定延長使用年限嗎", function (yes) {
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

</script>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="gvFixture" runat="server" CellPadding="3" CssClass="EU_DataTable"
        Style="font-size: small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
        BorderWidth="1px" ShowFooter="True" AutoGenerateColumns="False" 
        onrowdatabound="gvFixture_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="年限">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                   <asp:LinkButton ID="btnConfirm" runat="server" CommandName="RowDelete" CommandArgument='<%# Eval("Fixture_no") %>'
                   OnClientClick='<%# @"return IsUpdate("""+ Eval("Fixture_sn") + @""");" %>' >延長</asp:LinkButton>
                   
                </ItemTemplate>
                 <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:TemplateField>
            <asp:BoundField DataField="Fixture_no" HeaderText="治具代碼" DataFormatString="">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
             <asp:BoundField DataField="Fixture_name" HeaderText="治具名稱">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
           <%-- <asp:BoundField DataField="Place_name" HeaderText="出借位置">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>--%>
            <asp:BoundField DataField="Create_date" HeaderText="收到日期" DataFormatString="{0:yyyy/MM/dd}">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Limit_date" HeaderText="到期日期" DataFormatString="{0:yyyy/MM/dd}">
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
