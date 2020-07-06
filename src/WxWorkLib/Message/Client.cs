using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WxWorkLib.Base;
using WxWorkLib.Message;
using WxWorkLib.Message.Models;

namespace WxWorkLib
{
    public partial class WxWorkClient: IClient
    {
        public MessageResponseModel MessageSend<T>(T message)
        {
            return HttpPost<MessageResponseModel>(new GenericHttpPostRequestModel
            {
                Module = "message",
                Action = "send",
                Data = message,
            });
        }
    }
}
