using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WxWorkLib.Models
{
    public class CDataModel
    {
        [JsonProperty(PropertyName = "#cdata-section")]
        public string CDataSection { get; set; }
    }
}
