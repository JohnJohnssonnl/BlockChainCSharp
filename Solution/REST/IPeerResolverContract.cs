using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.PeerResolvers;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace BlockChainCSharp.REST
{
    [ServiceContractAttribute(Name = "IPeerResolverContract", Namespace = "http://schemas.microsoft.com/net/2006/05/peer/resolver",
    SessionMode = SessionMode.Allowed)]
        public interface IPeerResolverContract
    { 
    }
}
