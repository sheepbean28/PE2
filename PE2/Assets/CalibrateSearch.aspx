<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalibrateSearch.aspx.cs" Inherits="PE2.Assets.CalibrateSearch" %>

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
                    <legend>資產管理</legend>
                    <p>
                        資產列表查詢</p>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        位置:</label>&nbsp;
                                    <asp:DropDownList ID="ddlPlace_sn" DataTextField="Place_name" DataValueField="Place_sn"
                                        runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlace_sn_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    &nbsp;<asp:DropDownList ID="ddlPlace_sn1" DataTextField="Place_name" DataValueField="Place_sn"
                                        runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                  <label for="question">
                                        標籤代碼:</label>
                                    <asp:TextBox ID="txtAsset_no" runat="server" Width="100"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        儲位代碼:</label>
                                    <asp:TextBox ID="txtPlace_Assets_sn" runat="server" Width="100"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="question">
                                        關聯儲位</label>
                                    <asp:TextBox ID="txtPlace_Assets_Detail_sn" runat="server" Width="100"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        站體功能:</label>
                                    <asp:DropDownList ID="ddlAssts_Station" runat="server" DataTextField="Assts_Station"
                                        DataValueField="Assts_Station">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <label for="question">
                                        客戶:</label>
                                    <asp:TextBox ID="txtCustomer" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        資產編號:</label>
                                    <asp:TextBox ID="txtAssts_id" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="question">
                                        設備序號:</label>
                                    <asp:TextBox ID="txtAssts_eq_id" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        資產名稱:</label>
                                    <asp:TextBox ID="txtAssts_name" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="question">
                                        資產管制名稱:</label>
                                    <asp:TextBox ID="txtAssts_eq_name" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        上次校驗時間</label><asp:TextBox ID="tbReturnStartDate" runat="server" 
                                        CssClass="calendar" ></asp:TextBox>
                                    &nbsp;~
                                    <asp:TextBox ID="tbReturnEndDate" runat="server" CssClass="calendar" ></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <label for="question">
                            下次校驗時間:</label>
                        <asp:TextBox ID="tbStartDate" runat="server" CssClass="calendar" ></asp:TextBox>
                        &nbsp;~
                        <asp:TextBox ID="tbEndDate" runat="server" CssClass="calendar" ></asp:TextBox>
                    </div>
                       <div class="elements">
                        <label for="question">
                            校驗狀態:</label>
                           <asp:DropDownList ID="ddlStatus" runat="server">
                               <asp:ListItem Value="-1" >所有</asp:ListItem>
                               <asp:ListItem Value="1" >已送回</asp:ListItem>
                               <asp:ListItem Value="2" >校驗中</asp:ListItem>
                               <asp:ListItem Value="3" >送修中</asp:ListItem>
                           </asp:DropDownList>
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
