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
            //string appid = "you appid";
            //string secretId = "you secretid";
            //string secretKey = "you secretkey";
            //string userid = "请用qq号代替";

            string appid = "1000031";
            string secretId = "AKIDUIDlPDt5mZutfr46NT0GisFcQh1nMOox";
            string secretKey = "ind5yAd55ZspBc7MCANcxEjuXi8YU8RL";
            string userid = "380549494";


            Conf.Instance().setAppInfo(appid, secretId, secretKey, userid);

            string path = System.IO.Directory.GetCurrentDirectory();
            string result = string.Empty;
            //// 人脸检测 调用列子
            //result = Youtu.detectface(path + "\\test.jpg");
            //Console.WriteLine(result);

            //Console.ReadKey();

            //// 人脸定位 调用demo
            //result = Youtu.faceshape(path + "\\test.jpg");.
            result = Youtu.getpersonids("group");
            result = Youtu.addface("123", new List<string> { path + "\\test.jpg", path + "\\test.jpg" });
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
