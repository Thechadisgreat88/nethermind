﻿using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Nethermind.DiagTools
{
    class Program
    {
        public static async Task Main(params string[] args)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Post, "http://10.0.1.6:8545");
//            msg.Content = new StringContent("{\"jsonrpc\":\"2.0\",\"method\":\"rpc_modules\",\"params\":[],\"id\":1}");
            string transactionHash = "0x36b62e14ba46f29eb446c5e9ab61d61acafdcea8f402883532318a0659dda0c0";
            msg.Content = new StringContent($"{{\"jsonrpc\":\"2.0\",\"method\":\"debug_traceTransaction\",\"params\":[\"{transactionHash}\"],\"id\":42}}");
            msg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage rsp = await client.SendAsync(msg);
            string text = await rsp.Content.ReadAsStringAsync();
            File.WriteAllText("C:\\ropsten\\" + transactionHash + ".txt", text);
        }
    }
}
