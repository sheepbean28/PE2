using System;
using System.IO;
namespace PE2.Model
{
    /// <summary>
    /// Supplies:实体类(属性说明自动提取数据库字段的描述信息)
    
    public partial class Supplies
    {
        //StockStatus
        public int Valid
        {
            set;
            get;
        }
        public int StockStart
        {
            set;
            get;
        }
        public int StockEnd
        {
            set;
            get;
        }
        public int StockStatus
        {
            set;
            get;
        }
        public int GetStatus
        {
            set;
            get;
        }
        public string StatusName 
        {
            get 
            {
                string Name = string.Empty;
                if (GetStatus == 1)
                {
                    Name = "耗材領用";
                }
                if (GetStatus == 2)
                {
                    Name = "耗材退庫";
                }
                if (GetStatus == 3)
                {
                    Name = "外單位借出";
                }
                if (GetStatus == 4)
                {
                    Name = "外單位歸還";
                }

                return Name;
            }
        }

        public string PlaceName
        {
            get
            {
                string Name = string.Empty;
                if (GetStatus == 23)
                {
                    Name = "辦公室";
                }
                if (GetStatus == 24)
                {
                    Name = "四樓庫房";
                }
                if (GetStatus == 25)
                {
                    Name = "五樓庫房";
                }
                if (GetStatus == 26)
                {
                    Name = "六樓庫房";
                }

                return Name;
            }
        }
        public int GetQuantity
        {
            set;
            get;
        }
        public string GetNote
        {
            set;
            get;
        }
        public string FilePath
        {
            get 
            {
                if (File.Exists(Supplies_File))
                {
                    return Supplies_File;
                }
                else 
                {
                    return @"~\Images\Supplies\no_image.gif";
                }
            }
        }
       
    }
}

