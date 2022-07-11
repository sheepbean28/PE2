<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetsGroupChange.aspx.cs"
    Inherits="PE2.Assets.AssetsGroupChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <title></title>
    <script type="text/javascript">
        var win1;

        $(function () {
            var height = ($(document).height() - 20);
            gridviewScroll();
            $("#txtAsset_no_Detail").keypress(function (event) {

                if (event.keyCode == 13) 
                {

               

                }

            });

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
            <legend>資產群組綁定</legend>
            <p>
                儲存位置</p>
            <div class="elements">
                <label for="question">
                    儲位查詢:</label>&nbsp;<asp:TextBox ID="txtAssets_no" runat="server" AutoPostBack="True"
                        OnTextChanged="txtAssets_no_TextChanged"></asp:TextBox>
                &nbsp;</div>
            <div class="elements">
                <asp:GridView ID="gvTable" runat="server" CellPadding="3" CssClass="EU_DataTable"
                    Style="font-size: small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                    BorderWidth="1px" ShowFooter="True" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Assts_no" HeaderText="儲位桌號" DataFormatString="">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Assts_eq_name" HeaderText="資產管制名稱">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Assts_Station" HeaderText="測試站別">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Assts_name" HeaderText="資產名稱">
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Place_sn" HeaderText="所在位置">
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
                    <SelectedRowStyle BackColor="#669999" ForeColor="White" Font-Bold="True" />
                </asp:GridView>
            </div>
        </fieldset>
    </div>
    <div>
        <fieldset>
            <legend>資產群組綁定</legend>
            <p>
                資產綁定</p>
            <div class="elements">
                <label for="question">
                    資產編號:</label>&nbsp;<asp:TextBox ID="txtAsset_no_Detail" runat="server"></asp:TextBox>
                &nbsp;</div>
            <div class="elements">
                <div class="elements">
                    &nbsp;&nbsp;<asp:Button ID="btnConfirm" runat="server" 
                        Text="新增綁定" CssClass="enjoy-css"
                        OnClick="btnConfirm_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="enjoy-css" OnClick="btnSave_Click" />
                </div>
                <div class="elements">
                    <asp:GridView ID="gvAssets" runat="server" CellPadding="3" CssClass="EU_DataTable"
                        Style="font-size: small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                        BorderWidth="1px" ShowFooter="True" AutoGenerateColumns="False" OnRowCommand="gvAssets_RowCommand"
                        OnRowDataBound="gvAssets_RowDataBound">
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
                            <asp:BoundField DataField="Place_Assets_sn" HeaderText="目前儲位" DataFormatString="">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Assts_no" HeaderText="標籤代碼" DataFormatString="">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Assts_eq_name" HeaderText="資產管制名稱">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="說明">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbNote" runat="server" Text='<%# Bind("Note")  %>' TextMode="MultiLine"
                                        Height="30" Width="200"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" Width="120px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="管理人員說明">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbSysNote" runat="server" Text='<%# Bind("SysNote") %>' TextMode="MultiLine"
                                        Height="30" Width="200"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" Width="120px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Assts_eq_id" HeaderText="序號">
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
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" ForeColor="White" Font-Bold="True" />
                    </asp:GridView>
                </div>
        </fieldset>
    </div>
    </form>
</body>
