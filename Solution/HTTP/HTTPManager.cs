using System;

namespace BlockChainCSharp.HTTP
{
    public class HTTPManager
    {
        public Int32 UsedHttpPort   = Parameters.GetParameter().HTTPPort;
        public Int32 UsedP2PPort    = Parameters.GetParameter().P2PPort;

        public void StartHTTPServer()
        {
            //Do nothing for now, starts the HTTP service
        }
    }
}
