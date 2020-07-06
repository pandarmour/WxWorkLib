using System;
using System.Collections.Generic;
using System.Text;
using WxWorkLib.Message.Models;

namespace WxWorkLib.Message
{
    interface IClient
    {
        MessageResponseModel MessageSend<T>(T message);
    }
}
