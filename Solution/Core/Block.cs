using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Crypto.Digests;

namespace BlockChainCSharp.Core
{
    public class Block
    {
        private Int64 blockNumber;
        private Hash  parentHash;

        public Boolean IsGenesisBlock()
        {
            //Returns whether we are working with the genesis block
            return (this.blockNumber == 0 && this.parentHash == null);
        }

    }
}
