<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalibrateTo.aspx.cs" Inherits="PE2.Assets.ToCalibrate" %>

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
        //將預設語系設定為中文
        $.datepicker.setDefaults($.datepicker.regional["zh-TW"]);

        $(function () {
            $("#tbStartEate").datepicker({ dateFormat: 'yy-mm-dd' });
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
                    <legend>儀器校驗</legend>
                    <p>
                        儀器送校<asp:HiddenField ID="hfCalibrate_sn" runat="server" />
                    </p>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="500">
                                    <label for="question">
                                        校驗日期:</label>&nbsp;
                                    <asp:TextBox ID="tbStartEate" runat="server" required CssClass="calendar" ></asp:TextBox>
                                    &nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlStatus" runat="server">
                                        <asp:ListItem Value="1">校驗</asp:ListItem>
                                        <asp:ListItem Value="2">送修</asp:ListItem>
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
                                <td width="500">
                                    <label for="question">
                                        備註:</label>&nbsp;
                                    <asp:TextBox ID="tbNote" TextMode="MultiLine" runat="server" Height="60px" 
                                        Width="300px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="submit">
                        <asp:Button ID="btnConfirm" runat="server" Text="儲存" OnClick="btnConfirm_Click" />
                        <%--<input id="btnConfirm" type="button" value="查詢" onclick="refresh()" />--%>
                    </div>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
