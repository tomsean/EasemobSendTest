using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class EasemobMessage
    {
        // ReSharper disable once InconsistentNaming
        public string target_type { get; set; }
        // ReSharper disable once InconsistentNaming
        public List<string> target { get; set; }
        // ReSharper disable once InconsistentNaming
        public EasemobMsgContent msg { get; set; }
        // ReSharper disable once InconsistentNaming
        public string from { get; set; }
        // ReSharper disable once InconsistentNaming
        public Dictionary<string, string> ext { get; set; }
    }
    public class EasemobMsgContent
    {
        public string type { get; set; }
        public string action { get; set; }
    }
}
