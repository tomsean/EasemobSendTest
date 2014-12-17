using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class EasemobTokenResponse
    {
        // ReSharper disable once InconsistentNaming
        public string Access_Token { get; set; }
        // ReSharper disable once InconsistentNaming
        public long Expires_In { get; set; }
        public string Application { get; set; }
    }
}
