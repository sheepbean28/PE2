<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuppliesEdit.aspx.cs" Inherits="PE2.Supplies.SuppliesEdit" %>

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
        var EditConfirm;
        function refresh() {
            window.parent.CloseAndreFresh();
        }
        function OpenEditDialog(val, change) 
        {
            if ($("#hfSupplies_sn").val() == 0) {
                if (EditConfirm) {
                    EditConfirm = $.ligerDialog.open({ height: 500, url: 'SuppliesCheck.aspx?Name=' + $("#tbSupplies_Name").val() + '&change=' + change, width: 600, title: '' });
                }
                else {
                    EditConfirm = $.ligerDialog.open({ height: 500, url: 'SuppliesCheck.aspx?Name=' + $("#tbSupplies_Name").val() + '&change=' + change, width: 600, title: '' });
                }
                edit = null;
            }
            else {
                $("#btnConfirm").click();
            }
            return false;
        }
        function CloseAndSave() 
        {
            $("#btnConfirm").click();
        }
        function CloseAndCancel() 
        {
            EditConfirm.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Scriptmanager1" runat="server">
    </asp:ScriptManager>
    <div>
        <fieldset>
            <legend>耗材管理</legend>
            <p>
                耗材基本資料
                <asp:HiddenField ID="hfSupplies_sn" runat="server" Value="0" />
                <asp:HiddenField ID="hfSupplies_no" runat="server" Value="0" />
                <asp:HiddenField ID="hfSupplies_Class" runat="server" Value="0" />

            </p>
            <div class="elements">
                <table>
                    <tr>
                        <td width="700">
                            <label for="question">
                                耗材代碼:</label>
                            <asp:DropDownList ID="ddlSupplies_Class" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlSupplies_Class_SelectedIndexChanged">
                                <asp:ListItem Value="01">線材</asp:ListItem>
                                <asp:ListItem Value="02">轉接頭</asp:ListItem>
                                <asp:ListItem Value="03">轉接板</asp:ListItem>
                                <asp:ListItem Value="04">其他</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="tbSupplies_C_No" required runat="server" Width="" 
                                Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="elements">
                <table>
                    <tr>
                        <td width="700">
                            <label for="question">
                                耗材名稱:</label>
                            <asp:TextBox ID="tbSupplies_Name" required runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="elements">
                <table>
                    <tr>
                        <td width="700">
                            <label for="question">
                                價格:</label>
                            <asp:TextBox ID="tbSupplies_Price" type="number" Width="60" runat="server">0</asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="elements">
                <table>
                    <tr>
                        <td width="700">
                            <label for="question">
                                入庫數量:</label>
                            <asp:TextBox ID="tbSupplies_Add" required type="number" Width="60" runat="server">0</asp:TextBox>
                        &nbsp;
                            <asp:Label ID="lbStock" runat="server" Text="庫存數量"></asp:Label>
&nbsp;
                            <asp:TextBox ID="tbSupplies_Stock" required type="number" Width="60" 
                                runat="server">0</asp:TextBox>
                             <asp:Label ID="lbPlace" runat="server" Text="存放位置"></asp:Label>
                            <asp:DropDownList ID="ddlPlace_code_sn" runat="server" DataTextField="Code_name"  DataValueField="Code_sn"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="elements">
                <table>
                    <tr>
                        <td width="700">
                            <label for="question">
                                庫存數量警告:</label>
                            警告:<asp:TextBox ID="tbSupplies_Warm" required type="number" Width="60" runat="server">3</asp:TextBox>
                            不足:<asp:TextBox ID="tbSupplies_Limit" required type="number" Width="60" runat="server">2</asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="elements">
                <label for="question">
                    說明:</label>
                <asp:TextBox ID="tbNote" runat="server" Height="15px" TextMode="MultiLine" Width="330px"></asp:TextBox>
            </div>
            <div class="elements">
                <label for="question">
                    是否購買:</label>
                <asp:CheckBox ID="cbValid" runat="server" Checked="True" />
            </div>
            <div class="elements">
                <label for="question">
                    圖片:</label>
                <asp:Image ID="imgUpload" runat="server" ImageUrl="~/Images/Supplies/image_4.png"
                    Width="75" Height="75" />
                <asp:FileUpload ID="fileUpload" runat="server" />
                <asp:HiddenField ID="hfFilePath" runat="server" />
                &nbsp;<asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="上傳" />
            </div>
          <div class="submit">
                
                 <input id="btnDisplay" type="button" value="儲存" onclick="OpenEditDialog(0,0);" />
                <asp:Button ID="btnConfirm" runat="server" Text="儲存" OnClick="btnConfirm_Click" style="display:none;" />
                <%--<input id="btnConfirm" type="button" value="查詢" onclick="refresh()" />--%>
            </div>
        </fieldset>
    </div>
    </form>
</body>
</html>
