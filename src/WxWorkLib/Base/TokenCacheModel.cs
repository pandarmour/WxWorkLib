using System;
using System.Collections.Generic;
using System.Text;

namespace WxWorkLib.Base
{
    public class TokenCacheModel
    {
        public string AccessToken { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}
