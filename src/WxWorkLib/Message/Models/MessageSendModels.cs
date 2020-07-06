using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WxWorkLib.Message.Models
{
    public class MessageSendBaseModel
    {
        /// <summary>
        /// 指定接收消息的成员，成员ID列表（多个接收者用‘|’分隔，最多支持1000个）
        /// 特殊情况：指定为”@all”，则向该企业应用的全部成员发送
        /// </summary>
        [JsonProperty(PropertyName = "touser")]
        public string ToUser { get; set; }

        /// <summary>
        /// 指定接收消息的部门，部门ID列表，多个接收者用‘|’分隔，最多支持100个。
        /// 当touser为”@all”时忽略本参数
        /// </summary>
        [JsonProperty(PropertyName = "toparty")]
        public string ToParty { get; set; }

        /// <summary>
        /// 指定接收消息的标签，标签ID列表，多个接收者用‘|’分隔，最多支持100个。
        /// 当touser为”@all”时忽略本参数
        /// </summary>
        [JsonProperty(PropertyName = "totag")]
        public string ToTag { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty(PropertyName = "msgtype")]
        public string MsgType { get; set; }

        /// <summary>
        /// 企业应用的id，整型。
        /// 企业内部开发，可在应用的设置页面查看；
        /// 第三方服务商，可通过接口 获取企业授权信息 获取该参数值
        /// </summary>
        [JsonProperty(PropertyName = "agentid")]
        public int AgentId { get; set; }

        /// <summary>
        /// 表示是否开启重复消息检查，0表示否，1表示是，默认0
        /// </summary>
        [JsonProperty(PropertyName = "enable_duplicate_check")]
        public int EnableDuplicateCheck { get; set; }

        /// <summary>
        /// 表示是否重复消息检查的时间间隔，默认1800s，最大不超过4小时
        /// </summary>
        [JsonProperty(PropertyName = "duplicate_check_interval")]
        public int DuplicateCheckInterval { get; set; }
    }

    /// <summary>
    /// 文本消息
    /// </summary>
    public class MessageSendTextModel : MessageSendBaseModel
    {
        public MessageSendTextModel()
        {
            MsgType = "text";
        }

        [JsonProperty(PropertyName = "text")]
        public TextModel Text { get; set; }
        public class TextModel
        {
            /// <summary>
            /// 消息内容，最长不超过2048个字节，超过将截断（支持id转译）
            /// </summary>
            [JsonProperty(PropertyName = "content")]
            public string Content { get; set; }
        }

        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0
        /// </summary>
        [JsonProperty(PropertyName = "safe")]
        public int Safe { get; set; }

        /// <summary>
        /// 表示是否开启id转译，0表示否，1表示是，默认0
        /// </summary>
        [JsonProperty(PropertyName = "enable_id_trans")]
        public int EnableIdTrans { get; set; }
    }

    /// <summary>
    /// 图片消息
    /// </summary>
    public class MessageSendImageModel : MessageSendBaseModel
    {
        public MessageSendImageModel()
        {
            MsgType = "image";
        }

        [JsonProperty(PropertyName = "image")]
        public ImageModel Image { get; set; }
        public class ImageModel
        {
            /// <summary>
            /// 图片媒体文件id，可以调用上传临时素材接口获取
            /// </summary>
            [JsonProperty(PropertyName = "media_id")]
            public string MediaId { get; set; }
        }

        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0
        /// </summary>
        [JsonProperty(PropertyName = "safe")]
        public int Safe { get; set; }
    }

    /// <summary>
    /// 语音消息
    /// </summary>
    public class MessageSendVoiceModel : MessageSendBaseModel
    {
        public MessageSendVoiceModel()
        {
            MsgType = "voice";
        }

        [JsonProperty(PropertyName = "voice")]
        public VoiceModel Voice { get; set; }
        public class VoiceModel
        {
            /// <summary>
            /// 语音文件id，可以调用上传临时素材接口获取
            /// </summary>
            [JsonProperty(PropertyName = "media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// 视频消息
    /// </summary>
    public class MessageSendVideoModel : MessageSendBaseModel
    {
        public MessageSendVideoModel()
        {
            MsgType = "video";
        }

        [JsonProperty(PropertyName = "video")]
        public VideoModel Video { get; set; }
        public class VideoModel
        {
            /// <summary>
            /// 视频媒体文件id，可以调用上传临时素材接口获取
            /// </summary>
            [JsonProperty(PropertyName = "media_id")]
            public string MediaId { get; set; }

            /// <summary>
            /// 视频消息的标题，不超过128个字节，超过会自动截断
            /// </summary>
            [JsonProperty(PropertyName = "title")]
            public string Title { get; set; }

            /// <summary>
            /// 视频消息的描述，不超过512个字节，超过会自动截断
            /// </summary>
            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; }
        }

        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0
        /// </summary>
        [JsonProperty(PropertyName = "safe")]
        public int Safe { get; set; }
    }

    /// <summary>
    /// 文件消息
    /// </summary>
    public class MessageSendFileModel : MessageSendBaseModel
    {
        public MessageSendFileModel()
        {
            MsgType = "file";
        }

        [JsonProperty(PropertyName = "file")]
        public FileModel File { get; set; }
        public class FileModel
        {
            /// <summary>
            /// 文件id，可以调用上传临时素材接口获取
            /// </summary>
            [JsonProperty(PropertyName = "media_id")]
            public string MediaId { get; set; }
        }

        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0
        /// </summary>
        [JsonProperty(PropertyName = "safe")]
        public int Safe { get; set; }
    }

    /// <summary>
    /// 文本卡片消息
    /// </summary>
    public class MessageSendTextCardModel : MessageSendBaseModel
    {
        public MessageSendTextCardModel()
        {
            MsgType = "textcard";
        }

        [JsonProperty(PropertyName = "textcard")]
        public TextCardModel TextCard { get; set; }
        public class TextCardModel
        {
            public TextCardModel()
            {
                BtnTxt = "详情";
            }

            /// <summary>
            /// 标题，不超过128个字节，超过会自动截断（支持id转译）
            /// </summary>
            [JsonProperty(PropertyName = "title")]
            public string Title { get; set; }

            /// <summary>
            /// 描述，不超过512个字节，超过会自动截断（支持id转译）
            /// </summary>
            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; }

            /// <summary>
            /// 点击后跳转的链接。
            /// </summary>
            [JsonProperty(PropertyName = "url")]
            public string Url { get; set; }

            /// <summary>
            /// 按钮文字。 默认为“详情”， 不超过4个文字，超过自动截断。
            /// </summary>
            [JsonProperty(PropertyName = "btntxt")]
            public string BtnTxt { get; set; }
        }
    }

    /// <summary>
    /// 图文消息
    /// </summary>
    public class MessageSendNewsModel : MessageSendBaseModel
    {
        public MessageSendNewsModel()
        {
            MsgType = "news";
        }

        [JsonProperty(PropertyName = "news")]
        public NewsModel News { get; set; }
        public class NewsModel
        {
            /// <summary>
            /// 图文消息，一个图文消息支持1到8条图文
            /// </summary>
            [JsonProperty(PropertyName = "articles")]
            public ArticleModel[] Articles { get; set; }

            public class ArticleModel
            {
                /// <summary>
                /// 标题，不超过128个字节，超过会自动截断（支持id转译）
                /// </summary>
                [JsonProperty(PropertyName = "title")]
                public string Title { get; set; }

                /// <summary>
                /// 描述，不超过512个字节，超过会自动截断（支持id转译）
                /// </summary>
                [JsonProperty(PropertyName = "description")]
                public string Description { get; set; }

                /// <summary>
                /// 点击后跳转的链接。
                /// </summary>
                [JsonProperty(PropertyName = "url")]
                public string Url { get; set; }

                /// <summary>
                /// 图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图 1068*455，小图150*150。
                /// </summary>
                [JsonProperty(PropertyName = "picurl")]
                public string PicUrl { get; set; }
            }
        }

        /// <summary>
        /// 表示是否开启id转译，0表示否，1表示是，默认0
        /// </summary>
        [JsonProperty(PropertyName = "enable_id_trans")]
        public int EnableIdTrans { get; set; }
    }

    /// <summary>
    /// 图文消息（mpnews）
    /// </summary>
    public class MessageSendMPNewsModel : MessageSendBaseModel
    {
        public MessageSendMPNewsModel()
        {
            MsgType = "mpnews";
        }
        [JsonProperty(PropertyName = "mpnews")]
        public MPNewsModel MPNews { get; set; }
        public class MPNewsModel
        {
            /// <summary>
            /// 图文消息，一个图文消息支持1到8条图文
            /// </summary>
            [JsonProperty(PropertyName = "articles")]
            public ArticleModel[] Articles { get; set; }

            public class ArticleModel
            {
                /// <summary>
                /// 标题，不超过128个字节，超过会自动截断（支持id转译）
                /// </summary>
                [JsonProperty(PropertyName = "title")]
                public string Title { get; set; }

                /// <summary>
                /// 图文消息缩略图的media_id, 可以通过素材管理接口获得。此处thumb_media_id即上传接口返回的media_id
                /// </summary>
                [JsonProperty(PropertyName = "thumb_media_id")]
                public string ThumbMediaId { get; set; }

                /// <summary>
                /// 图文消息的作者，不超过64个字节
                /// </summary>
                [JsonProperty(PropertyName = "author")]
                public string Author { get; set; }

                /// <summary>
                /// 图文消息点击“阅读原文”之后的页面链接
                /// </summary>
                [JsonProperty(PropertyName = "content_source_url")]
                public string ContentSourceUrl { get; set; }

                /// <summary>
                /// 图文消息的内容，支持html标签，不超过666 K个字节（支持id转译）
                /// </summary>
                [JsonProperty(PropertyName = "content")]
                public string Content { get; set; }

                /// <summary>
                /// 图文消息的描述，不超过512个字节，超过会自动截断（支持id转译）
                /// </summary>
                [JsonProperty(PropertyName = "digest")]
                public string Digest { get; set; }
            }
        }

        /// <summary>
        /// 表示是否是保密消息，0表示可对外分享，1表示不能分享且内容显示水印，2表示仅限在企业内分享，默认为0；
        /// 注意仅mpnews类型的消息支持safe值为2，其他消息类型不支持
        /// </summary>
        [JsonProperty(PropertyName = "safe")]
        public int Safe { get; set; }

        /// <summary>
        /// 表示是否开启id转译，0表示否，1表示是，默认0
        /// </summary>
        [JsonProperty(PropertyName = "enable_id_trans")]
        public int EnableIdTrans { get; set; }
    }

    /// <summary>
    /// markdown消息
    /// </summary>
    public class MessageSendMarkdownModel : MessageSendBaseModel
    {
        public MessageSendMarkdownModel()
        {
            MsgType = "markdown";
        }

        [JsonProperty(PropertyName = "markdown")]
        public MarkdownModel Markdown { get; set; }
        public class MarkdownModel
        {
            /// <summary>
            /// markdown内容，最长不超过2048个字节，必须是utf8编码
            /// </summary>
            [JsonProperty(PropertyName = "content")]
            public string Content { get; set; }
        }
    }

    /// <summary>
    /// 小程序通知消息
    /// </summary>
    public class MessageSendMiniProgramNoticeModel : MessageSendBaseModel
    {
        public MessageSendMiniProgramNoticeModel()
        {
            MsgType = "miniprogram_notice";
        }

        [JsonProperty(PropertyName = "miniprogram_notice")]
        public MiniProgramNoticeModel MiniProgramNotice { get; set; }

        public class MiniProgramNoticeModel
        {

            /// <summary>
            /// 小程序appid，必须是与当前小程序应用关联的小程序
            /// </summary>
            [JsonProperty(PropertyName = "appid")]
            public string AppId { get; set; }

            /// <summary>
            /// 点击消息卡片后的小程序页面，仅限本小程序内的页面。该字段不填则消息点击后不跳转。
            /// </summary>
            [JsonProperty(PropertyName = "page")]
            public string Page { get; set; }

            /// <summary>
            /// 消息标题，长度限制4-12个汉字（支持id转译）
            /// </summary>
            [JsonProperty(PropertyName = "title")]
            public string Title { get; set; }

            /// <summary>
            /// 消息标题，消息描述，长度限制4-12个汉字（支持id转译）
            /// </summary>
            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; }

            /// <summary>
            /// 是否放大第一个content_item
            /// </summary>
            [JsonProperty(PropertyName = "emphasis_first_item")]
            public bool EmphasisFirstItem { get; set; }

            /// <summary>
            /// 消息内容键值对，最多允许10个item
            /// </summary>
            [JsonProperty(PropertyName = "content_item")]
            public ContentItemModel[] ContentItems { get; set; }
            public class ContentItemModel
            {
                /// <summary>
                /// 长度10个汉字以内
                /// </summary>
                [JsonProperty(PropertyName = "key")]
                public string Key { get; set; }

                /// <summary>
                /// 长度30个汉字以内（支持id转译）
                /// </summary>
                [JsonProperty(PropertyName = "value")]
                public string Value { get; set; }
            }
        }

        /// <summary>
        /// 表示是否开启id转译，0表示否，1表示是，默认0
        /// </summary>
        [JsonProperty(PropertyName = "enable_id_trans")]
        public int EnableIdTrans { get; set; }
    }

    /// <summary>
    /// 任务卡片消息
    /// </summary>
    public class MessageSendTaskCardModel : MessageSendBaseModel
    {
        public MessageSendTaskCardModel()
        {
            MsgType = "taskcard";
        }

        [JsonProperty(PropertyName = "taskcard")]
        public TaskCardModel TaskCard { get; set; }
        public class TaskCardModel
        {
            /// <summary>
            /// 标题，不超过128个字节，超过会自动截断（支持id转译）
            /// </summary>
            [JsonProperty(PropertyName = "title")]
            public string Title { get; set; }

            /// <summary>
            /// 描述，不超过512个字节，超过会自动截断（支持id转译）
            /// </summary>
            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; }

            /// <summary>
            /// 点击后跳转的链接。最长2048字节，请确保包含了协议头(http/https)
            /// </summary>
            [JsonProperty(PropertyName = "url")]
            public string Url { get; set; }

            /// <summary>
            /// 任务id，同一个应用发送的任务卡片消息的任务id不能重复，
            /// 只能由数字、字母和“_-@.”组成，最长支持128字节
            /// </summary>
            [JsonProperty(PropertyName = "task_id")]
            public string TaskId { get; set; }

            /// <summary>
            /// 按钮列表，按钮个数为为1 ~2个。
            /// </summary>
            [JsonProperty(PropertyName = "btn")]
            public BtnModel[] btns { get; set; }

            public class BtnModel
            {
                /// <summary>
                /// 按钮key值，用户点击后，会产生任务卡片回调事件，回调事件会带上该key值，
                /// 只能由数字、字母和“_-@.”组成，最长支持128字节
                /// </summary>
                [JsonProperty(PropertyName = "key")]
                public string Key { get; set; }

                /// <summary>
                /// 按钮名称
                /// </summary>
                [JsonProperty(PropertyName = "name")]
                public string Name { get; set; }

                /// <summary>
                /// 点击按钮后显示的名称，默认为“已处理”
                /// </summary>
                [JsonProperty(PropertyName = "replace_name")]
                public string ReplaceName { get; set; }

                /// <summary>
                /// 按钮字体颜色，可选“red”或者“blue”,默认为“blue”
                /// </summary>
                [JsonProperty(PropertyName = "color")]
                public string Color { get; set; }

                /// <summary>
                /// 按钮字体是否加粗，默认false
                /// </summary>
                [JsonProperty(PropertyName = "is_bold")]
                public bool IsBold { get; set; }
            }
        }

        /// <summary>
        /// 表示是否开启id转译，0表示否，1表示是，默认0
        /// </summary>
        [JsonProperty(PropertyName = "enable_id_trans")]
        public int EnableIdTrans { get; set; }
    }
}
