<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetsEdit.aspx.cs" Inherits="PE2.Assets.AssetsEdit" %>

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
                        資產修改<asp:HiddenField ID="hfAssets_sn" runat="server" />
                    </p>
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
                                    <asp:DropDownList ID="ddlAssts_Station" runat="server" DataTextField="Assts_Station" style="width:100px"
                                        DataValueField="Assts_Station" AutoPostBack="True" 
                                        onselectedindexchanged="ddlAssts_Station_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtAssts_Station" runat="server"></asp:TextBox>
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
                                        數量:</label>
                                    <asp:TextBox ID="txtQuantity" type="number" Width="60" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="question">
                                        站體數量:</label>
                                    <asp:TextBox ID="txtAssts_Station_num" type="number" Width="60" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="elements">
                        <label for="question">
                            說明:</label>
                        <asp:TextBox ID="txtNote" runat="server" Height="15px" TextMode="MultiLine" Width="330px"></asp:TextBox>
                    </div>
                    <div class="elements">
                        <label for="question">
                            管理人員說明:</label>
                        <asp:TextBox ID="txtSysNote" runat="server" Height="15px" TextMode="MultiLine" Width="330px"></asp:TextBox>
                    </div>
                    <div class="submit">
                        <asp:Button ID="btnConfirm" runat="server" Text="儲存" 
                            OnClick="btnConfirm_Click" />
                        <%--<input id="btnConfirm" type="button" value="查詢" onclick="refresh()" />--%>
                    </div>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
