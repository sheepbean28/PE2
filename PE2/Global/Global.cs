using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE2
{
    public  class Settings
    {
        public static int Car ()
        {
            return 20;
        }
        public static int Car1()
        {
            return 4;
        }
        public static int Car2()
        {
            return 3;
        }
    }
    public enum Place
    {
        樓層 = 1,
        線別 = 2
    }
    public enum Status
    {
        在庫 = 1,
        已領出 = 0,
        報廢 = 2,
        轉出 = 3
    }
    public enum Power
    {
        治具管理 = 1,
        資產管理 = 2,
        校驗管理 = 3,
        隔離箱管理 = 4,
        耗材管理 = 5
    }
    public enum OutFixture
    {
        架站使用 = 1,
        外借使用 = 2,
        治具送修 = 3
    }
    public enum PlacePower
    { 
        治具出借 = 1,
        治具歸還 = 2,
        資產管理 = 4
    }
    public enum CP_Type
    {
        內校驗 = 0,
        外校驗 = 1,
        免校驗 = 2
    }
    public enum CP_Status
    {
        已送回 = 1,
        送驗中 = 2,
        送修中 = 3
    }
}