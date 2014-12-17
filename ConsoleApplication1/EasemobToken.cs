using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class EasemobToken
    {
        // ReSharper disable once InconsistentNaming
        public string grant_type = "client_credentials";
        // ReSharper disable once InconsistentNaming
        public string client_id = EasemoSetting.EasemobClientId;
        // ReSharper disable once InconsistentNaming
        public string client_secret = EasemoSetting.EasemobClientSecret;
    }
}
