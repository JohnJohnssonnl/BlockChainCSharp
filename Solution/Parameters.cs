using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainCSharp
{
    public class Parameters
    {
        public Int64 MaxCoins           = 1000000;      //One million 
        public Int64 ExpectedBlockTime  = 30;           //Block time in seconds
        public Int64 Difficulty         = 0;            //Dynamically calculate

        //Premining is for losers

        public static Parameters GetParameter()
        {
            Parameters Parms = new Parameters();

            return Parms;
        }
    }
}
