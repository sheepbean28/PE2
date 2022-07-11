<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FixtureOut.aspx.cs" Inherits="PE2.Fixture.FixtureOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<script src="../../PE2/Scripts/jquery-ui-1.11.4/external/jquery/jquery.js" type="text/javascript"></script>
<script src="../Scripts/ligerUI/js/ligerui.all.js" type="text/javascript"></script>
<script src="../../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.js" type="text/javascript"></script>
<script src="../../PE2/Scripts/gridviewScroll.min.js" type="text/javascript"></script>
<link href="../Scripts/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
<link href="../../PE2/Scripts/jquery-ui-1.11.4/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../Styles/Grid.css" rel="stylesheet" type="text/css" />
<link href="../Styles/Item.css" rel="stylesheet" type="text/css" />
<link href="../Scripts/GridviewScroll.css" rel="stylesheet" type="text/css" />
<link href="../Styles/Form.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var win1;

        $(function () {
            var height = ($(document).height() - 20);
            gridviewScroll();

        });

        function gridviewScroll() {
            var height = $(window).height();
            var width = $(window).width();

            gridView1 = $('#gvOutFixture').gridviewScroll({
                width: width,
                height: height - 260,
                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",
                freezesize: 4,
                arrowsize: 30,
                varrowtopimg: "../Images/arrowvt.png",
                varrowbottomimg: "../Images/arrowvb.png",
                harrowleftimg: "../Images/arrowhl.png",
                harrowrightimg: "../Images/arrowhr.png",
                headerrowcount: 2,
                railsize: 16,
                barsize: 8
            });
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <fieldset>
            <legend>治具管理</legend>
            <p>
                借出治具查詢</p>
            <div class="elements">
                <label for="question">
                    編號查詢:</label>&nbsp;<asp:TextBox ID="txtFixture_no" runat="server"></asp:TextBox>
                &nbsp;使用位置:
                <asp:DropDownList ID="ddlPlace_sn" DataTextField="Place_name" DataValueField="Place_sn"
                    runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlace_sn_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;<asp:DropDownList ID="ddlPlace_sn1" DataTextField="Place_name" DataValueField="Place_sn"
                    runat="server">
                </asp:DropDownList>
            </div>
            <div class="elements">
                <table>
                    <tr>
                        <td>
                            <label for="question">
                                使用目的:</label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlOutStatus" runat="server">
                                <asp:ListItem Text="架站使用" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="外借使用" Value="2"></asp:ListItem>
                                <asp:ListItem Text="治具送修" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="elements">
                <label for="question">
                    說明:</label>
                <asp:TextBox ID="txtNote" runat="server" Height="47px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                &nbsp;<asp:Button ID="btnConfirm" runat="server" Text="新增借出" CssClass="enjoy-css"
                    OnClick="btnConfirm_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="enjoy-css" OnClick="btnSave_Click" />
            </div>
            <div class="submit">
                <%--<input id="btnConfirm" type="button" value="查詢" onclick="refresh()" />--%>
            </div>
        </fieldset>
        <asp:GridView ID="gvOutFixture" runat="server" CellPadding="3" CssClass="EU_DataTable"
            Style="font-size: small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
            BorderWidth="1px" ShowFooter="True" AutoGenerateColumns="False" OnRowCommand="gvOutFixture_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="功能">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <%--<asp:LinkButton ID="btnUpdate" runat="server" CommandName="RowUpdate" CommandArgument='<%# Eval("Fixture_no") %>'  >修改</asp:LinkButton>--%>
                        &nbsp;<asp:LinkButton ID="btnDelete" runat="server" CommandName="RowDelete" CommandArgument='<%# Eval("Fixture_no") %>'>刪除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Place_name" HeaderText="存放位置">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Note" HeaderText="說明">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Fixture_no" HeaderText="治具代碼" DataFormatString="">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Fixture_car" HeaderText="治具位置">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Fixture_car1" HeaderText="車次">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Fixture_car2" HeaderText="位置">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Fixture_name" HeaderText="治具名稱">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Fixture_usefor" HeaderText="治具用途">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Status" HeaderText="治具狀態">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Quantity" HeaderText="數量">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Limit_date" HeaderText="使用期限" DataFormatString="{0:yyyy/MM/dd}">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" ForeColor="White" Font-Bold="True" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
