<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="PE2.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script src="../PE2/Scripts/jquery-ui-1.11.4/external/jquery/jquery.js" type="text/javascript"></script>
<script src="../PE2/Scripts/ligerUI/js/ligerui.all.js" type="text/javascript"></script>
<script src="../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.js" type="text/javascript"></script>
<script src="../PE2/Scripts/gridviewScroll.min.js" type="text/javascript"></script>
<link href="../PE2/Scripts/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet"
    type="text/css" />
<link href="../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../PE2/Styles/Grid.css" rel="stylesheet" type="text/css" />
<link href="../PE2/Styles/Item.css" rel="stylesheet" type="text/css" />
<link href="../PE2/Scripts/GridviewScroll.css" rel="stylesheet" type="text/css" />
<link href="../PE2/Styles/Form.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        $(function () {
            $("#panel1-1").ligerPanel({
                title: '需校驗儀器列表',
                url: '../PE2/Assets/CalibrateLimit.aspx',
                width: 500,
                height: 300,
                left: 3,
                top: 5
            });
            $("#panShieldingBox").ligerPanel(
            {

                title: '需校驗隔離箱列表',
                url: '../PE2/Assets/ShieldingBoxLimit.aspx',
                width: 500,
                height: 300,
                left: '3px'
            });
            //$("#panel2").ligerPanel({
            //    title: '尚未歸還治具列表',
            //    width: 500,
            //    height: 300,
            //    url: '../PE2/Fixture/FixtureOutLimit.aspx',
            //    left: '3px'
            //});
            //$("#panFixtureLimit").ligerPanel({
            //    title: '治具到期提醒',
            //    width: 500,
            //    height: 300,
            //    url: '../PE2/Fixture/FixtureLimit.aspx',
            //    left: '3px'
            //});
            $("#panSuppliesList").ligerPanel({
                title: '耗材不足提醒',
                width: 500,
                height: 300,
                url: '../PE2/Supplies/SuppliesLimit.aspx',
                left: '3px'
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
           <%-- <tr>
                <td>
                    <div id="panel2" style="margin-top: 10px; clear: both;">
                    </div>
                </td>
                <td>
                    <asp:Panel ID="panFixtureLimit" style="margin-top: 10px;" runat="server">
                    </asp:Panel>
                </td>
            </tr>--%>
            <tr>
                <td>
                    <asp:Panel ID="panShieldingBox"  runat="server" Style="float: left; margin-left: 10px;margin-top: 10px;">
                    </asp:Panel>
                </td>
                <td>
                    <div id="panel1-1" style="float: left;margin-top: 10px;">
                    </div>
                </td>
                <tr>
                    <td>
                        <asp:Panel ID="panSuppliesList" runat="server" Style="float: left; margin-left: 10px; margin-top: 10px;">
                        </asp:Panel>
                    </td>
                    <td>
                    </td>
                </tr>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
