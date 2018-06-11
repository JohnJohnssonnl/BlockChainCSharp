using System.ServiceModel;
using System.ServiceModel.Web;
using BlockChainCSharp.Core;

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

        //JSON requests and response
        [OperationContract]
        [WebInvoke(UriTemplate = "/WriteTransaction",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        bool WriteTransaction(BlockTransaction transaction);
    }
}