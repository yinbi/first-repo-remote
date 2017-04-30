using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        private string GetTicket()
        {
            HttpClient _httpClient = new HttpClient();
            //https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=TOKEN
            _httpClient.BaseAddress = new Uri("https://api.weixin.qq.com/");

            //var parameters = new Dictionary<string, string>();
            //parameters.Add("access_token", "5wTjy00CAwKodYm_FHNmbaOESgvAk1Zq0-Easu4SLYygJ5wR2EdiMIOqEygDPoToj1GOihrCI4rXzjjKIYzy5c60RzQLzrk97oFSefwtO2Fa3yhN37mjkoe6IGNajyhhQATjABAXHA");

            var json = "{\"expire_seconds\": 604800, \"action_name\": \"QR_SCENE\", \"action_info\": {\"scene\": {\"scene_id\": 123}}}";
            var jObject = JObject.Parse(json);
            // //_httpClient.po("https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=5wTjy00CAwKodYm_FHNmbaOESgvAk1Zq0-Easu4SLYygJ5wR2EdiMIOqEygDPoToj1GOihrCI4rXzjjKIYzy5c60RzQLzrk97oFSefwtO2Fa3yhN37mjkoe6IGNajyhhQATjABAXHA",)
           // _httpClient.PostAsJsonAsync()
            
            //var ticket = JObject.Parse(str)["ticket"].Value<string>();
            //return ticket;
            return "";
        }
    }
}