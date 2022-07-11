<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalibrateEdit.aspx.cs"
    Inherits="PE2.Assets.EditCalibation" %>

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
                        資產修改<asp:HiddenField ID="hfCalibrate_sn" runat="server" Value="0" />
                                <asp:HiddenField ID="hfAssets_sn" runat="server" />
                    </p>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        標籤代碼:</label>&nbsp;<asp:TextBox ID="txtAsset_no" runat="server" Width="100" 
                                        AutoPostBack="True" ontextchanged="txtAsset_no_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="question">
                                        資產管制名稱:</label>
                                    <asp:TextBox ID="txtAssts_eq_name" runat="server" Enabled="False"></asp:TextBox>
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
                                    <asp:TextBox ID="txtAssts_name" runat="server" Enabled="False"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="question">
                                        資產編號:</label>
                                    <asp:TextBox ID="txtAssts_id" runat="server" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        校驗位置:</label>
                                    <asp:DropDownList ID="ddlCp_place" runat="server" Style="width: 100px">
                                        <asp:ListItem>儀校室</asp:ListItem>
                                        <asp:ListItem>NI</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <label for="question">
                                        校驗方式:</label>
                                    <asp:DropDownList ID="ddlCp_type" runat="server" Style="width: 100px">
                                        <asp:ListItem Value="2">免校驗</asp:ListItem>
                                        <asp:ListItem Value="0">內校驗</asp:ListItem>
                                        <asp:ListItem Value="1">外校驗</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                        校驗週期:</label>
                                    <asp:DropDownList ID="ddlCp_Date_Range" runat="server" Style="width: 100px">
                                        <asp:ListItem Value="6">六個月</asp:ListItem>
                                        <asp:ListItem Value="12">一年</asp:ListItem>
                                        <asp:ListItem Value="24">兩年</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <label for="question">
                                        校驗編號:</label>
                                    <asp:TextBox ID="tbEq_id" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <label for="question">
                            說明:</label>
                        <asp:TextBox ID="txtCp_Note" runat="server" Height="15px" TextMode="MultiLine" Width="330px"></asp:TextBox>
                    </div>
                    <div class="elements">
                        <label for="question">
                            設備說明:</label>
                        <asp:TextBox ID="txtCp_Note1" runat="server" Height="15px" TextMode="MultiLine" 
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
