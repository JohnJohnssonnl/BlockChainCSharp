using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using WebSocketSharp;
using WebSocketSharp.Net;

namespace BlockChainCSharp.TESTWEBSOCKET
{
    class TestWebSocket
    {
        public void StartServer()
        {
            var   WebSocketServer = new WebSocketServer(System.Net.IPAddress.IPv6Any, 3001);

        }
    }
}
