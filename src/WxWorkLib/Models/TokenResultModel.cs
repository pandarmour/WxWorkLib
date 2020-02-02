using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WxWorkLib.Models
{
    public class TokenResultModel
    {
        /// <summary>
        /// 出错返回码，为0表示成功，非0表示调用失败
        /// </summary>
        [JsonProperty(PropertyName = "errcode")]
        public int ErrCode { get; set; }

        /// <summary>
        /// 返回码提示语
        /// </summary>
        [JsonProperty(PropertyName = "errmsg")]
        public string ErrMsg { get; set; }

        /// <summary>
        /// 获取到的凭证，最长为512字节
        /// </summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 凭证的有效时间（秒）
        /// </summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
    }
}
