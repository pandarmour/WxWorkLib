using System;
using System.Collections.Generic;
using System.Text;
using WxWorkLib.Base;

namespace WxWorkLib.Message.Models
{
    public class MessageReceiveModel: MessageReceiveBaseModel
    {
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public long MsgId { get; set; }
    }

    /// <summary>
    /// 文本消息
    /// </summary>
    public class MessageReceiveTextModel : MessageReceiveModel
    {
        /// <summary>
        /// 文本消息内容
        /// </summary>
        public CDataModel Content { get; set; }
    }

    /// <summary>
    /// 图片消息
    /// </summary>
    public class MessageReceiveImageModel : MessageReceiveModel
    {
        /// <summary>
        /// 图片链接
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 图片媒体文件id，可以调用获取媒体文件接口拉取，仅三天内有效
        /// </summary>
        public string MediaId { get; set; }
    }

    /// <summary>
    /// 语音消息
    /// </summary>
    public class MessageReceiveVoiceModel : MessageReceiveModel
    {
        /// <summary>
        /// 图片媒体文件id，可以调用获取媒体文件接口拉取，仅三天内有效
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format { get; set; }
    }

    /// <summary>
    /// 视频消息
    /// </summary>
    public class MessageReceiveVideoModel : MessageReceiveModel
    {
        /// <summary>
        /// 图片媒体文件id，可以调用获取媒体文件接口拉取，仅三天内有效
        /// </summary>
        public string MediaId { get; set; }

        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用获取媒体文件接口拉取数据，仅三天内有效
        /// </summary>
        public string ThumbMediaId { get; set; }
    }

    /// <summary>
    /// 位置消息
    /// </summary>
    public class MessageReceiveLocationModel : MessageReceiveModel
    {
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public double Location_X { get; set; }

        /// <summary>
        /// 地理位置经度
        /// </summary>
        public double Location_Y { get; set; }

        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public double Scale { get; set; }

        /// <summary>
        /// 地理位置信息
        /// </summary>
        public string Label { get; set; }
    }

    /// <summary>
    /// 链接消息
    /// </summary>
    public class MessageReceiveLinkModel : MessageReceiveModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 链接跳转的url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 封面缩略图的url
        /// </summary>
        public string PicUrl { get; set; }
    }
}
