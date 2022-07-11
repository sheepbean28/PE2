using System;
namespace PE2.Model
{
    /// <summary>
    /// Supplies:实体类(属性说明自动提取数据库字段的描述信息)
    
    public partial class SuppliesLog
    {

        public string TypeName 
        {
            get 
            {
                string Name = string.Empty;
                if (Type == 1)
                {
                    Name = "耗材領用";
                }
                if (Type == 2)
                {
                    Name = "耗材退庫";
                }
                if (Type == 3)
                {
                    Name = "外單位借出";
                }
                if (Type == 4)
                {
                    Name = "外單位歸還";
                }

                return Name;
            }
        }
    }
}

