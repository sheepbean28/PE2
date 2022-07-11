<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuppliesCheck.aspx.cs"
    Inherits="PE2.Supplies.SuppliesCheck" %>

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
    var result = false;

    $(function () {
        var height = ($(document).height() - 20);
        //  gridviewScroll();

    });


    function gridviewScroll() {
        var height = 200;
        var width = 580;
        gridView1 = $('#gvList').gridviewScroll({
            width: width,
            height: height,
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

    
    
</script>
<body>
    <form id="form1" runat="server">

    找到類似的庫存<br />

    <asp:GridView ID="gvList" runat="server" CellPadding="3" CssClass="EU_DataTable"
        Style="font-size: small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
        BorderWidth="1px" ShowFooter="True" AutoGenerateColumns="False" OnRowDataBound="gvList_RowDataBound"
        AllowPaging="True" PageSize="40" OnPageIndexChanging="gvList_PageIndexChanging"
        OnPreRender="gvList_PreRender">
        <Columns>
            <asp:TemplateField HeaderText="圖片">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Supplies_File") %>' Width="50"
                        Height="50" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
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
            <asp:BoundField DataField="Supplies_Stock" HeaderText="庫存數量">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
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
    <asp:Button ID="btnConfirm"  class="enjoy-css" runat="server" Text="繼續儲存" 
        onclick="btnConfirm_Click" />
    &nbsp;<asp:Button ID="btnCancel" class="enjoy-css" runat="server" Text="取消" 
        onclick="btnCancel_Click" />
    <br />
    </form>
</body>
</html>
