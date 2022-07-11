<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PICS.aspx.cs" Inherits="PE2.Supplies.PICS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<script src="../../PE2/Scripts/jquery-ui-1.11.4/external/jquery/jquery.js" type="text/javascript"></script>
<script src="../Scripts/ligerUI/js/ligerui.all.js" type="text/javascript"></script>
<script src="../../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.js" type="text/javascript"></script>
<link href="../../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../../PE2/Scripts/ligerUI/skins/Aqua/css/ligerui-dialog.css" rel="stylesheet"
    type="text/css" />
<link href="../Styles/Form.css" rel="stylesheet" type="text/css" />
<link href="../Styles/Item.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title></title>
    <script type="text/javascript">
        $(function () {
            if($("#imgUpload").width() > 600)
                $("#imgUpload").width(600)
            if ($("#imgUpload").height() > 400)
                $("#imgUpload").height(400)

        });
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hfSupplies_sn" runat="server" Value="0" />
    <asp:Image ID="imgUpload" runat="server" ImageUrl="~/Images/Supplies/image_4.png"
        OnPreRender="imgUpload_PreRender" />
    <div>
    </div>
    </form>
</body>
</html>
