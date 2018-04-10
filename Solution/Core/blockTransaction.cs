using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainCSharp.Core
{
    class blockTransaction
    {
        //Placeholders: begin
        private string Sender;
        private string Receiver;
        private string Description;
        //Placeholders: end
        private double Amount;
        private Int64  BlockId;

        public Boolean GenerateNewTransaction(  string  _sender, 
                                                string  _receiver, 
                                                double  _amount, 
                                                Int64   _blockId,
                                                /*From here is optional*/
                                                string _description)
        {
            Boolean Ret = true;

            if (_amount < 0)
            {
                Console.WriteLine("Transaction has amount < 0, not allowed");
                return false;
            }

            Sender      = _sender;
            Receiver    = _receiver;
            Amount      = _amount;
            Description = _description;
            BlockId     = _blockId;

            return Ret;
        }
    }
}
