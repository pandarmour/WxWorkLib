using System;
using System.Collections.Generic;
using System.Text;

namespace WxWorkLib.Models.ReceiveMessageModels
{
    public class ReceiveBaseModel
    {
        /// <summary>
        /// 企业微信CorpID
        /// </summary>
        public CDataModel ToUserName { get; set; }

        /// <summary>
        /// 成员UserID
        /// </summary>
        public CDataModel FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间（整型）
        /// </summary>
        public int CreateTime { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public CDataModel MsgType { get; set; }

        /// <summary>
        /// 企业应用的id，整型。可在应用的设置页面查看
        /// </summary>
        public int AgentID { get; set; }
    }
}
