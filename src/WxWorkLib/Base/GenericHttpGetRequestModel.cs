using System;
using System.Collections.Generic;
using System.Text;

namespace WxWorkLib.Base
{
    public class GenericHttpGetRequestModel
    {
        public string Module { get; set; }
        public string Action { get; set; }
        public object Params { get; set; }
    }

    public class GenericHttpPostRequestModel : GenericHttpGetRequestModel
    {
        public object Data { get; set; }
    }
}
