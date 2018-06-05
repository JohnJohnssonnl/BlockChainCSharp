using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainCSharp.Core
{
    [Serializable]
    public class TransactionSigning
    {
        public Guid     TransactionId;
        public Guid     SigningId;
        public DateTime SignDateTimeStamp;

        public void SignTransaction(Guid _TransactionId, BlockChain _chain)
        {
            SignDateTimeStamp   = DateTime.UtcNow;
            SigningId           = Guid.NewGuid();
            TransactionId       = _TransactionId;

            _chain.AddSignedTransactionToChain(this);
        }
    }
}
