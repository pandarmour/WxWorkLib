using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WxWorkLib.Base;

namespace WxWorkLib.Message.Models
{
    public class MessageResponseModel : ResponseBaseModel
    {
        [JsonProperty(PropertyName = "invaliduser")]
        public string InvalidUser { get; set; }

        [JsonProperty(PropertyName = "invalidparty")]
        public string InvalidParty { get; set; }

        [JsonProperty(PropertyName = "invalidtag")]
        public string InvalidTag { get; set; }
    }
}
