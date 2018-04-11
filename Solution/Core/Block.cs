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
        private     Int64                       blockHeight;
        private     Hash                        parentHash;
        private     Hash                        blockHash;
        private     DateTime                    blockDateTimeStamp;
        private     IList<BlockTransaction>     blockTransactions;  //One block has a list of transactions
        private     Int64                       difficulty;

        //Design decision, we do not keep balances of an address, instead the balance should be calculated from all transactions at the moment of sending coins
        //One may NOT send coins when calc. balance < 0 AND when blockHeight < actual blockheight (messing with the system)

        public Boolean IsGenesisBlock()
        {
            //Returns whether we are working with the genesis block
            return (this.blockHeight == 0 && this.parentHash == null);  //Both has to be true to validate as genesis block
        }

        //Add a transaction to the block
        public Boolean AddTransaction(BlockTransaction _Transaction)
        {
            Boolean ret = true;

            try
            {
                blockTransactions.Add(_Transaction);
            }
            catch
            {
                Console.WriteLine("Something went wrong when adding the transaction to the block");
                ret = false;
            }

            return ret;
        }

        public Block CreateBlock(BlockChain _Chain)
        {
            //Create a new block
            Block ParentBlock = _Chain.GetBlock(blockHeight - 1);

            blockDateTimeStamp  = DateTime.UtcNow;                              //Always use UTC
            blockHash           = CalculateHash();                              //Create Hash
            parentHash          = null;
            if (ParentBlock!=null)
            {
                parentHash = ParentBlock.GetHash();
            }
                      
            //Gets the height of the blockChain when creating a new block
            blockHeight         = _Chain.GetHeight();
            blockHeight--;  //It's the number of blocks away from the Genesis, so 1 becomes 0

            return this;
        }

        private Hash GetHash()
        {
            return this.blockHash;
        }

        private Hash CalculateHash()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            Sha3Digest digest = new Sha3Digest(256);
            byte[] bytes = new byte[32];

            rng.GetBytes(bytes);

            digest.BlockUpdate(bytes, 0, bytes.Length);
            byte[] result = new byte[32];
            digest.DoFinal(result, 0);

            return new Hash(result);
        }
    }
}
