using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var http = new HttpUtil();
            var headers = new Dictionary<string, string>
            {
                {"Content-Type","application/json"},
                {"Authorization","Bearer "+SetEasemobToken()}
            };
            var url = string.Format("{0}/{1}/{2}/messages", EasemoSetting.EasemobHost, EasemoSetting.EasemobOrgName, EasemoSetting.EasemobAppName);
            var easemobMessage = new EasemobMessage
            {
                target_type = "users",
                target=new List<string>(){"tommy1","tommy2","tommy654321"},
                msg = new EasemobMsgContent
                {
                    type = "cmd",
                    action = "testcmd"
                },
                ext = new Dictionary<string, string>
                {
                    {"Attr1", "hq.job attr1"},
                    {"Attr2", "v2"}
                },
                @from = "tommy123456"
            };
            var bodyData = JsonConvert.SerializeObject(easemobMessage);
            http.HttpPost<object>(url, bodyData, headers);
            //var url = string.Format("{0}/{1}/{2}/users/tommy2/contacts/users", EasemoSetting.EasemobHost, EasemoSetting.EasemobOrgName, EasemoSetting.EasemobAppName);
            
            //http.HttpGet<object>(url, null, headers);
        }
        private static string SetEasemobToken()
        {
            var tokenUrl = string.Format("{0}/{1}/{2}/token", EasemoSetting.EasemobHost, EasemoSetting.EasemobOrgName, EasemoSetting.EasemobAppName);
            var bodyData = JsonConvert.SerializeObject(new EasemobToken());
            var headers = new Dictionary<string, string> { { "Content-Type", "application/json" } };
            var easemobToken = new HttpUtil().HttpPost<EasemobTokenResponse>(tokenUrl, bodyData, headers);
            return easemobToken.Access_Token;
        }
    }
}
