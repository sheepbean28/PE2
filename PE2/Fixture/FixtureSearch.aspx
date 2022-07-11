<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FixtureSearch.aspx.cs"
    Inherits="PE2.Fixture.FixtureSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../Styles/Form.css" rel="stylesheet" type="text/css" />
    <title></title>
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
            <legend>治具管理</legend>
            <p>
                治具列表查詢</p>
            <div class="elements">
                <label for="question">
                    編號查詢:</label>&nbsp;<asp:TextBox ID="txtFixture_no" runat="server"></asp:TextBox>
            </div>
            <div class="elements">
                <label for="question">
                    治具位置:</label>
                <asp:DropDownList ID="ddlFixture_car" runat="server">
                </asp:DropDownList>
                &nbsp;<asp:DropDownList ID="ddlFixture_car2" runat="server">
                    <asp:ListItem Value="">所有</asp:ListItem>
                    <asp:ListItem Value="0">第0層</asp:ListItem>
                    <asp:ListItem Value="1">第1層</asp:ListItem>
                    <asp:ListItem Value="2">第2層</asp:ListItem>
                    <asp:ListItem Value="3">第3層</asp:ListItem>
                    <asp:ListItem Value="4">第4層</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:DropDownList ID="ddlFixture_car3" runat="server">
                    <asp:ListItem Value="">所有</asp:ListItem>
                    <asp:ListItem Value="Ⅰ">I</asp:ListItem>
                    <asp:ListItem Value="Ⅱ">Ⅱ</asp:ListItem>
                    <asp:ListItem Value="Ⅲ">Ⅲ</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="elements">
                <label for="question">
                    治具名稱:</label>
                <asp:TextBox ID="txtFixture_name" runat="server"></asp:TextBox>
            </div>
            <div class="elements">
                <label for="question">
                    庫存狀態:</label>
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Value="-1">所有</asp:ListItem>
                    <asp:ListItem Value="1">在庫</asp:ListItem>
                    <asp:ListItem Value="2">報廢</asp:ListItem>
                    <asp:ListItem Value="3">轉出</asp:ListItem>
                    <asp:ListItem Value="0">已領出</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="elements">
                <label for="question">
                    用途:</label>
                <asp:DropDownList ID="ddlFixture_usefor" DataTextField="Fixture_usefor" DataValueField="Fixture_usefor"
                    runat="server">
                </asp:DropDownList>
            </div>
            <div class="submit">
                <asp:Button ID="btnConfirm" runat="server" Text="查詢" OnClick="btnConfirm_Click" />
                <%--<input id="btnConfirm" type="button" value="查詢" onclick="refresh()" />--%>
            </div>
        </fieldset>
    </div>
    </form>
</body>
</html>
