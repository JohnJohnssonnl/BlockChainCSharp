using System.ServiceModel;
using System.ServiceModel.Web;

namespace Contracts
{
    [ServiceContract]
    public interface IService
    {
        //Add all wanted interaction endpoints 

        //String requests and JSON response
        [OperationContract]
        [WebGet(UriTemplate = "/GetBlockHash/{BlockID}",
            ResponseFormat = WebMessageFormat.Json)]
        string GetBlockHash(string BlockID);

        [OperationContract]
        [WebGet(UriTemplate = "/GetStatus/",
        ResponseFormat = WebMessageFormat.Json)]
        string GetStatus();

        //JSON requests and response
        [OperationContract]
        [WebInvoke(UriTemplate = "/WriteTransaction",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        bool WriteTransaction(object transaction);
    }
}