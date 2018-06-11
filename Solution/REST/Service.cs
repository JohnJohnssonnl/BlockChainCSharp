using System;
using Contracts;
using System.ServiceModel;
using BlockChainCSharp.Core;

namespace BlockChainCSharp.REST
{
    public class Service : IService
    {
        public string GetStatus()
        {
            string ret = "Status OK";

            try
            {
                //Do some stuff to fetch data
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
            return ret;
        }

        public string GetBlockHash(string BlockId)
        {
            string blockHash = "TODO";

            try
            {
                //Do some stuff to fetch data
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
            return blockHash;
        }
        public bool WriteTransaction(BlockTransaction transaction)
        {
            try
            {
                //Do stuff with the new object of type transaction
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
            return true;
        }
    }
}