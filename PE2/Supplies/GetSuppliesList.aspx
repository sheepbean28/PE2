<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetSuppliesList.aspx.cs"
    Inherits="PE2.Supplies.GetSuppliesList" %>

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
    <link href="../Styles/Form.css" rel="stylesheet" type="text/css" />
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
        }

    }
    function OpenEditDialog(val, change) {
        if (edit) {
            edit = $.ligerDialog.open({ height: 620, url: 'AssetsEdit.aspx?Mode=' + val + '&change=' + change, width: 800, title: '' });
        }
        else {
            edit = $.ligerDialog.open({ height: 620, url: 'AssetsEdit.aspx?Mode=' + val + '&change=' + change, width: 800, title: '' });
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
            height: (height - 120) / 2,
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
    <asp:ScriptManager ID="Scriptmanager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <fieldset>
                    <legend>耗材管理</legend>
                    <p>
                        耗材列表查詢</p>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        異動原因:</label><asp:DropDownList ID="ddlStatus" runat="server">
                                            <asp:ListItem Value="1">耗材領用</asp:ListItem>
                                            <asp:ListItem Value="2">耗材退庫</asp:ListItem>
                                            <asp:ListItem Value="3">外單位借出</asp:ListItem>
                                            <asp:ListItem Value="4">外單位歸還</asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        物品條碼:</label><asp:TextBox ID="txtSupplies_no" runat="server" Width="100" AutoPostBack="True"></asp:TextBox>
                                    &nbsp;<asp:DropDownList ID="ddlPlace_sn" runat="server" DataTextField="Code_name"  DataValueField="Code_sn" AutoPostBack="True" OnSelectedIndexChanged="ddlPlace_sn_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" 
                                        Text="查詢" />
                                </td>
                                <td>
                                    <label for="question">
                                        品名:</label>
                                    <asp:Label ID="lbSupplies_Name" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        類別:</label><asp:DropDownList ID="ddlSupplies_Class" runat="server" Enabled="False">
                                            <asp:ListItem Value="-1">所有</asp:ListItem>
                                            <asp:ListItem Value="01">線材</asp:ListItem>
                                            <asp:ListItem Value="02">轉接頭</asp:ListItem>
                                            <asp:ListItem Value="03">轉接板</asp:ListItem>
                                            <asp:ListItem Value="04">其他</asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                                <td>
                                    <label for="question">
                                        異動數量:</label>
                                    <asp:TextBox ID="txtStockStart" runat="server" Width="55px">0</asp:TextBox>
                                    &nbsp;(庫存數量:
                                    <asp:Label ID="lbStock" runat="server"></asp:Label>
                                    &nbsp;<asp:Label ID="lbStockLevel" runat="server"></asp:Label>
                                    &nbsp;)
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <label for="question">
                            備註:</label>
                        &nbsp;<asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" Width="529px"></asp:TextBox>
                    </div>
                    <div class="submit">
                        <%--<input id="btnConfirm" type="button" value="查詢" onclick="refresh()" />--%>
                    </div>
                </fieldset>
            </div>
            <div style="text-align: left">
            <asp:Button ID="btnSave" runat="server" Text="儲存" class="enjoy-css" 
                    onclick="btnSave_Click"  />
                &nbsp;共<asp:Label ID="lbCount" runat="server" Text="0"></asp:Label>筆資料
            </div>
            <asp:GridView ID="gvList" runat="server" CellPadding="3" CssClass="EU_DataTable"
                Style="font-size: small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                BorderWidth="1px" ShowFooter="True" AutoGenerateColumns="False" OnRowDataBound="gvList_RowDataBound"
                AllowPaging="True" PageSize="40" 
                OnPageIndexChanging="gvList_PageIndexChanging" onrowcommand="gvList_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="功能">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="RowUpdate" CommandArgument='<%# Eval("Supplies_no") %>' >修改</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="RowDelete" CommandArgument='<%# Eval("Supplies_no") %>' >刪除</asp:LinkButton>
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
                      <asp:BoundField DataField="StatusName" HeaderText="作業項目">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GetQuantity" HeaderText="數量">
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
                            <asp:Label ID="lbStock" runat="server" Text='<%# Bind("Supplies_Stock") %>' Visible="false"></asp:Label>
                            <asp:Label ID="lbResult" runat="server" Text="庫存充足"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="GetNote" HeaderText="備註">
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
