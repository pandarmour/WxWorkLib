# WxWorkLib

WxWorkLib封装了访问企业微信API的一些方法。

#### 接收应用消息与事件
```
[HttpPost]
public async Task Post([FromQuery]string msg_signature, [FromQuery]string timestamp, [FromQuery]string nonce)
{
    using StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
    var encrypt = await reader.ReadToEndAsync();

    logger.LogInformation(encrypt);
    string token = "<Token>", encodingAESKey = "<EncodingAESKey>", receiveId = "<企业ID>";

    string msg = null;
    var msgCrypt = new WXBizMsgCrypt(token, encodingAESKey, receiveId);
    // 解密Encrypt，得到明文的消息结构体
    msgCrypt.DecryptMsg(msg_signature, timestamp, nonce, encrypt, ref msg);

    XmlDocument doc = new XmlDocument();
    doc.LoadXml(msg);
    string json = JsonConvert.SerializeXmlNode(doc);
    var rcvModel = JsonConvert.DeserializeObject<XmlJsonBaseModel<ReceiveBaseModel>>(json);
    logger.LogInformation($"json: {json}");

    if (rcvModel.Xml.MsgType.CDataSection == "event")
    {
        return;
    }

    if (rcvModel.Xml.MsgType.CDataSection == "text")
    {
        var rcvMsgModel = JsonConvert.DeserializeObject<XmlJsonBaseModel<ReceiveMessageTextModel>>(json);
        logger.LogInformation($"Content: {rcvMsgModel.Xml.Content.CDataSection}");
        logger.LogInformation($"MsgId: {rcvMsgModel.Xml.MsgId}");
    }
}

```


#### 发送应用消息
```
string corpId = "<企业ID>";
int agentId = <AgentId>;
string agentSecret = "<AgentSecret>";

WxWorkClient wwClient = new WxWorkClient(corpId, agentId, agentSecret);
// 自动请求token并缓存
wwClient.SendMessage(new SendMessageTextModel
{
    ToUser = "<touser>",
    AgentId = agentId,
    Text = new SendMessageTextModel.TextModel { Content = $"你好, 现在是{DateTime.Now.ToLongTimeString()}" }
});
```
