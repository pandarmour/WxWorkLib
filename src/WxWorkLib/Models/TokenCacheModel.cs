using System;
using System.Collections.Generic;
using System.Text;

namespace WxWorkLib.Models
{
    public class TokenCacheModel
    {
        public string AccessToken { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}
