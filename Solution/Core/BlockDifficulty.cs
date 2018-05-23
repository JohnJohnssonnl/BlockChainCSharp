using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainCSharp.Core
{
    public class BlockDifficulty
    {
        //Calculates block difficulty
        public static Int64 GetCurrentBlockDifficulty()
        {
            Int64 difficulty = 5;

            if (difficulty < Parameters.GetParameter().MinDifficulty)
            {
                //Possible difficulty attack, block
                difficulty = Parameters.GetParameter().MinDifficulty;
            }
            return difficulty;
        }
    }
}
