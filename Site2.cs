using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bonus
{
    internal class Site
    {
        string cookie;
        string loginURL = "https://cabinet.ssau.ru/login";
        string chatsURL = "https://cabinet.ssau.ru/api/chats";

        public Site() 
        {
            string cookie = GetRequestCookey(loginURL);
        }

        public bool sendMessage(string chatId, string mess)
        {
            return (Post(chatsURL + "/" + chatId, new { message = mess}, "application/json") == HttpStatusCode.OK);
        }

        public string[] getChat(string chatId)
        {
            List<Chat> chat = JsonConvert.DeserializeObject<List<Chat>>(GetRequestWithCookie(chatsURL + "/" + chatId + "?limit=100&offset=0"));
            string[] result = new string[chat.Count];
            for (int i = 0; i < chat.Count; i++) 
            {
                result[i] = chat[i].author.name + "  " + chat[i].createdAt + "\r\n" + "Сообщение: " + chat[i].text + "\r\n\r\n";
            }
            return result;
        }

        public string[,] getChats() 
        {
            List<Chats> chats = JsonConvert.DeserializeObject<List<Chats>>(GetRequestWithCookie(chatsURL));
            string[,] result = new string[chats.Count,2];
            for (int i = 0; i < result.GetLength(0); i++) 
            {
                result[i,0] = chats[i].name;
                result[i,1] = chats[i].id.ToString();
            }
            return result;
        }

        public bool Login(string login, string password) 
        {
            return (Post(loginURL, new { name = login, password = password }, "application/json") == HttpStatusCode.OK);
        }


        public HttpStatusCode Post(string uri, object data, string contentType)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = contentType;
            request.Headers.Set("Cookie", cookie);
            request.Method = "POST";
            using (Stream requestBody = request.GetRequestStream())
            {
                requestBody.Write(dataBytes, 0, dataBytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                cookie = response.GetResponseHeader("Set-Cookie");
                return response.StatusCode;
            }
        }

        public string GetRequestWithCookie(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Method = "GET";
            request.Headers.Set("Cookie", cookie);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                cookie = response.GetResponseHeader("Set-Cookie");
                return reader.ReadToEnd();
            }
        }


        public string GetRequestCookey(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Method = "GET";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return response.GetResponseHeader("Set-Cookie");
            }
        }


    }
}
