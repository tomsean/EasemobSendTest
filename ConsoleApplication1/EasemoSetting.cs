using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Configuration;
namespace ConsoleApplication1
{
    public static class EasemoSetting
    {
        public static string EasemobHost = "https://a1.easemob.com";
        public static string EasemobOrgName = ConfigurationManager.AppSettings["easemobOrgName"];
        public static string EasemobAppName = ConfigurationManager.AppSettings["easemobAppName"];
        public static string EasemobClientId = ConfigurationManager.AppSettings["easemobClientID"];
        public static string EasemobClientSecret = ConfigurationManager.AppSettings["easemobClientSecret"];
    }
}
