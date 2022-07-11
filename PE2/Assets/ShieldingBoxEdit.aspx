<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShieldingBoxEdit.aspx.cs" Inherits="PE2.Assets.ShieldingBoxEdit" %>

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
            $("#txtCp_date").datepicker({ dateFormat: 'yy-mm-dd' });
            $("#txtLimit_date").datepicker({ dateFormat: 'yy-mm-dd' });
        });
        function refresh() {
            window.parent.CloseAndreFresh();
        }
    </script>
    <style type="text/css">
        .style1
        {
            height: 26px;
        }
        .auto-style1 {
            width: 400px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Scriptmanager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <fieldset>
                    <legend>隔離箱管理</legend>
                    <p>
                        隔離箱校驗<asp:HiddenField ID="hfShieldingBox_sn" runat="server" Value="0" />
                        <asp:HiddenField ID="hfAssets_sn" runat="server" />
                    </p>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        標籤代碼:</label>&nbsp;<asp:TextBox ID="txtAsset_no" runat="server" Width="100" AutoPostBack="True"
                                            OnTextChanged="txtAsset_no_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="question">
                                        資產管制名稱:</label>
                                    <asp:TextBox ID="txtAssts_eq_name" runat="server" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
<%--                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        類別:</label>
                                    <asp:TextBox ID="txtShieldingBox_Class" runat="server"  Width="100"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="question">
                                        型式:</label>
                                    <asp:TextBox ID="txtShieldingBox_Type" runat="server"  Width="100"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>--%>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        隔離度(2G開啟):</label>
                                    <asp:TextBox ID="txt2GOpen" runat="server" 
                                        OnTextChanged="txtAsset_no_TextChanged" Width="100" Text="-27" ></asp:TextBox>
                                </td>
                                <td>
                                    <label for="question">
                                        隔離度(2G關閉):</label>
                                    <asp:TextBox ID="txt2GClose" runat="server" 
                                        OnTextChanged="txtAsset_no_TextChanged" Width="100"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <table>
                            <tr>
                                <td class="auto-style1">
                                    <label for="question">
                                        隔離度(2G):</label>
                                    <asp:TextBox ID="txt2GShild" runat="server" 
                                        OnTextChanged="txt2GShild_TextChanged" Width="100" AutoPostBack="True"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        隔離度(5G開啟):</label>
                                    <asp:TextBox ID="txt5GOpen" runat="server" 
                                        OnTextChanged="txtAsset_no_TextChanged" Width="100" Text="-38"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="question">
                                        隔離度(5G關閉):</label>
                                    <asp:TextBox ID="txt5GClose" runat="server" 
                                        OnTextChanged="txtAsset_no_TextChanged" Width="100"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400" class="style1">
                                    <label for="question">
                                        隔離度(5G):</label>
                                    <asp:TextBox ID="txt5GShild" runat="server" 
                                        OnTextChanged="txt5GShild_TextChanged" Width="100" AutoPostBack="True"></asp:TextBox>
                                </td>
                                <td class="style1">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        校驗時間:</label>
                                    <asp:TextBox ID="txtCp_date" runat="server"  Width="100" CssClass="calendar"  ></asp:TextBox>
                                </td>
                                <td>
                                     <label for="question">
                                        下次校驗時間:</label>
                                    <asp:TextBox ID="txtLimit_date" runat="server"  Width="100" CssClass="calendar" ></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
     <%--               <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        漏電流:</label>
                                    <asp:TextBox ID="txtLeakage" runat="server" ></asp:TextBox>
                                </td>
                                <td>
                                    <label for="question">
                                        漏電流單位:</label>
                                    <asp:TextBox ID="txtLeakage_no" runat="server" ></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>--%>
                    <div class="elements">
                        <label for="question">
                            說明:</label>
                        <asp:TextBox ID="txtNote" runat="server" Height="15px" TextMode="MultiLine" 
                            Width="330px"></asp:TextBox>
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