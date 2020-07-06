using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using WxWorkLib.Base;

namespace WxWorkLib
{
    public partial class WxWorkClient
    {
        public static Dictionary<string, TokenCacheModel> TokenCache = new Dictionary<string, TokenCacheModel>();

        public string CorpId { get; set; }
        public string AgentId { get; set; }
        public string AgentSecret { get; set; }

        public WxWorkClient(string corpId, string agentId, string agentSecret)
        {
            this.CorpId = corpId;
            this.AgentId = agentId;
            this.AgentSecret = agentSecret;
        }

        public TokenCacheModel GetToken()
        {
            TokenCacheModel cache = TokenCache.ContainsKey(AgentId) ? TokenCache[AgentId] : null;
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

        public string GetAddress(string module, string action, object @params)
        {
            var tokenCache = GetToken();
            string accessToken = tokenCache.AccessToken;
            string address = $"https://qyapi.weixin.qq.com/cgi-bin/{module}/{action}?access_token={accessToken}";
            if (@params != null)
                foreach (PropertyInfo p in @params.GetType().GetProperties())
                {
                    address = $"{address}&{p.Name}={p.GetValue(@params)}";
                }
            Console.WriteLine(address);
            return address;
        }

        public T HttpGet<T>(GenericHttpGetRequestModel req)
        {
            string address = GetAddress(req.Module, req.Action, req.Params);
            using (var webClient = new WebClient())
            {
                var result = webClient.DownloadString(address);
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public T HttpPost<T>(GenericHttpPostRequestModel req)
        {
            string address = GetAddress(req.Module, req.Action, req.Params);

            string json = JsonConvert.SerializeObject(req.Data);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            using (var webClient = new WebClient())
            {
                var result = webClient.UploadData(address, bytes);
                string text = Encoding.UTF8.GetString(result);
                return JsonConvert.DeserializeObject<T>(text);
            }
        }
    }
}
