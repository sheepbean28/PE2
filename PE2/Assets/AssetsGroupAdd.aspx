<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetsGroupAdd.aspx.cs"
    Inherits="PE2.Assets.AssetsGroupAdd" %>

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
    <style type="text/css">
        .EU_DataTable
        {
            border-collapse: collapse;
            width: 100%;
        }
        .EU_DataTable tr th
        {
            background-color: #3c454f;
            color: #ffffff;
            padding: 10px 5px 10px 5px;
            border: 1px solid #cccccc;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: normal;
            text-transform: capitalize;
        }
        .GridPager a
        {
            background-color: #f5f5f5;
            color: #969696;
            border: 1px solid #969696;
        }
    </style>
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
                        資產新增<asp:HiddenField ID="hfAssets_sn" runat="server" />
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
                                    &nbsp;<asp:DropDownList ID="ddlPlace_sn1" required DataTextField="Place_name" DataValueField="Place_sn"
                                        runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <label for="question">
                                        標籤代碼:</label>
                                    <asp:TextBox ID="txtAsset_no" required  runat="server" Width="100"></asp:TextBox>
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
                                    <asp:DropDownList ID="ddlAssts_Station" required runat="server" DataTextField="Assts_Station"
                                        Style="width: 100px" DataValueField="Assts_Station" AutoPostBack="True" OnSelectedIndexChanged="ddlAssts_Station_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtAssts_Station" required runat="server"></asp:TextBox>
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
                                    <asp:TextBox ID="txtAssts_name" required runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="question">
                                        資產管制名稱:</label>
                                    <asp:TextBox ID="txtAssts_eq_name" required runat="server"></asp:TextBox>
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
                                    <asp:TextBox ID="txtQuantity" type="number" required Width="60" runat="server">0</asp:TextBox>
                                </td>
                                <td>
                                    <label for="question">
                                        站體數量:</label>
                                    <asp:TextBox ID="txtAssts_Station_num" type="number" Width="60" runat="server">0</asp:TextBox>
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
                    <div class="elements">
                        <asp:Button ID="btnConfirm0" runat="server" Text="新增" OnClick="btnConfirm_Click"
                            CssClass="enjoy-css" />
                        &nbsp;
                        <asp:Button ID="btnSave"  formnovalidate runat="server" CssClass="enjoy-css" OnClick="btnSave_Click"
                            Text="儲存" />
                        <%--<input id="btnConfirm" type="button" value="查詢" onclick="refresh()" />--%>
                    </div>
                    <div class="elements">
                        <asp:GridView ID="gvAssets" runat="server" AutoGenerateColumns="False" BackColor="White"
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="EU_DataTable"
                            PageSize="40" ShowFooter="True" Style="font-size: small" 
                            onrowcommand="gvAssets_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="功能">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <%--<asp:LinkButton ID="btnUpdate" runat="server" CommandName="RowUpdate" CommandArgument='<%# Eval("Fixture_no") %>'  >修改</asp:LinkButton>--%>
                                        &nbsp;<asp:LinkButton ID="btnDelete" runat="server" CommandName="RowDelete" CommandArgument='<%# Eval("Assts_no") %>'>刪除</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Assts_no" DataFormatString="" HeaderText="標籤代碼">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Assts_id" HeaderText="資產編號">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Assts_name" HeaderText="資產名稱">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Assts_eq_id" HeaderText="資產管制編號">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Assts_eq_name" HeaderText="資產管制名稱">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Place_name" HeaderText="存放位置">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Assts_Quantity" HeaderText="數量">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Assts_Customer" HeaderText="客戶">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Place_sn" HeaderText="所在位置">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Place_Assets_sn" HeaderText="儲位代碼">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Place_Assets_Detail_sn" HeaderText="關聯儲位">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Assts_Station" HeaderText="測試站別">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Note" HeaderText="備註">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SysNote" HeaderText="系統備註">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <PagerStyle CssClass="GridPager" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
