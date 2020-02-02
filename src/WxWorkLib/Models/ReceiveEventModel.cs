using WxWorkLib.Models.ReceiveMessageModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace WxWorkLib.Models
{
    public class ReceiveEventModel: ReceiveBaseModel
    {
        /// <summary>
        /// 事件类型：view
        /// </summary>
        public CDataModel Event { get; set; }

        /// <summary>
        /// 事件KEY值，设置的跳转URL
        /// </summary>
        public CDataModel EventKey { get; set; }
    }
}
