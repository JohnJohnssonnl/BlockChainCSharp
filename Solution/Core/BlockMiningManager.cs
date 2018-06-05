using System;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Digests;
using System.Collections.Generic;
using System.Text;

namespace BlockChainCSharp.Core
{
    class BlockMiningManager
    {
        //This class handles the mining of the block based on the transactions in a block + datetime stamp (utc) + previous hash

        public Hash CalculateHash(Hash _parentHash, IList<BlockTransaction> _unconfirmedTransactions, DateTime _dateTimeStampBlock)
        {
            byte[] Input = BlockMiningManager.GenerateBytes(_parentHash!=null? Convert.ToString(_parentHash.GetHashCode()):"", _dateTimeStampBlock.ToString(), Convert.ToString(_unconfirmedTransactions.GetHashCode()));

            //Design decision, vary difficulty by using PBKDF2 or maintain SHA3 256...later to be decided
            Sha3Digest digest = new Sha3Digest(256);
            digest.BlockUpdate(Input, 0, Input.Length);
            byte[] result = new byte[32];
            digest.DoFinal(result, 0);

            return new Hash(result);
        }

        public static byte[] GenerateBytes(string _parentHash, string _DateTimeStampStr, string _Transactions)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(_parentHash + _DateTimeStampStr + _Transactions);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            return hash;
        }
    }
}
