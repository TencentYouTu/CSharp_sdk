using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TencentYoutuYun.SDK.Csharp.Common;
using TencentYoutuYun.SDK.Csharp.Model;

namespace TencentYoutuYun.SDK.Csharp
{
    public class Youtu
    {
        // 30 days
        const double EXPIRED_SECONDS = 2592000;
        const int HTTP_BAD_REQUEST = 400;
        const int HTTP_SERVER_ERROR = 500;

        /// <summary>
        /// return the status message 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string statusText(int status)
        {
            string statusText = "unkown";

            switch (status)
            {
                case 200:
                    statusText = "HTTP OK";
                    break;
                case 400:
                    statusText = "Bad Request";
                    break;
                case 401:
                    statusText = "Unauthorized";
                    break;
                case 403:
                    statusText = "Forbidden";
                    break;
                case 500:
                    statusText = "Internal Server Error";
                    break;
            }
            return statusText;
        }

        #region 接口调用

        #region 人脸检测与分析

        /// <summary>
        /// 人脸检测 detectface
        /// </summary>
        /// <param name="image_path">待检测的路径</param>
        /// <param name="isbigface">是否大脸模式 ０表示检测所有人脸， 1表示只检测照片最大人脸　适合单人照模式</param>
        /// <returns>返回的结果，JSON字符串，字段参见API文档</returns>
        public static string detectface(string image_path, int isbigface=1)
        {
            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/detectface";
            StringBuilder postData = new StringBuilder(); 
            string pars = "\"app_id\":\"{0}\",\"image\":\"{1}\",\"mode\":{2}";
            pars = string.Format(pars, Conf.Instance().APPID, Utility.ImgBase64(image_path), isbigface);
            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));
            return result;
        }
        /// <summary>
        /// 五官定位 faceshape
        /// </summary>
        /// <param name="image_path">待检测的路径</param>
        /// <param name="isbigface">是否大脸模式 ０表示检测所有人脸， 1表示只检测照片最大人脸　适合单人照模式</param>
        /// <returns>返回的结果，JSON字符串，字段参见API文档</returns>
        public static string faceshape(string image_path,int isbigface=1)
        {
            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/faceshape";
            StringBuilder postData = new StringBuilder(); 
            string pars = "\"app_id\":\"{0}\",\"image\":\"{1}\",\"mode\":{2}";
            pars =string.Format(pars, Conf.Instance().APPID, Utility.ImgBase64(image_path), isbigface);
            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));
            return result;
        }

        #endregion

        #region 人脸识别

        /// <summary>
        /// 人脸对比 facecompare
        /// </summary>
        /// <param name="imageA">待比对的A图片数据</param>
        /// <param name="imageB">待比对的B图片数据</param>
        /// <returns>返回的结果，JSON字符串，字段参见API文档</returns>
        public static string facecompare(string imageA, string imageB)
        {
            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/facecompare";
            StringBuilder postData = new StringBuilder(); 
            string pars = "\"app_id\":\"{0}\",\"imageA\":\"{1}\",\"imageB\":\"{2}\"";
            pars =string.Format(pars, Conf.Instance().APPID, Utility.ImgBase64(imageA), Utility.ImgBase64(imageB));
            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));
            return result;
        }

        /// <summary>
        /// 人脸验证 faceverify
        /// </summary>
        /// <param name="image_path">待验证的图片路径</param>
        /// <param name="person_id">待验证的人脸id</param>
        /// <returns>返回的结果，JSON字符串，字段参见API文档</returns>
        public static string faceverify(string image_path, string person_id)
        {
            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/faceverify";
            StringBuilder postData = new StringBuilder(); 
            string pars = "\"app_id\":\"{0}\",\"image\":\"{1}\",\"person_id\":\"{2}\"";
            pars =string.Format(pars, Conf.Instance().APPID, Utility.ImgBase64(image_path), person_id);
            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));
            return result;
        }
        /// <summary>
        /// 人脸识别 faceidentify
        /// </summary>
        /// <param name="image_path">待识别的图片路径</param>
        /// <param name="group_id">识别的组id</param>
        /// <returns>返回的结果，JSON字符串，字段参见API文档</returns>
        public static string faceidentify(string image_path, string group_id)
        {
            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/faceidentify";
            StringBuilder postData = new StringBuilder(); 
            string pars = "\"app_id\":\"{0}\",\"group_id\":\"{1}\",\"image\":\"{2}\"";
            pars =string.Format(pars, Conf.Instance().APPID, group_id, Utility.ImgBase64(image_path));
            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));
            return result;
        }

        #endregion

        #region 个体(Person)管理

        /// <summary>
        /// 个体创建 newperson
        /// </summary>
        /// <param name="image_path">包含个体人脸的图片数据</param>
        /// <param name="person_id">新建的个体id，用户指定，需要保证app_id下的唯一性</param>
        /// <param name="person_name">姓名</param>
        /// <param name="group_ids">新建的个体存放的组id，可以指定多个组id，用户指定（组默认创建）</param>
        /// <param name="person_tag">备注信息，用户自解释字段</param>
        /// <returns>返回的结果，JSON字符串，字段参见API文档</returns>
        public static string newperson(string image_path, string person_id, string person_name, List<string> group_ids, string person_tag)
        {
            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/newperson";
            StringBuilder postData = new StringBuilder(); 
            string pars = "\"app_id\":\"{0}\",\"image\":\"{1}\",\"group_ids\":{2},\"person_id\":\"{3}\",\"person_name\":\"{4}\",\"tag\":\"{5}\"";
            pars =string.Format(pars, Conf.Instance().APPID, Utility.ImgBase64(image_path), JsonHelp<string[]>.ToJsonString(group_ids.ToArray()), person_id, person_name, person_tag);
            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));
            return result;
        }
        /// <summary>
        /// 删除个体 delperson
        /// </summary>
        /// <param name="person_id">待删除的个体id</param>
        /// <returns>返回的结果，JSON字符串，字段参见API文档</returns>
        public static string delperson(string person_id)
        {
            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/delperson";
            StringBuilder postData = new StringBuilder(); 
            string pars = "\"app_id\":\"{0}\",\"person_id\":\"{1}\"";
            pars =string.Format(pars, Conf.Instance().APPID, person_id);
            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));
            return result;
        }
        /// <summary>
        /// 增加人脸 addface
        /// </summary>
        /// <param name="person_id">新增人脸的个体身份id</param>
        /// <param name="image_path_arr">待增加的包含人脸的图片数据，可加入多张（包体大小<2m）</param>
        /// <param name="facetag">人脸备注信息，用户自解释字段</param>
        /// <returns>返回的结果，JSON字符串，字段参见API文档</returns>
        public static string addface(string person_id, List<string> image_path_arr, string facetag="")
        {
            List<string> faceImgBase64List = new List<string>();

            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/addface";
            StringBuilder postData = new StringBuilder(); 

            image_path_arr.ForEach(path =>
            {
                faceImgBase64List.Add(Utility.ImgBase64(path));
            });

            string pars = "\"app_id\":\"{0}\",\"images\":{1},\"person_id\":\"{2}\",\"tag\":\"{3}\"";

            pars =string.Format(pars, Conf.Instance().APPID, JsonHelp<string[]>.ToJsonString(faceImgBase64List.ToArray()), person_id, facetag);

            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));

            return result;
        }
        /// <summary>
        /// 删除人脸 delface
        /// </summary>
        /// <param name="person_id">待删除人脸的个体身份id</param>
        /// <param name="face_ids">删除人脸id的列表</param>
        /// <returns>返回的结果，JSON字符串，字段参见API文档</returns>
        public static string delface(string person_id, List<string> face_ids)
        {
            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/delface";
            StringBuilder postData = new StringBuilder(); 
            string pars = "\"app_id\":\"{0}\",\"person_id\":\"{1}\",\"face_ids\":{2}";
            pars =string.Format(pars, Conf.Instance().APPID, person_id, JsonHelp<string[]>.ToJsonString(face_ids.ToArray()));
            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));

            return result;
        }
        /// <summary>
        /// 设置信息 setinfo
        /// </summary>
        /// <param name="person_id">待设置的个体身份id</param>
        /// <param name="person_name">新设置的个体名字</param>
        /// <param name="person_tag">新设置的人备注信息</param>
        /// <returns>返回的结果，JSON字符串，字段参见API文档</returns>
        public static string setinfo(string person_id, string person_name, string person_tag)
        {
            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/setinfo";
            StringBuilder postData = new StringBuilder(); 
            string pars = "\"app_id\":\"{0}\",\"person_name\":\"{1}\",\"person_id\":\"{2}\",\"tag\":\"{3}\"";
            pars =string.Format(pars, Conf.Instance().APPID, person_name, person_id, person_tag);
            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));
            return result;
        }
        /// <summary>
        /// 获取信息 getinfo
        /// </summary>
        /// <param name="person_id">待查询的个体身份id</param>
        /// <returns>返回的结果，JSON字符串，字段参见API文档</returns>
        public static string getinfo(string person_id)
        {
            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/getinfo";
            StringBuilder postData = new StringBuilder(); 
            string pars = "\"app_id\":\"{0}\",\"person_id\":\"{1}\"";
            pars =string.Format(pars, Conf.Instance().APPID, person_id);
            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));
            return result;
        }

        #endregion

        #region 信息查询
        /// <summary>
        /// 获取组列表 getgroupids
        /// </summary>
        /// <returns>返回的组列表查询结果，JSON字符串，字段参见API文档</returns>
        public static string getgroupids()
        {
            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/getgroupids";
            StringBuilder postData = new StringBuilder(); 
            string pars = "\"app_id\":\"{0}\"";
            pars =string.Format(pars, Conf.Instance().APPID);
            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));
            return result;
        }
        /// <summary>
        /// 获取人列表 getpersonids
        /// </summary>
        /// <param name="group_id">待查询的组id</param>
        /// <returns>返回的个体列表查询结果，JSON字符串，字段参见API文档</returns>
        public static string getpersonids(string group_id)
        {
            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/getpersonids";
            StringBuilder postData = new StringBuilder(); 
            string pars = "\"app_id\":\"{0}\",\"group_id\":\"{1}\"";
            pars =string.Format(pars, Conf.Instance().APPID, group_id);
            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));
            return result;
        }
        /// <summary>
        /// 获取人脸列表 getfaceids
        /// </summary>
        /// <param name="person_id">待查询的个体id</param>
        /// <returns>返回的人脸列表查询结果，JSON字符串，字段参见API文档</returns>
        public static string getfaceids(string person_id)
        {
            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/getfaceids";
            StringBuilder postData = new StringBuilder(); 
            string pars = "\"app_id\":\"{0}\",\"person_id\":\"{1}\"";
            pars =string.Format(pars, Conf.Instance().APPID, person_id);
            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));
            return result;
        }
        /// <summary>
        /// 获取人脸信息 getfaceinfo
        /// </summary>
        /// <param name="face_id">待查询的人脸id</param>
        /// <returns>返回的人脸信息查询结果，JSON字符串，字段参见API文档</returns>
        public static string getfaceinfo(string face_id)
        {
            string expired = Utility.UnixTime(EXPIRED_SECONDS);
            string url = Conf.Instance().API_YOUTU_END_POINT + "youtu/api/getfaceinfo";
            StringBuilder postData = new StringBuilder(); 
            string pars = "\"app_id\":\"{0}\",\"face_id\":\"{1}\"";
            pars =string.Format(pars, Conf.Instance().APPID, face_id);
            postData.Append("{");
            postData.Append(pars);
            postData.Append("}");
            string result = Http.Post(url, postData.ToString(), Auth.appSign(expired, Conf.Instance().USER_ID));
            return result;
        }

        #endregion

        #endregion

    }
}