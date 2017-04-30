using IISMonitor_Web;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace IISMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //MonitorHelper.MonitoringISS6AppPool();
            //Console.WriteLine("check over!");
            //string num = "12.01";

            //if (MyParse.ParseDecimal(num, 0) >= 1)
            //{
            //    Console.WriteLine(">1 " + MyParse.ParseDecimal(num, 0));
            //}
            //else
            //{
            //    Console.WriteLine("<1");
            //}
            //Console.ReadKey();

            //GregorianCalendar gc = new GregorianCalendar();
            //DateTime dt = DateTime.Parse("2015-03-07");
            //int weekLast = gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            //Console.WriteLine(string.Format("{0}={1}", dt.ToString(), weekLast));
            //dt = DateTime.Parse("2015-03-08");
            //weekLast = gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            //Console.WriteLine(string.Format("{0}={1}", dt.ToString(), weekLast));
            //dt = DateTime.Parse("2015-03-14");
            //weekLast = gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            //Console.WriteLine(string.Format("{0}={1}", dt.ToString(), weekLast));
            //dt = DateTime.Parse("2015-03-15");
            //weekLast = gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            //Console.WriteLine(string.Format("{0}={1}", dt.ToString(), weekLast));

            //string str = "ewoJInNpZ25hdHVyZSIgPSAiQWxRZDN3SVpFcjZQY3dDb3htdnhtVUJqQVBsYjR0UHJyRjg4dUJldkNNekxobW1qeDYyRmVWSGI0aVVjWlhZNEo2ajI4ME1pZnp1Z3JtSUdiRW9JY1YveXRQeXlrKzl5NThlZE5IY2RNMS9SbWhZdW8vT1JKeFJIZzgvNy9BWDgxQThvaU1KK3pseXh1cmtUYUR5VGVyK3lSZDRYeWUvaVZCN1d5OHlSbmZrK0FBQURWekNDQTFNd2dnSTdvQU1DQVFJQ0NCdXA0K1BBaG0vTE1BMEdDU3FHU0liM0RRRUJCUVVBTUg4eEN6QUpCZ05WQkFZVEFsVlRNUk13RVFZRFZRUUtEQXBCY0hCc1pTQkpibU11TVNZd0pBWURWUVFMREIxQmNIQnNaU0JEWlhKMGFXWnBZMkYwYVc5dUlFRjFkR2h2Y21sMGVURXpNREVHQTFVRUF3d3FRWEJ3YkdVZ2FWUjFibVZ6SUZOMGIzSmxJRU5sY25ScFptbGpZWFJwYjI0Z1FYVjBhRzl5YVhSNU1CNFhEVEUwTURZd056QXdNREl5TVZvWERURTJNRFV4T0RFNE16RXpNRm93WkRFak1DRUdBMVVFQXd3YVVIVnlZMmhoYzJWU1pXTmxhWEIwUTJWeWRHbG1hV05oZEdVeEd6QVpCZ05WQkFzTUVrRndjR3hsSUdsVWRXNWxjeUJUZEc5eVpURVRNQkVHQTFVRUNnd0tRWEJ3YkdVZ1NXNWpMakVMTUFrR0ExVUVCaE1DVlZNd2daOHdEUVlKS29aSWh2Y05BUUVCQlFBRGdZMEFNSUdKQW9HQkFNbVRFdUxnamltTHdSSnh5MW9FZjBlc1VORFZFSWU2d0Rzbm5hbDE0aE5CdDF2MTk1WDZuOTNZTzdnaTNvclBTdXg5RDU1NFNrTXArU2F5Zzg0bFRjMzYyVXRtWUxwV25iMzRucXlHeDlLQlZUeTVPR1Y0bGpFMU93QytvVG5STStRTFJDbWVOeE1iUFpoUzQ3VCtlWnRERWhWQjl1c2szK0pNMkNvZ2Z3bzdBZ01CQUFHamNqQndNQjBHQTFVZERnUVdCQlNKYUVlTnVxOURmNlpmTjY4RmUrSTJ1MjJzc0RBTUJnTlZIUk1CQWY4RUFqQUFNQjhHQTFVZEl3UVlNQmFBRkRZZDZPS2RndElCR0xVeWF3N1hRd3VSV0VNNk1BNEdBMVVkRHdFQi93UUVBd0lIZ0RBUUJnb3Foa2lHOTJOa0JnVUJCQUlGQURBTkJna3Foa2lHOXcwQkFRVUZBQU9DQVFFQWVhSlYyVTUxcnhmY3FBQWU1QzIvZkVXOEtVbDRpTzRsTXV0YTdONlh6UDFwWkl6MU5ra0N0SUl3ZXlOajVVUllISytIalJLU1U5UkxndU5sMG5rZnhxT2JpTWNrd1J1ZEtTcTY5Tkluclp5Q0Q2NlI0Szc3bmI5bE1UQUJTU1lsc0t0OG9OdGxoZ1IvMWtqU1NSUWNIa3RzRGNTaVFHS01ka1NscDRBeVhmN3ZuSFBCZTR5Q3dZVjJQcFNOMDRrYm9pSjNwQmx4c0d3Vi9abEwyNk0ydWVZSEtZQ3VYaGRxRnd4VmdtNTJoM29lSk9PdC92WTRFY1FxN2VxSG02bTAzWjliN1BSellNMktHWEhEbU9Nazd2RHBlTVZsTERQU0dZejErVTNzRHhKemViU3BiYUptVDdpbXpVS2ZnZ0VZN3h4ZjRjemZIMHlqNXdOelNHVE92UT09IjsKCSJwdXJjaGFzZS1pbmZvIiA9ICJld29KSW05eWFXZHBibUZzTFhCMWNtTm9ZWE5sTFdSaGRHVXRjSE4wSWlBOUlDSXlNREUxTFRBekxURTFJREU0T2pRMk9qTTVJRUZ0WlhKcFkyRXZURzl6WDBGdVoyVnNaWE1pT3dvSkluVnVhWEYxWlMxcFpHVnVkR2xtYVdWeUlpQTlJQ0ptWVRNMVpXWmtaRFJoWXpjMVpUQmlNakEwTVRFelpXTTBNRGcyT0dReU9EaGhPVFV3TlRZd0lqc0tDU0p2Y21sbmFXNWhiQzEwY21GdWMyRmpkR2x2YmkxcFpDSWdQU0FpTVRBd01EQXdNREUwTnpJeU9UazNOeUk3Q2draVluWnljeUlnUFNBaU1TNHdMakF1TUNJN0Nna2lkSEpoYm5OaFkzUnBiMjR0YVdRaUlEMGdJakV3TURBd01EQXhORGN5TWprNU56Y2lPd29KSW5GMVlXNTBhWFI1SWlBOUlDSXhJanNLQ1NKdmNtbG5hVzVoYkMxd2RYSmphR0Z6WlMxa1lYUmxMVzF6SWlBOUlDSXhOREkyTkRjd016azVNVFV6SWpzS0NTSjFibWx4ZFdVdGRtVnVaRzl5TFdsa1pXNTBhV1pwWlhJaUlEMGdJalJEUkRBMFFVTkZMVEZDTUVZdE5EUTVOQzA0TnpCQ0xUWXlRa0pETVRZMVF6Z3dOaUk3Q2draWNISnZaSFZqZEMxcFpDSWdQU0FpWTI5dExtTjBOVEU0T0M1MGIyNW5RbWxPYVhWT2FYVXVlV2x1ZW1rd0lqc0tDU0pwZEdWdExXbGtJaUE5SUNJNU56TXpNalF3TlRjaU93b0pJbUpwWkNJZ1BTQWlZMjl0TG1OME5URTRPQzUwYjI1blFtbE9hWFZPYVhWNWIzbHZJanNLQ1NKd2RYSmphR0Z6WlMxa1lYUmxMVzF6SWlBOUlDSXhOREkyTkRjd016azVNVFV6SWpzS0NTSndkWEpqYUdGelpTMWtZWFJsSWlBOUlDSXlNREUxTFRBekxURTJJREF4T2pRMk9qTTVJRVYwWXk5SFRWUWlPd29KSW5CMWNtTm9ZWE5sTFdSaGRHVXRjSE4wSWlBOUlDSXlNREUxTFRBekxURTFJREU0T2pRMk9qTTVJRUZ0WlhKcFkyRXZURzl6WDBGdVoyVnNaWE1pT3dvSkltOXlhV2RwYm1Gc0xYQjFjbU5vWVhObExXUmhkR1VpSUQwZ0lqSXdNVFV0TURNdE1UWWdNREU2TkRZNk16a2dSWFJqTDBkTlZDSTdDbjA9IjsKCSJlbnZpcm9ubWVudCIgPSAiU2FuZGJveCI7CgkicG9kIiA9ICIxMDAiOwoJInNpZ25pbmctc3RhdHVzIiA9ICIwIjsKfQ==";
            //string strmd5 = MD5encrypt(str);

            //string strDoubleMd5 = MD5encrypt(string.Format("^*I$R#Etl&_135120_130619_{0}", strmd5));
            //Console.WriteLine(strDoubleMd5);
            //strDoubleMd5 = MD5encrypt(string.Format("^*I$R#Etl&_135120_130619_29faacc112858a4f3c8fdd59943a8f8e"));
            //Console.WriteLine(strDoubleMd5);

            string str = "version=1&agent_id=1959951&agent_bill_id=m1503310012&agent_bill_time=20150331101831&pay_type=10&pay_amt=5.00&notify_url=http://pay.16m.com/notify_url.aspx&return_url=http://pay.16m.com/sureorder.aspx&user_ip=192_168_1_223&key=B2341251CE164641A55CB984";
            string str1 = MD5encrypt(str);
            //Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss"));
            Console.WriteLine(str1);

            Console.ReadKey();
        }

        /// <summary>
        /// base64编码
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
         static string EncryptBase64(string text)
        {
            byte[] bytes = Encoding.Default.GetBytes(text);
            //byte[] bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// base64解码
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
         static string DescryptBase64(string text)
         {
             byte[] outputb = Convert.FromBase64String(text);
             return Encoding.Default.GetString(outputb);
         }
         /// <summary>
         /// MD5加密 20130416增加
         /// </summary>
         /// <param name="str"></param>
         /// <returns></returns>
         static string MD5encrypt(string str)
         {
             System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
             byte[] data = md5.ComputeHash(System.Text.Encoding.GetEncoding("UTF-8").GetBytes(str));
             StringBuilder sBulider = new StringBuilder();
             for (int i = 0; i < data.Length; i++)
             {
                 sBulider.Append(data[i].ToString("x2"));
             }
             return sBulider.ToString();
         }
    }
}
