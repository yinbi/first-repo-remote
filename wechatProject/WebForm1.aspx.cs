using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace wechatProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //string token = GetAccessToken();
                ////Response.Write(token);

                //string ticket = GetTicket(token);
                ////Response.Write(ticket);

                Response.Redirect(string.Format("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}",Server.UrlEncode("gQE/8ToAAAAAAAAAASxodHRwOi8vd2VpeGluLnFxLmNvbS9xL3NFanNVSkRtVVk4b2xKS0hMR2JiAAIEn8T4VgMEgDoJAA==")));
            }
        }
        private string GetAccessToken()
        {
            string APPID = "wx317b534d8e5bd8ec";
            //公众账号JSAPI
            string MCHID = "1278913901";
            string KEY = "SDF345DGFD6ASDFGASDF3457JHGJHKHF";
            string APPSECRET = "974d2284d13c737b0474fa9f70d67abf";
            HttpClient _httpClient = new HttpClient();
            //_httpClient.BaseAddress = new Uri("http://api.16m.com/");
            _httpClient.BaseAddress = new Uri("https://api.weixin.qq.com/");

            var parameters = new Dictionary<string, string>();
            //parameters.Add("client_id", "1234");
            //parameters.Add("client_secret", "5678");
            //parameters.Add("grant_type", "client_credentials");
            //var str = _httpClient.PostAsync("/token", new FormUrlEncodedContent(parameters))
            //    .Result.Content.ReadAsStringAsync().Result;

            //https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
            parameters.Add("appid", APPID);
            parameters.Add("secret", APPSECRET);
            parameters.Add("grant_type", "client_credential");

            var str = _httpClient.GetAsync(string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", APPID, APPSECRET)).Result.Content.ReadAsStringAsync().Result;
               // .Result.Content.ReadAsStringAsync().Result;

            // JObject.Parse(responseValue)["access_token"].Value<string>();
            var token = JObject.Parse(str)["access_token"].Value<string>();
            return token;
        }

        private string GetTicket(string token)
        {
            HttpClient _httpClient = new HttpClient();
            //https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=TOKEN

            var json = "{\"expire_seconds\": 604800, \"action_name\": \"QR_SCENE\", \"action_info\": {\"scene\": {\"scene_id\": 123}}}";

            string str = DoPost(string.Format("https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}", token), json);

            var ticket = JObject.Parse(str)["ticket"].Value<string>();
            return ticket;
        }

        public static string DoPost(string requestUrl, string param)
        {
            //string buyCode = receipt;
            //string param = "{\"receipt-data\":\"" + buyCode + "\"}";

            byte[] bs = Encoding.ASCII.GetBytes(param);
            string responseData = string.Empty;
            string _requestUrl = requestUrl;

            try
            {
                Uri uri = new Uri(_requestUrl);
                HttpWebRequest req = HttpWebRequest.Create(uri) as HttpWebRequest;
                req.Method = "POST";
                req.ContentType = "application/json";
                req.ContentLength = bs.Length;

                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                    reqStream.Close();
                    //using (StreamWriter myStreamWriter = new StreamWriter(reqStream, Encoding.GetEncoding("utf-8")))
                    //{
                    //    //myStreamWriter.Write(param);
                    //    myStreamWriter.Write(bs,
                    //    myStreamWriter.Close();
                    //}
                }

                using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                    {
                        responseData = reader.ReadToEnd().ToString();
                    }
                }
            }
            catch (Exception e)
            {
                responseData = e.ToString();
            }
            return responseData;
        }
    }
}