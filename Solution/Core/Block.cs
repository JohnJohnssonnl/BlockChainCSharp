using System;
using System.Collections.Generic;

namespace BlockChainCSharp.Core
{
    [Serializable]
    public class Block
    {
        private     Int64                       blockHeight;
        private     Hash                        parentHash;
        public      Hash                        blockHash;
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

        public Block CreateBlock(BlockChain _Chain, Hash _blockHash, DateTime _dateTimeStampBlock)
        {
            int                 blockTimeDrift;
            //Gets the height of the blockChain when creating a new block
            blockHeight = _Chain.GetHeight();
            blockHeight--;  //It's the number of blocks away from the Genesis, so 1 becomes 0
            //Create a new block
            Block ParentBlock = _Chain.GetBlock(blockHeight - 1);

            blockDateTimeStamp = _dateTimeStampBlock;                             //Always use UTC
            parentHash          = null;
            difficulty          = BlockDifficulty.GetCurrentBlockDifficulty();  //Determine and write block difficulty
            blockHash           = _blockHash;

            if (ParentBlock!=null)
            {
                parentHash = ParentBlock.GetHash();
                blockTimeDrift = (blockDateTimeStamp - ParentBlock.blockDateTimeStamp).Seconds;

                if (blockTimeDrift < Parameters.GetParameter().AllowedMinimalBlocktime)
                {
                    //Possible timewarp attack, block
                    Console.WriteLine("Block too fast, prohibit time warping");
                    throw new Exception("Block too fast");
                }
            }

            ObjectSerializerBlock.WriteBlockToBlob(this,this.blockHeight);
            //TODO: Should be used when retrieving blocks loading the chain....ObjectSerializerBlock.ReadBlobToBlock(this.blockHeight);

            return this;
        }

        private Hash GetHash()
        {
            return this.blockHash;
        }
    }
}
