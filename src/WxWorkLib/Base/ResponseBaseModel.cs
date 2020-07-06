using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WxWorkLib.Base
{
    public class ResponseBaseModel
    {
        [JsonProperty(PropertyName = "errcode")]
        public int ErrorCode { get; set; }

        [JsonProperty(PropertyName = "errmsg")]
        public string ErrorMessage { get; set; }
    }
}
