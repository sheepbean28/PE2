using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common
{
    /// <summary> 
    /// Rmb 腔晡猁佽隴﹝ 
    /// </summary> 
    public class Rmb
    {
        /// <summary> 
        /// 蛌遙鏍啟湮苤踢塗 
        /// </summary> 
        /// <param name="num">踢塗</param> 
        /// <returns>殿隙湮迡倛宒</returns> 
        public static string CmycurD(decimal num)
        {
            string str1 = "錨瓞楚佹斪翻副墾";            //0-9垀勤茼腔犖趼 
            string str2 = "勀唱夆砬唱夆勀唱夆啋褒煦"; //杅趼弇垀勤茼腔犖趼 
            string str3 = "";    //植埻num硉笢堤腔硉 
            string str4 = "";    //杅趼腔趼睫揹倛宒 
            string str5 = "";  //鏍啟湮迡踢塗倛宒 
            int i;    //悜遠曹講 
            int j;    //num腔硉傚眕100腔趼睫揹酗僅 
            string ch1 = "";    //杅趼腔犖逄黍楊 
            string ch2 = "";    //杅趼弇腔犖趼黍楊 
            int nzero = 0;  //蚚懂數呾蟀哿腔錨硉岆撓跺 
            int temp;            //植埻num硉笢堤腔硉 

            num = Math.Round(Math.Abs(num), 2);    //蔚num橈勤硉甜侐忔拻2弇苤杅 
            str4 = ((long)(num * 100)).ToString();        //蔚num傚100甜蛌遙傖趼睫揹倛宒 
            j = str4.Length;      //梑堤郔詢弇 
            if (j > 15) { return "祛堤"; }
            str2 = str2.Substring(15 - j);   //堤勤茼弇杅腔str2腔硉﹝ㄩ200.55,j峈5垀眕str2=唱夆啋褒煦 

            //悜遠堤藩珨弇剒猁蛌遙腔硉 
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //堤剒蛌遙腔議珨弇腔硉 
                temp = Convert.ToInt32(str3);      //蛌遙峈杅趼 
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //絞垀弇杅祥峈啋﹜勀﹜砬﹜勀砬奻腔杅趼奀 
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "錨" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //蜆弇岆勀砬ㄛ砬ㄛ勀ㄛ啋弇脹壽瑩弇 
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "錨" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //彆蜆弇岆砬弇麼啋弇ㄛ寀斛剕迡奻 
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //郔綴珨弇ㄗ煦ㄘ峈0奀ㄛ樓奻※淕§ 
                    str5 = str5 + '淕';
                }
            }
            if (num == 0)
            {
                str5 = "錨啋淕";
            }
            return str5;
        }

        /**/
        /// <summary> 
        /// 珨跺笭婥ㄛ蔚趼睫揹珂蛌遙傖杅趼婓覃蚚CmycurD(decimal num) 
        /// </summary> 
        /// <param name="num">蚚誧怀腔踢塗ㄛ趼睫揹倛宒帤蛌傖decimal</param> 
        /// <returns></returns> 
        public static string CmycurD(string numstr)
        {
            try
            {
                decimal num = Convert.ToDecimal(numstr);
                return CmycurD(num);
            }
            catch
            {
                return "準杅趼倛宒ㄐ";
            }
        }
    } 

}
