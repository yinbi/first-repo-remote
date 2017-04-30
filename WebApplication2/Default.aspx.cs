using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Bind();
            }
        }
        private void Bind()
        {
            Response.Write(Request.Url.Host.ToString());
            return;
            //string str = "{\"CurID\":\"160819002\",\"UserID\":\"396961\",\"KindID\":\"123\",\"ServerID\":\"456\",\"Additional\":\"1\",\"ChangeGold\":\"300\",\"Area\":{\"0\":\"150\",\"2\":\"50\",\"3\":\"100\"},\"IP\":\"127.0.0.1\"}";
            //GetWebRequest("http://localhost:37660/fjk3/Bet?result=" + str, Encoding.Default);
            //HttpClient _httpClient = new HttpClient();
            //_httpClient.BaseAddress = new Uri("http://localhost:37660/");
            //string url = "fjk3/Bet";
            //string clientId = "1234";
            //string clientSecret = "5678";
            //var parameters = new Dictionary<string, string>();
            ////parameters.Add("grant_type", "client_credentials");
            //string str = "{\"CurID\":\"160819002\",\"UserID\":\"396961\",\"KindID\":\"123\",\"ServerID\":\"456\",\"Additional\":\"1\",\"ChangeGold\":\"300\",\"Area\":{\"0\":\"150\",\"2\":\"50\",\"3\":\"100\"},\"IP\":\"127.0.0.1\"}";
            //parameters.Add("result", str);

            ////_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            ////    "Basic"
            ////    , Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret))
            ////    );
            ////var str = _httpClient.PostAsync("/token", new FormUrlEncodedContent(parameters)).Result.Content.ReadAsStringAsync().Result;
            //var result = _httpClient.PostAsync("/api/users/login", new FormUrlEncodedContent(parameters)).Result.Content.ReadAsStringAsync().Result;

            ////var token = JObject.Parse(str)["access_token"].Value<string>();
            ////_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            ////url = "api/users/CurrentUser";
            ////var result = _httpClient.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            //string str = "{\"cmd\":\"verify\",\"uid\":\"285838\",\"appid\":\"130619\",\"receipt\":\"ewoJInNpZ25hdHVyZSIgPSAiQXpRYWtIcHBUbHNaOEI3WG1RWHA4aGY3OExnOUNnYTNpODhjVTNDYm5QQnd6Z0g5eWNtMmI2VHNzODhpK0MzcXhQZUY4QnFkc3lFSjh1VHcyZnZ4N2ZhTmN3cnBXUzdud3lPMGlSRmdlbEwzYWxEWU1TQjdEVFBkdWNaQWN6RWhQdExjaXJMNEw4elJrM3VaZ0NMZkpldW9uRlNnci9HQTVtLzkrOUc5UEY3aXE4T1N2ZUVBQVpDY0krRHozWEc1M0FwYVUvVEx0dURpcnBmYWNpQUs1Ly9aRmVoT0hnNGVUKzBDS1l3MzNSaTZYSVhISHB6V3dNbDA1M1NISUVtcEppblhwYUJvUzM0S1RYUmMzR0lHalVOSEZzNEF2cEF2aktxM05Lc21kbGxTMExYaFNBTFlmci9lZVVERUZvLzJXY3JnLytnVWlncjhocmFadWRKSkh2TUFBQVdBTUlJRmZEQ0NCR1NnQXdJQkFnSUlEdXRYaCtlZUNZMHdEUVlKS29aSWh2Y05BUUVGQlFBd2daWXhDekFKQmdOVkJBWVRBbFZUTVJNd0VRWURWUVFLREFwQmNIQnNaU0JKYm1NdU1Td3dLZ1lEVlFRTERDTkJjSEJzWlNCWGIzSnNaSGRwWkdVZ1JHVjJaV3h2Y0dWeUlGSmxiR0YwYVc5dWN6RkVNRUlHQTFVRUF3dzdRWEJ3YkdVZ1YyOXliR1IzYVdSbElFUmxkbVZzYjNCbGNpQlNaV3hoZEdsdmJuTWdRMlZ5ZEdsbWFXTmhkR2x2YmlCQmRYUm9iM0pwZEhrd0hoY05NVFV4TVRFek1ESXhOVEE1V2hjTk1qTXdNakEzTWpFME9EUTNXakNCaVRFM01EVUdBMVVFQXd3dVRXRmpJRUZ3Y0NCVGRHOXlaU0JoYm1RZ2FWUjFibVZ6SUZOMGIzSmxJRkpsWTJWcGNIUWdVMmxuYm1sdVp6RXNNQ29HQTFVRUN3d2pRWEJ3YkdVZ1YyOXliR1IzYVdSbElFUmxkbVZzYjNCbGNpQlNaV3hoZEdsdmJuTXhFekFSQmdOVkJBb01Da0Z3Y0d4bElFbHVZeTR4Q3pBSkJnTlZCQVlUQWxWVE1JSUJJakFOQmdrcWhraUc5dzBCQVFFRkFBT0NBUThBTUlJQkNnS0NBUUVBcGMrQi9TV2lnVnZXaCswajJqTWNqdUlqd0tYRUpzczl4cC9zU2cxVmh2K2tBdGVYeWpsVWJYMS9zbFFZbmNRc1VuR09aSHVDem9tNlNkWUk1YlNJY2M4L1cwWXV4c1FkdUFPcFdLSUVQaUY0MWR1MzBJNFNqWU5NV3lwb041UEM4cjBleE5LaERFcFlVcXNTNCszZEg1Z1ZrRFV0d3N3U3lvMUlnZmRZZUZScjZJd3hOaDlLQmd4SFZQTTNrTGl5a29sOVg2U0ZTdUhBbk9DNnBMdUNsMlAwSzVQQi9UNXZ5c0gxUEttUFVockFKUXAyRHQ3K21mNy93bXYxVzE2c2MxRkpDRmFKekVPUXpJNkJBdENnbDdaY3NhRnBhWWVRRUdnbUpqbTRIUkJ6c0FwZHhYUFEzM1k3MkMzWmlCN2o3QWZQNG83UTAvb21WWUh2NGdOSkl3SURBUUFCbzRJQjF6Q0NBZE13UHdZSUt3WUJCUVVIQVFFRU16QXhNQzhHQ0NzR0FRVUZCekFCaGlOb2RIUndPaTh2YjJOemNDNWhjSEJzWlM1amIyMHZiMk56Y0RBekxYZDNaSEl3TkRBZEJnTlZIUTRFRmdRVWthU2MvTVIydDUrZ2l2Uk45WTgyWGUwckJJVXdEQVlEVlIwVEFRSC9CQUl3QURBZkJnTlZIU01FR0RBV2dCU0lKeGNKcWJZWVlJdnM2N3IyUjFuRlVsU2p0ekNDQVI0R0ExVWRJQVNDQVJVd2dnRVJNSUlCRFFZS0tvWklodmRqWkFVR0FUQ0IvakNCd3dZSUt3WUJCUVVIQWdJd2diWU1nYk5TWld4cFlXNWpaU0J2YmlCMGFHbHpJR05sY25ScFptbGpZWFJsSUdKNUlHRnVlU0J3WVhKMGVTQmhjM04xYldWeklHRmpZMlZ3ZEdGdVkyVWdiMllnZEdobElIUm9aVzRnWVhCd2JHbGpZV0pzWlNCemRHRnVaR0Z5WkNCMFpYSnRjeUJoYm1RZ1kyOXVaR2wwYVc5dWN5QnZaaUIxYzJVc0lHTmxjblJwWm1sallYUmxJSEJ2YkdsamVTQmhibVFnWTJWeWRHbG1hV05oZEdsdmJpQndjbUZqZEdsalpTQnpkR0YwWlcxbGJuUnpMakEyQmdnckJnRUZCUWNDQVJZcWFIUjBjRG92TDNkM2R5NWhjSEJzWlM1amIyMHZZMlZ5ZEdsbWFXTmhkR1ZoZFhSb2IzSnBkSGt2TUE0R0ExVWREd0VCL3dRRUF3SUhnREFRQmdvcWhraUc5Mk5rQmdzQkJBSUZBREFOQmdrcWhraUc5dzBCQVFVRkFBT0NBUUVBRGFZYjB5NDk0MXNyQjI1Q2xtelQ2SXhETUlKZjRGelJqYjY5RDcwYS9DV1MyNHlGdzRCWjMrUGkxeTRGRkt3TjI3YTQvdncxTG56THJSZHJqbjhmNUhlNXNXZVZ0Qk5lcGhtR2R2aGFJSlhuWTR3UGMvem83Y1lmcnBuNFpVaGNvT0FvT3NBUU55MjVvQVE1SDNPNXlBWDk4dDUvR2lvcWJpc0IvS0FnWE5ucmZTZW1NL2oxbU9DK1JOdXhUR2Y4YmdwUHllSUdxTktYODZlT2ExR2lXb1IxWmRFV0JHTGp3Vi8xQ0tuUGFObVNBTW5CakxQNGpRQmt1bGhnd0h5dmozWEthYmxiS3RZZGFHNllRdlZNcHpjWm04dzdISG9aUS9PamJiOUlZQVlNTnBJcjdONFl0UkhhTFNQUWp2eWdhWndYRzU2QWV6bEhSVEJoTDhjVHFBPT0iOwoJInB1cmNoYXNlLWluZm8iID0gImV3b0pJbTl5YVdkcGJtRnNMWEIxY21Ob1lYTmxMV1JoZEdVdGNITjBJaUE5SUNJeU1ERTJMVEE1TFRFeUlEQTRPalUyT2pFd0lFRnRaWEpwWTJFdlRHOXpYMEZ1WjJWc1pYTWlPd29KSW5CMWNtTm9ZWE5sTFdSaGRHVXRiWE1pSUQwZ0lqRTBOek0yT1RVM056QTBOVEVpT3dvSkluVnVhWEYxWlMxcFpHVnVkR2xtYVdWeUlpQTlJQ0kwTURGa01XRXdOak00WlRFeFlqQTFNbVV5T0dFeE9HTmlOVEJtWWpWa05tRXhaVEEzWm1Kaklqc0tDU0p2Y21sbmFXNWhiQzEwY21GdWMyRmpkR2x2YmkxcFpDSWdQU0FpTWpVd01EQXdNakF4T0RZM056UTVJanNLQ1NKaWRuSnpJaUE5SUNJeExqTXVNQzR3SWpzS0NTSmhjSEF0YVhSbGJTMXBaQ0lnUFNBaU1URXlPVEEwTURBNE15STdDZ2tpZEhKaGJuTmhZM1JwYjI0dGFXUWlJRDBnSWpJMU1EQXdNREl3TVRnMk56YzBPU0k3Q2draWNYVmhiblJwZEhraUlEMGdJakVpT3dvSkltOXlhV2RwYm1Gc0xYQjFjbU5vWVhObExXUmhkR1V0YlhNaUlEMGdJakUwTnpNMk9UVTNOekEwTlRFaU93b0pJblZ1YVhGMVpTMTJaVzVrYjNJdGFXUmxiblJwWm1sbGNpSWdQU0FpTkRZd1FqUXhPREV0TmpRME5DMDBRVEJDTFRoQ1JUUXRSRVEwTVVWQ01qRkRNakJFSWpzS0NTSnBkR1Z0TFdsa0lpQTlJQ0l4TVRJNU1UWXpNekV3SWpzS0NTSjJaWEp6YVc5dUxXVjRkR1Z5Ym1Gc0xXbGtaVzUwYVdacFpYSWlJRDBnSWpneE56azBOekE1TWlJN0Nna2ljSEp2WkhWamRDMXBaQ0lnUFNBaVkyOXRMbU4wTlRFNE9DNUlkV0Z1VEdWUGVDNTVhVzU2YVRVaU93b0pJbkIxY21Ob1lYTmxMV1JoZEdVaUlEMGdJakl3TVRZdE1Ea3RNVElnTVRVNk5UWTZNVEFnUlhSakwwZE5WQ0k3Q2draWIzSnBaMmx1WVd3dGNIVnlZMmhoYzJVdFpHRjBaU0lnUFNBaU1qQXhOaTB3T1MweE1pQXhOVG8xTmpveE1DQkZkR012UjAxVUlqc0tDU0ppYVdRaUlEMGdJbU52YlM1amREVXhPRGd1U0hWaGJreGxUM2dpT3dvSkluQjFjbU5vWVhObExXUmhkR1V0Y0hOMElpQTlJQ0l5TURFMkxUQTVMVEV5SURBNE9qVTJPakV3SUVGdFpYSnBZMkV2VEc5elgwRnVaMlZzWlhNaU93cDkiOwoJInBvZCIgPSAiMjUiOwoJInNpZ25pbmctc3RhdHVzIiA9ICIwIjsKfQ==\",\"unionid\":\"0\",\"key\":\"987524f4ca789d2999c0025591893af9\"}";
            string url = "http://game.16m.com/pay/iospay/verifyReceipt.ashx";
            string str = "cmd=verify&uid=285838&appid=130619&receipt=ewoJInNpZ25hdHVyZSIgPSAiQXpRYWtIcHBUbHNaOEI3WG1RWHA4aGY3OExnOUNnYTNpODhjVTNDYm5QQnd6Z0g5eWNtMmI2VHNzODhpK0MzcXhQZUY4QnFkc3lFSjh1VHcyZnZ4N2ZhTmN3cnBXUzdud3lPMGlSRmdlbEwzYWxEWU1TQjdEVFBkdWNaQWN6RWhQdExjaXJMNEw4elJrM3VaZ0NMZkpldW9uRlNnci9HQTVtLzkrOUc5UEY3aXE4T1N2ZUVBQVpDY0krRHozWEc1M0FwYVUvVEx0dURpcnBmYWNpQUs1Ly9aRmVoT0hnNGVUKzBDS1l3MzNSaTZYSVhISHB6V3dNbDA1M1NISUVtcEppblhwYUJvUzM0S1RYUmMzR0lHalVOSEZzNEF2cEF2aktxM05Lc21kbGxTMExYaFNBTFlmci9lZVVERUZvLzJXY3JnLytnVWlncjhocmFadWRKSkh2TUFBQVdBTUlJRmZEQ0NCR1NnQXdJQkFnSUlEdXRYaCtlZUNZMHdEUVlKS29aSWh2Y05BUUVGQlFBd2daWXhDekFKQmdOVkJBWVRBbFZUTVJNd0VRWURWUVFLREFwQmNIQnNaU0JKYm1NdU1Td3dLZ1lEVlFRTERDTkJjSEJzWlNCWGIzSnNaSGRwWkdVZ1JHVjJaV3h2Y0dWeUlGSmxiR0YwYVc5dWN6RkVNRUlHQTFVRUF3dzdRWEJ3YkdVZ1YyOXliR1IzYVdSbElFUmxkbVZzYjNCbGNpQlNaV3hoZEdsdmJuTWdRMlZ5ZEdsbWFXTmhkR2x2YmlCQmRYUm9iM0pwZEhrd0hoY05NVFV4TVRFek1ESXhOVEE1V2hjTk1qTXdNakEzTWpFME9EUTNXakNCaVRFM01EVUdBMVVFQXd3dVRXRmpJRUZ3Y0NCVGRHOXlaU0JoYm1RZ2FWUjFibVZ6SUZOMGIzSmxJRkpsWTJWcGNIUWdVMmxuYm1sdVp6RXNNQ29HQTFVRUN3d2pRWEJ3YkdVZ1YyOXliR1IzYVdSbElFUmxkbVZzYjNCbGNpQlNaV3hoZEdsdmJuTXhFekFSQmdOVkJBb01Da0Z3Y0d4bElFbHVZeTR4Q3pBSkJnTlZCQVlUQWxWVE1JSUJJakFOQmdrcWhraUc5dzBCQVFFRkFBT0NBUThBTUlJQkNnS0NBUUVBcGMrQi9TV2lnVnZXaCswajJqTWNqdUlqd0tYRUpzczl4cC9zU2cxVmh2K2tBdGVYeWpsVWJYMS9zbFFZbmNRc1VuR09aSHVDem9tNlNkWUk1YlNJY2M4L1cwWXV4c1FkdUFPcFdLSUVQaUY0MWR1MzBJNFNqWU5NV3lwb041UEM4cjBleE5LaERFcFlVcXNTNCszZEg1Z1ZrRFV0d3N3U3lvMUlnZmRZZUZScjZJd3hOaDlLQmd4SFZQTTNrTGl5a29sOVg2U0ZTdUhBbk9DNnBMdUNsMlAwSzVQQi9UNXZ5c0gxUEttUFVockFKUXAyRHQ3K21mNy93bXYxVzE2c2MxRkpDRmFKekVPUXpJNkJBdENnbDdaY3NhRnBhWWVRRUdnbUpqbTRIUkJ6c0FwZHhYUFEzM1k3MkMzWmlCN2o3QWZQNG83UTAvb21WWUh2NGdOSkl3SURBUUFCbzRJQjF6Q0NBZE13UHdZSUt3WUJCUVVIQVFFRU16QXhNQzhHQ0NzR0FRVUZCekFCaGlOb2RIUndPaTh2YjJOemNDNWhjSEJzWlM1amIyMHZiMk56Y0RBekxYZDNaSEl3TkRBZEJnTlZIUTRFRmdRVWthU2MvTVIydDUrZ2l2Uk45WTgyWGUwckJJVXdEQVlEVlIwVEFRSC9CQUl3QURBZkJnTlZIU01FR0RBV2dCU0lKeGNKcWJZWVlJdnM2N3IyUjFuRlVsU2p0ekNDQVI0R0ExVWRJQVNDQVJVd2dnRVJNSUlCRFFZS0tvWklodmRqWkFVR0FUQ0IvakNCd3dZSUt3WUJCUVVIQWdJd2diWU1nYk5TWld4cFlXNWpaU0J2YmlCMGFHbHpJR05sY25ScFptbGpZWFJsSUdKNUlHRnVlU0J3WVhKMGVTQmhjM04xYldWeklHRmpZMlZ3ZEdGdVkyVWdiMllnZEdobElIUm9aVzRnWVhCd2JHbGpZV0pzWlNCemRHRnVaR0Z5WkNCMFpYSnRjeUJoYm1RZ1kyOXVaR2wwYVc5dWN5QnZaaUIxYzJVc0lHTmxjblJwWm1sallYUmxJSEJ2YkdsamVTQmhibVFnWTJWeWRHbG1hV05oZEdsdmJpQndjbUZqZEdsalpTQnpkR0YwWlcxbGJuUnpMakEyQmdnckJnRUZCUWNDQVJZcWFIUjBjRG92TDNkM2R5NWhjSEJzWlM1amIyMHZZMlZ5ZEdsbWFXTmhkR1ZoZFhSb2IzSnBkSGt2TUE0R0ExVWREd0VCL3dRRUF3SUhnREFRQmdvcWhraUc5Mk5rQmdzQkJBSUZBREFOQmdrcWhraUc5dzBCQVFVRkFBT0NBUUVBRGFZYjB5NDk0MXNyQjI1Q2xtelQ2SXhETUlKZjRGelJqYjY5RDcwYS9DV1MyNHlGdzRCWjMrUGkxeTRGRkt3TjI3YTQvdncxTG56THJSZHJqbjhmNUhlNXNXZVZ0Qk5lcGhtR2R2aGFJSlhuWTR3UGMvem83Y1lmcnBuNFpVaGNvT0FvT3NBUU55MjVvQVE1SDNPNXlBWDk4dDUvR2lvcWJpc0IvS0FnWE5ucmZTZW1NL2oxbU9DK1JOdXhUR2Y4YmdwUHllSUdxTktYODZlT2ExR2lXb1IxWmRFV0JHTGp3Vi8xQ0tuUGFObVNBTW5CakxQNGpRQmt1bGhnd0h5dmozWEthYmxiS3RZZGFHNllRdlZNcHpjWm04dzdISG9aUS9PamJiOUlZQVlNTnBJcjdONFl0UkhhTFNQUWp2eWdhWndYRzU2QWV6bEhSVEJoTDhjVHFBPT0iOwoJInB1cmNoYXNlLWluZm8iID0gImV3b0pJbTl5YVdkcGJtRnNMWEIxY21Ob1lYTmxMV1JoZEdVdGNITjBJaUE5SUNJeU1ERTJMVEE1TFRFeUlEQTRPalUyT2pFd0lFRnRaWEpwWTJFdlRHOXpYMEZ1WjJWc1pYTWlPd29KSW5CMWNtTm9ZWE5sTFdSaGRHVXRiWE1pSUQwZ0lqRTBOek0yT1RVM056QTBOVEVpT3dvSkluVnVhWEYxWlMxcFpHVnVkR2xtYVdWeUlpQTlJQ0kwTURGa01XRXdOak00WlRFeFlqQTFNbVV5T0dFeE9HTmlOVEJtWWpWa05tRXhaVEEzWm1Kaklqc0tDU0p2Y21sbmFXNWhiQzEwY21GdWMyRmpkR2x2YmkxcFpDSWdQU0FpTWpVd01EQXdNakF4T0RZM056UTVJanNLQ1NKaWRuSnpJaUE5SUNJeExqTXVNQzR3SWpzS0NTSmhjSEF0YVhSbGJTMXBaQ0lnUFNBaU1URXlPVEEwTURBNE15STdDZ2tpZEhKaGJuTmhZM1JwYjI0dGFXUWlJRDBnSWpJMU1EQXdNREl3TVRnMk56YzBPU0k3Q2draWNYVmhiblJwZEhraUlEMGdJakVpT3dvSkltOXlhV2RwYm1Gc0xYQjFjbU5vWVhObExXUmhkR1V0YlhNaUlEMGdJakUwTnpNMk9UVTNOekEwTlRFaU93b0pJblZ1YVhGMVpTMTJaVzVrYjNJdGFXUmxiblJwWm1sbGNpSWdQU0FpTkRZd1FqUXhPREV0TmpRME5DMDBRVEJDTFRoQ1JUUXRSRVEwTVVWQ01qRkRNakJFSWpzS0NTSnBkR1Z0TFdsa0lpQTlJQ0l4TVRJNU1UWXpNekV3SWpzS0NTSjJaWEp6YVc5dUxXVjRkR1Z5Ym1Gc0xXbGtaVzUwYVdacFpYSWlJRDBnSWpneE56azBOekE1TWlJN0Nna2ljSEp2WkhWamRDMXBaQ0lnUFNBaVkyOXRMbU4wTlRFNE9DNUlkV0Z1VEdWUGVDNTVhVzU2YVRVaU93b0pJbkIxY21Ob1lYTmxMV1JoZEdVaUlEMGdJakl3TVRZdE1Ea3RNVElnTVRVNk5UWTZNVEFnUlhSakwwZE5WQ0k3Q2draWIzSnBaMmx1WVd3dGNIVnlZMmhoYzJVdFpHRjBaU0lnUFNBaU1qQXhOaTB3T1MweE1pQXhOVG8xTmpveE1DQkZkR012UjAxVUlqc0tDU0ppYVdRaUlEMGdJbU52YlM1amREVXhPRGd1U0hWaGJreGxUM2dpT3dvSkluQjFjbU5vWVhObExXUmhkR1V0Y0hOMElpQTlJQ0l5TURFMkxUQTVMVEV5SURBNE9qVTJPakV3SUVGdFpYSnBZMkV2VEc5elgwRnVaMlZzWlhNaU93cDkiOwoJInBvZCIgPSAiMjUiOwoJInNpZ25pbmctc3RhdHVzIiA9ICIwIjsKfQ==&unionid=0&key=987524f4ca789d2999c0025591893af9";
            PostWebRequest(url, str, Encoding.Default);
           
        }
        private string GetWebRequest(string postUrl,  Encoding dataEncode)
        {
            string ret = string.Empty;
            try
            {
                //byte[] byteArray = dataEncode.GetBytes(paramData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "GET";
                webReq.ContentType = "application/x-www-form-urlencoded";

                //webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                //newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                //newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return ret;
        }

        private string PostWebRequest(string postUrl, string paramData, Encoding dataEncode)
        {
            string ret = string.Empty;
            try
            {
                byte[] byteArray = dataEncode.GetBytes(paramData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";

                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return ret;
        }
    }
}