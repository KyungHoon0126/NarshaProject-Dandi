using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNetwork.Common
{
    public class ComDef
    {
        public enum LOGIN_STATS { DISCONNECT, CONNECT };

        //소켓 서버 주소
        public static string serverUrl { get; set; } //HOSTING

		public const int TIME_OUT = 30000;

        public static string DEFAULT_PROFILEIMAGE = @"/Assets/default.png";
        public static string DEFAULT_NOIMAGE = "/Assets/nophoto.jpg";
        public static string DEFAULT_GROUPIMAGE = "/Assets/group.png";
    }
}
