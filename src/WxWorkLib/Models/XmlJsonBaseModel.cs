using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WxWorkLib.Models
{
    public class XmlJsonBaseModel<T>
    {
        [JsonProperty(PropertyName = "xml")]
        public T Xml { get; set; }
    }
}
