using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using Contracts;

namespace BlockChainCSharp.REST
{
    class ServiceController
    {
        WebServiceHost host;

        public void StartWebService()
        {
            String URI = "http://localhost:" + Convert.ToString(Parameters.GetParameter().HTTPPort);

            host = new WebServiceHost(typeof(Service), new Uri(URI));
            ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
            ServiceDebugBehavior stp = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            stp.HttpHelpPageEnabled = false;
            try
            {
                host.Open();
                Console.WriteLine("Service is up and running");
            }
            catch
            {
                Console.WriteLine("Couldn't start service");
            }
        }

        public void StopWebService()
        {
            try
            {
                host.Close();
                Console.WriteLine("Service is closed correctly");
            }
            catch
            {
                Console.WriteLine("Couldn't stop service");
            }
        }
    }
}
