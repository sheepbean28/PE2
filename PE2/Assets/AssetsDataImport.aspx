<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetsDataImport.aspx.cs"
    Inherits="PE2.Assets.AssetsDataImport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../../PE2/Scripts/jquery-ui-1.11.4/external/jquery/jquery.js" type="text/javascript"></script>
    <script src="../Scripts/ligerUI/js/ligerui.all.js" type="text/javascript"></script>
    <script src="../../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.js" type="text/javascript"></script>
    <link href="../../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../PE2/Scripts/ligerUI/skins/Aqua/css/ligerui-dialog.css" rel="stylesheet"
        type="text/css" />
    <link href="../Styles/Form.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Item.css" rel="stylesheet" type="text/css" />
    <title>資料上傳</title>
    <script type="text/javascript">
        function refresh() {
            window.parent.CloseAndreFresh();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
 
            <div>
                <fieldset>
                    <legend>資產管理</legend>
                    <p>資產資料上傳</p>
                    <div class="elements">
                        <table>
                            <tr>
                                <td width="400">
                                    <label for="question">
                                    檔案上傳:
                                    </label>
                                    <asp:FileUpload ID="fuUpload" runat="server" />
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="submit">
                        <asp:Button ID="btnConfirm" runat="server" Text="上傳" OnClick="btnConfirm_Click" />
                    </div>
                </fieldset>
            </div>
    </form>
</body>
</html>
