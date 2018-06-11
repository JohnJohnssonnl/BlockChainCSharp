using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using Contracts;
using System.ServiceModel.PeerResolvers;

namespace BlockChainCSharp.REST
{
    class ServiceController
    {
        WebServiceHost              host;

        public void StartWebService()
        {
            //For now localhost
            String URI = "http://localhost:" + Convert.ToString(Parameters.GetParameter().HTTPPort);
         
            host = new WebServiceHost(typeof(Service), new Uri(URI));
            ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
            ServiceDebugBehavior stp = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            stp.HttpHelpPageEnabled = false;

            Console.WriteLine("Getting ready to start service at port: " + Parameters.GetParameter().HTTPPort);
            try
            {
                host.Open();
                Console.WriteLine("Service is online");
                Console.WriteLine("You can check whether the service is running as expected by navigating to: " + URI + "/GetStatus");
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
