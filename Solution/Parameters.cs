using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainCSharp
{
    public class Parameters
    {
        public Int64    MaxCoins                = 1000000;      //One million 
        public Int64    ExpectedBlockTime       = 30;           //Block time in seconds
        public Int64    Difficulty              = 0;            //Dynamically calculate
        public Int32    MinNumOfMiningRequests  = 1;            //Bare minimum of miners required for calculating the block (testing 1, but later at least 10)
        public double   ConsensusReachedPct     = 90.0;         //At which percentage is consensus on the new block reached? recommended 90%
        public double   MinimumFee              = 0.000001;     //Minimum fee for the miners on top of a block reward
        
        //Premining is for losers, no support for that kind of tricks

        public static Parameters GetParameter()
        {
            Parameters Parms = new Parameters();

            return Parms;
        }
    }
}
