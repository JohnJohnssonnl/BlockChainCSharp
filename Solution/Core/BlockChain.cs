using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Linq;
using System.Net.Sockets;

namespace BlockChainCSharp.Core
{
    [Serializable]
    public class BlockChain
    {
        private Block[]                     ChainedBlocks;
        private IList<BlockTransaction>     unconfirmedTransactions = new List<BlockTransaction>();
        private TransactionSigning[]        signedTransactions;

        //Placeholder stuff, later on when coding the estimated block interval, add some difficulty tricks to make it happen
        private void PeriodicCreateBlock()
        {
            var delay = Task.Run(async () =>
            {
                await Task.Delay(5000);
                GenerateBlock();
                PeriodicCreateBlock();
                Console.WriteLine(GetHeight());
            });
        }

        public void Genesis()
        {
            int x = 0;
            String userInput;
            ChainedBlocks = new Block[0];
            //This is where the blockChain starts (for now :-P)
            do
            {
                userInput = Console.ReadLine();
                if (userInput == "Save")
                {
                    ObjectSerializerBlockChain.WriteBlockChainToBlob(this);
                    ObjectSerializerBlockChain.ReadBlobToBlockChain(); //Just for testing

                    Console.WriteLine("BlockChain stored correctly");
                }
                else
                {
                    GenerateBlock();
                    Console.WriteLine("Current Block Height:" + GetHeight());
                }
            } while (x < 100);  //Never ending for now :-P
        }

        public Block GetBlock(Int64 _Height)
        {
            //Returns requested block
            if (_Height < 0)
                return null;    //Genesis block

            return ChainedBlocks[_Height];
        }
        public Int64 GetHeight()
        {
            //Returns the height of the blockChain (incremented when creating new blocks)
            return ChainedBlocks.Length;
        }

        public void GenerateBlock()
        {
            Block               newBlock = new Block();
            Hash                blockHash;
            BlockMiningManager  miningManager       = new BlockMiningManager();
            DateTime            dateTimeStampBlock  = DateTime.UtcNow;
            Hash prevBlockHash = ChainedBlocks.Length - 1 > -1? this.GetBlock(ChainedBlocks.Length - 1).blockHash: null;
            //Add a new block to the chain

            blockHash = miningManager.CalculateHash(prevBlockHash, unconfirmedTransactions, dateTimeStampBlock);                    //Create Hash (use difficulty)

            try
            {
                newBlock.CreateBlock(this, blockHash, dateTimeStampBlock); //Try
                Array.Resize(ref ChainedBlocks, ChainedBlocks.Length + 1);
                ChainedBlocks[ChainedBlocks.Length - 1] = newBlock;

                foreach (var item in unconfirmedTransactions)
                {
                    //Send unconfirmed transactions to block
                    newBlock.AddTransaction(item);
                }

                unconfirmedTransactions.Clear();    //Clear unconfirmed transactions
            }
            catch
            {
                Console.WriteLine("Skipped inserting block due to errors");
                return;
            }
        }

        public void AddTransactionToChainCue(BlockTransaction _transAction)
        {
            unconfirmedTransactions.Add(_transAction);
        }

        public void AddSignedTransactionToChain(TransactionSigning _TransactionSigning)
        {
            //Add signing to chain to counter double spending and stuff like that
            Array.Resize(ref signedTransactions, signedTransactions.Length + 1);
            signedTransactions[signedTransactions.Length - 1] = _TransactionSigning;
        }
    }
}
