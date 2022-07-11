<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetExpendables.aspx.cs"
    Inherits="PE2.Expendables.GetExpendables" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../PE2/Scripts/jqtransformplugin/jquery.jqtransform.js" type="text/javascript"></script>
    <script src="../PE2//Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , Verdana, Arial, Helvetica, sans-serif;
            font-size: 12px;
        }
        .registration_form
        {
            margin: 0 auto;
            width: 500px;
            padding: 14px;
        }
        label
        {
            width: 8em;
            float: left;
            margin-right: 0.5em;
          
            display: block;
        }
        
        .submit
        {
            float: right;
        }
        p
        {
            border-bottom: 1px solid #B7DDF2;
            color: #666666;
            font-size: 11px;
            margin-bottom: 20px;
            padding-bottom: 10px;
        }
        fieldset
        {
            background: #EBF4FB none repeat scroll 0 0;
            border: 2px solid #B7DDF2;
            width: 500px;
        }
        
        legend
        {
            color: #fff;
            background: #80D3E2;
            border: 1px solid #781351;
            padding: 2px 6px;
        }
        
        .elements
        {
            padding: 10px;
        }
        .QuantityCount
        {
            width: 50px;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <fieldset>
            <legend>耗材領用</legend>
            <p>
                領取耗材使用</p>
            <div class="elements">
                <label for="name">
                    執行項目 :</label>&nbsp;
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="elements">
                <label for="e-mail">
                    領用人員:</label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
                &nbsp;
                <input type="text" id="e-mail" size="25" />
            </div>
            <div class="elements">
                <label for="question">
                    條碼查詢:</label>
                <input type="text" id="e-mail0" size="25" /></div>
            <div class="elements">
                <label for="question">
                    品名:</label>
                <asp:Label ID="Label1" runat="server" Text="無"></asp:Label>
            </div>
            <div class="elements">
                <label for="question">
                    類別:</label>
                <asp:Label ID="Label2" runat="server" Text="無"></asp:Label>
            </div>
            <div class="elements">
                <label for="question">
                    單價:</label>
                <asp:Label ID="Label3" runat="server" Text="無"></asp:Label>
            </div>
            <div class="elements">
                <label for="question">
                    查詢時間:</label>
                <asp:Label ID="Label4" runat="server" Text="無"></asp:Label>
            </div>
            <div class="elements">
                <label for="question">
                    說明:</label>
                <asp:Label ID="Label5" runat="server" Text="無"></asp:Label>
            </div>
            <div class="elements">
                <label for="Password">
                    庫存數量:</label>
                <asp:Label ID="Label6" runat="server" Text="無"></asp:Label>
            </div>
            <div class="elements">
                <label for="Password">
                    庫存等級:</label>
                <asp:Label ID="Label7" runat="server" Text="無"></asp:Label>
            </div>
            <div class="elements">
                <label for="Password">
                    領用數量:</label>
                <input type="text" id="e-mail1" size="25" class="QuantityCount" /></div>
            <div class="elements">
                <label for="Password">
                    領用說明:</label>
                <textarea rows="10" style="width: 473px"></textarea>
            </div>
            <div class="submit">
                <input type="submit" value="領用" />
            </div>
        </fieldset>
    </div>
    </form>
</body>
</html>
