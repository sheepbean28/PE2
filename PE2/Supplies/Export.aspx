<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="PE2.Supplies.Export" %>

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
      
    </script>
    <style>
        .chkboxlist td
        {
            color: Black;
            font-weight: bold;
            border-width: 2px;
            border-color: Black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Scriptmanager1" runat="server">
    </asp:ScriptManager>
    <div>
        <fieldset>
            <legend>耗材管理</legend>
            <p>
                匯出資料
            </p>
            
                <asp:CheckBoxList ID="cbLColnums" runat="server" RepeatColumns="5" 
                    CssClass="chkboxlist" CellSpacing="5" TextAlign="Left">
                    <asp:ListItem Value="Supplies_File">    圖片:</asp:ListItem>
                    <asp:ListItem Value="Supplies_no">    條碼編號:</asp:ListItem>
                    <asp:ListItem Value="Supplies_Name">    名稱:</asp:ListItem>
                    <asp:ListItem Value="Supplies_Price">    價格:</asp:ListItem>
                    <asp:ListItem Value="Supplies_Add">    入庫數量:</asp:ListItem>
                    <asp:ListItem Value="Supplies_In">    退庫:</asp:ListItem>
                    <asp:ListItem Value="Supplies_Out">    領用:</asp:ListItem>
                    <asp:ListItem Value="Supplies_R_IN"    >歸還:</asp:ListItem>
                    <asp:ListItem Value="Supplies_R_OUT">    外借:</asp:ListItem>
                    <asp:ListItem Value="Supplies_Limit">    不足:</asp:ListItem>
                    <asp:ListItem Value="Supplies_Warm">    警告:</asp:ListItem>
                    <asp:ListItem Value="Supplies_Stock">    庫存:</asp:ListItem>
                    <asp:ListItem Value="Note">    備註:</asp:ListItem>
                </asp:CheckBoxList>
            
            <div class="submit">
                &nbsp;<asp:Button ID="btnConfirm" runat="server" Text="匯出" OnClick="btnConfirm_Click" />
            </div>
        </fieldset>
    </div>
    </form>
</body>
</html>
