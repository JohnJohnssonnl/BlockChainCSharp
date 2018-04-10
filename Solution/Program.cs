using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockChainCSharp.Core;

namespace BlockChainCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Core.BlockChain Chain = new Core.BlockChain();

            Chain.Genesis();    
        }
    }
}
