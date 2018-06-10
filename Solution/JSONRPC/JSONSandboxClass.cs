using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonRPC;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using BlockChainCSharp;

namespace MonetaVerdeWalletC
{
    class JSONSandboxClass
    {
        //This class contains all code to interact with RPC
        public static Boolean SendRPCJson(string _method, string _params)
        {
            string URL = "http://" + Parameters.GetParameter().HTTPPort + "/json_rpc";    //Get parameter for IP+Port
            Boolean ret = true;

            using (Client rpcClient = new Client(URL))
            {
                JArray parameters = JArray.Parse(@"['9000']");  //TODO: set parameters

                Request request = rpcClient.NewRequest(_method, parameters);
                GenericResponse response = rpcClient.Rpc(request);

                if (response != null)
                {
                    if (response.Result != null)
                    {
                        JToken result = response.Result;

                        Console.WriteLine("Connection success for method {0} : daemon says: {1}", _method, result);
                    }
                    else
                    {
                        Console.WriteLine(string.Format("Error in response, code:{0} message:{1}",
                        response.Error.Code, response.Error.Message));
                    }
                }
                else
                {
                    ret = false;
                    Console.WriteLine("Serious issues occured in connecting to the daemon, please check the setup or check if the daemon is running...");
                }
            }

            return ret;
        }
        public static void TestRPCJsonGet()
        {
            string URL = "http://" + Parameters.GetParameter().HTTPPort + "/getinfo";    //Get parameter for IP+Port + add method

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json";

            var response = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
    }
}

