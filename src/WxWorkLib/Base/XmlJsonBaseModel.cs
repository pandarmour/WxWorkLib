using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WxWorkLib.Base
{
    public class XmlJsonBaseModel<T>
    {
        [JsonProperty(PropertyName = "xml")]
        public T Xml { get; set; }
    }
}
