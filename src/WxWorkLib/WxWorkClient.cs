using Newtonsoft.Json;
using WxWorkLib.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WxWorkLib
{
    public class WxWorkClient
    {
        public static Dictionary<int, TokenCacheModel> TokenCache = new Dictionary<int, TokenCacheModel>();

        public string CorpId { get; set; }
        public int AgentId { get; set; }
        public string AgentSecret { get; set; }

        public WxWorkClient(string corpId, int agentId, string agentSecret)
        {
            this.CorpId = corpId;
            this.AgentId = agentId;
            this.AgentSecret = agentSecret;
        }

        public TokenCacheModel GetToken()
        {
            TokenCacheModel cache = TokenCache.ContainsKey(AgentId) ? TokenCache[AgentId] :  null;
            if (cache != null && DateTime.Now < cache.ExpiresAt)
            {
                return cache;
            }

            using (var webClient = new WebClient())
            {
                var address = $"https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={CorpId}&corpsecret={AgentSecret}";
                var json = webClient.DownloadString(address);
                var result = JsonConvert.DeserializeObject<TokenResultModel>(json);
                if (result.ErrCode != 0)
                {
                    throw new Exception(result.ErrMsg);
                }

                var accessToken = result.AccessToken;
                var expiresAt = DateTime.Now.AddSeconds(result.ExpiresIn);
                cache = new TokenCacheModel { AccessToken = accessToken, ExpiresAt = expiresAt };
                TokenCache[AgentId] = cache;
                return cache;
            }
        }

        public void SendMessage<T>(T data)
        {
            var tokenCache = GetToken();
            string accessToken = tokenCache.AccessToken;

            string json = JsonConvert.SerializeObject(data);
            byte[] bytes = Encoding.UTF8.GetBytes(json);

            using (var webClient = new WebClient())
            {
                var address = $"https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={accessToken}";
                var result = webClient.UploadData(address, bytes);
            }
        }
    }
}
