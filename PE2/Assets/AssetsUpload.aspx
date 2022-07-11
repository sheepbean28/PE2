<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetsUpload.aspx.cs" Inherits="PE2.Assets.AssetsUpload" %>

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
    <title></title>
</head>
<script type="text/javascript">
    var win1;
    var edit;
    var result = false;
    //將預設語系設定為中文
    $(function () {
        var height = ($(document).height() - 20);

        //  $("#tbStartDate").datepicker({ dateFormat: 'yy-mm-dd' });
        //   $("#tbEndDate").datepicker({ dateFormat: 'yy-mm-dd' });
       // gridviewScroll();

    });
  
    
    function gridviewScroll() {
        var height = $(window).height();
        var width = $(window).width();
        gridView1 = $('#gvAssets').gridviewScroll({
            width: width - 80,
            height: height - 120,
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
    //by Bryan(不來ㄣ)

    //這裡控制要檢查的項目，true表示要檢查，false表示不檢查 
    var isCheckImageType = true;  //是否檢查圖片副檔名 
    var isCheckImageWidth = false;  //是否檢查圖片寬度 
    var isCheckImageHeight = false;  //是否檢查圖片高度 
    var isCheckImageSize = false;  //是否檢查圖片檔案大小 

    var ImageSizeLimit = 100000;  //上傳上限，單位:byte 
    var ImageWidthLimit = 1200;  //圖片寬度上限 
    var ImageHeightLimit = 1000;  //圖片高度上限 

    function checkFile() {
        
        var re = /\.(mdb|mdb)$/i;  //允許的圖片副檔名 
        if (isCheckImageType && !re.test($("#fileUploader").val())) 
        {
            alert("只允許上傳mdb檔");
            $("#fileUploader").val('');
        }
        else 
        {
           
        }
    }
    function checkImage() {
        if (isCheckImageWidth && this.width > ImageWidthLimit) {
            showMessage('寬度', 'px', this.width, ImageWidthLimit);
        } else if (isCheckImageHeight && this.height > ImageHeightLimit) {
            showMessage('高度', 'px', this.height, ImageHeightLimit);
        } else if (isCheckImageSize && this.fileSize > ImageSizeLimit) {
            showMessage('檔案大小', 'kb', this.fileSize / 1000, ImageSizeLimit / 1000);
        } else {
            document.FileForm.submit();
        }
    }
    function showMessage(kind, unit, real, limit) {
        var msg = "您所選擇的圖片kind為 real unit\n超過了上傳上限 limit unit\n不允許上傳！"
        alert(msg.replace(/kind/, kind).replace(/unit/g, unit).replace(/real/, real).replace(/limit/, limit));
    } 
 

</script>

<body>
    <form id="form1" runat="server">
    <div style="text-align: left">
        <asp:FileUpload ID="fileUploader" runat="server" onchange="checkFile()" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUpload" runat="server" CssClass="enjoy-css" Text="上傳" 
            onclick="btnUpload_Click" />
        &nbsp;
        共<asp:Label ID="lbCount" runat="server" Text="0"></asp:Label>筆資料
    </div>
    <asp:GridView ID="gvAssets" runat="server" CellPadding="3" CssClass="EU_DataTable"
        Style="font-size: small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
        BorderWidth="1px" ShowFooter="True" 
        onrowdatabound="gvAssets_RowDataBound" AllowPaging="True" PageSize="40" 
        onpageindexchanging="gvAssets_PageIndexChanging" >
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <PagerStyle CssClass="GridPager"></PagerStyle>
        <SelectedRowStyle BackColor="#669999" ForeColor="White" Font-Bold="True" />
    </asp:GridView>
    <br />
    </form>
</body>
</html>
