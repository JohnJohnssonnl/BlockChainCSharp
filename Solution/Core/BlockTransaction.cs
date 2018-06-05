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
        private Boolean isSigned;
        Guid            TransactionID;

        public BlockTransaction GenerateNewTransaction(  string      _sender,
                                                         string      _receiver,
                                                         double      _amount,
                                                         Int64       _blockHeight,
                                                         BlockChain  _chain,
                                                         byte[]      _privateKey, 
                                                         byte[]      _publicKey,
                                                         /*From here is optional*/
                                                         string      _description)
        {
            //TODO: Validate keys vs public address (_sender)
            if (_amount <= 0)
            {
                Console.WriteLine("Transaction has amount equal or less than 0, not allowed");
                return null;
            }
            if (_blockHeight == 0)
            {
                Console.WriteLine("Cannot add a transaction to the genesis block");
                return null;
            }

            if (!KeyManager.ValidateInput(_privateKey, _publicKey, _sender))
            {
                Console.WriteLine("Wrong keys were added for the transaction, transaction failed");
                return null;
            }

            Sender          = _sender;
            Receiver        = _receiver;
            Amount          = _amount;
            Description     = _description;
            blockHeight     = _blockHeight;
            TransactionID   = Guid.NewGuid();

            TransactionSigning Signing = new TransactionSigning();

            Signing.SignTransaction(TransactionID, _chain);

            isSigned        = true;

            _chain.AddTransactionToChainCue(this);  //new unconfirmed transaction

            return this;
        }

        public Boolean AddTransactionToBlock(BlockChain _chain, BlockTransaction _transAction)
        {
            TargetBlock = _chain.GetBlock(_transAction.blockHeight);

            if (TargetBlock == null)
            {
                throw new InvalidOperationException("Block you want to add the transaction to does not exist on the chain");
            }

            if (!_transAction.isSigned)
            {
                throw new InvalidOperationException("Transaction is not signed, cannot be added to the chain");
            }

            TargetBlock.AddTransaction(this);

            return true;
        }
    }
}
