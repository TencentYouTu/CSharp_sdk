using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TencentYoutuYun.SDK.Csharp;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 设置为你自己的密钥对
            string appid = "1000031";
            string secretId = "AKIDUIDlPDt5mZutfr46NT0GisFcQh1nMOox";
            string secretKey = "ind5yAd55ZspBc7MCANcxEjuXi8YU8RL";
            string userid = "380549494";



            Conf.Instance().setAppInfo(appid, secretId, secretKey, userid, Conf.Instance().YOUTU_END_POINT);

            string path = System.IO.Directory.GetCurrentDirectory() + "\\test.jpg";
            string result = string.Empty;
            //// 人脸检测 调用列子
            string url = "http://open.youtu.qq.com/content/img/slide-1.jpg";
            result = Youtu.addfaceurl("12345", new List<string> { url});
            //result = Youtu.faceshape(path);
            Console.WriteLine(result);
            Console.ReadKey();

            //// 人脸定位 调用demo
            result = Youtu.faceshape(path);
            Console.WriteLine(result);
            Console.ReadKey();

           result = Youtu.getpersonids("group");
           Console.WriteLine(result);
           Console.ReadKey();
        }
    }
}
