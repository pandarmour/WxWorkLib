using System;
using System.Linq;

namespace WxWorkLib.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string corpId = "";
                string agentId = "";
                string agentSecret = "";
                var client = new WxWorkClient(corpId, agentId, agentSecret);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
