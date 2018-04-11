using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainCSharp.Core
{
    [Serializable]
    public class BlockTransaction
    {
        //Placeholders: begin
        private string  Sender;
        private string  Receiver;
        private string  Description;
        //Placeholders: end
        private double  Amount;
        private Int64   blockHeight;
        private Block   TargetBlock;

        public Boolean GenerateNewTransaction(  string      _sender,
                                                string      _receiver,
                                                double      _amount,
                                                Int64       _blockHeight,
                                                BlockChain  _chain,
                                                /*From here is optional*/
                                                string      _description)
        {
            Boolean Ret = true;

            if (_amount < 0)
            {
                Console.WriteLine("Transaction has amount < 0, not allowed");
                return false;
            }
            if (_blockHeight == 0)
            {
                Console.WriteLine("Cannot add a transaction to the genesis block");
                return false;
            }

            Sender      = _sender;
            Receiver    = _receiver;
            Amount      = _amount;
            Description = _description;
            blockHeight = _blockHeight;

            _chain.AddTransactionToChainCue(this);  //new unconfirmed transaction

            return Ret;
        }

        public Boolean AddTransactionToBlock(BlockChain _chain, BlockTransaction _transAction)
        {
            TargetBlock = _chain.GetBlock(_transAction.blockHeight);

            if (TargetBlock == null)
            {
                throw new InvalidOperationException("Block you want to add the transaction to does not exist on the chain");
            }

            TargetBlock.AddTransaction(this);

            return true;
        }
    }
}
