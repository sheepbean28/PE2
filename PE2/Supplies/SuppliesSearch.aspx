<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuppliesSearch.aspx.cs"
    Inherits="PE2.Supplies.SuppliesSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="../../PE2/Scripts/jquery-ui-1.11.4/external/jquery/jquery.js" type="text/javascript"></script>
    <script src="../Scripts/ligerUI/js/ligerui.all.js" type="text/javascript"></script>
    <script src="../../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.js" type="text/javascript"></script>
    <link href="../../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../PE2/Scripts/ligerUI/skins/Aqua/css/ligerui-dialog.css" rel="stylesheet"
        type="text/css" />
    <link href="../Styles/Form.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Item.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script type="text/javascript">
        $.datepicker.regional['zh-TW'] = {
            dayNames: ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"],
            dayNamesMin: ["日", "一", "二", "三", "四", "五", "六"],
            monthNames: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
            monthNamesShort: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
            prevText: "上月",
            nextText: "次月",
            weekHeader: "週"
        };
        $.datepicker.setDefaults($.datepicker.regional["zh-TW"]);
        $(function () {
            $("#tbStartDate").datepicker({ dateFormat: 'yy-mm-dd' });
            $("#tbEndDate").datepicker({ dateFormat: 'yy-mm-dd' });

            $("#tbReturnStartDate").datepicker({ dateFormat: 'yy-mm-dd' });
            $("#tbReturnEndDate").datepicker({ dateFormat: 'yy-mm-dd' });
        });

        function refresh() {
            window.parent.CloseAndreFresh();
        }
    </script>
</head>
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
                            耗材列表查詢
                        </p>
                        <div class="elements">
                            <table>
                                <tr>
                                    <td width="400">
                                        <label for="question">
                                            物品條碼:</label><asp:TextBox ID="txtSupplies_no" runat="server" Width="100"></asp:TextBox>
                                    </td>
                                    <td>
                                        <label for="question">
                                            品名:</label>
                                        <asp:TextBox ID="txtSupplies_Name" runat="server" Width="100"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="elements">
                            <table>
                                <tr>
                                    <td width="400">
                                        <label for="question">
                                            類別:</label><asp:DropDownList ID="ddlSupplies_Class" runat="server">
                                                <asp:ListItem Value="-1">所有</asp:ListItem>
                                                <asp:ListItem Value="01">線材</asp:ListItem>
                                                <asp:ListItem Value="02">轉接頭</asp:ListItem>
                                                <asp:ListItem Value="03">轉接板</asp:ListItem>
                                                <asp:ListItem Value="04">其他</asp:ListItem>
                                            </asp:DropDownList>
                                    </td>
                                    <td>
                                        <label for="question">
                                            庫存數量:</label>
                                        <asp:TextBox ID="txtStockStart" runat="server" Width="55px"></asp:TextBox>
                                        ~<asp:TextBox ID="txtStockEnd" runat="server" Width="55px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="elements">
                            <table>
                                <tr>
                                    <td width="400">
                                        <label for="question">
                                            庫存狀態:</label>
                                        <asp:DropDownList ID="ddlStatus" runat="server">
                                            <asp:ListItem Value="-1">所有</asp:ListItem>
                                            <asp:ListItem Value="1">庫存充足</asp:ListItem>
                                            <asp:ListItem Value="2">庫存即將不足</asp:ListItem>
                                            <asp:ListItem Value="3">庫存不足</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>

                                    <td>
                                        <label for="question">
                                            是否使用:</label>
                                        <asp:DropDownList ID="ddlValid" runat="server">
                                            <asp:ListItem Value="-1">所有</asp:ListItem>
                                            <asp:ListItem Value="1" Selected="True">使用中</asp:ListItem>
                                            <asp:ListItem Value="0">已停用</asp:ListItem>

                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                </table>
                        </div>
                        
                        <div class="elements">
                            <label for="question">
                                備註:</label>
                            &nbsp;<asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" Width="529px"></asp:TextBox>
                        </div>
                        <div class="elements">
                            <label for="question">
                                存放位置:</label>
                            <asp:DropDownList ID="ddlPlace_sn" runat="server" DataTextField="Code_name" DataValueField="Code_sn"></asp:DropDownList>

                        </div>
                        <div class="submit">
                            <asp:Button ID="btnConfirm" runat="server" Text="查詢" OnClick="btnConfirm_Click" />
                            <%--<input id="btnConfirm" type="button" value="查詢" onclick="refresh()" />--%>
                        </div>
                    </fieldset>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
