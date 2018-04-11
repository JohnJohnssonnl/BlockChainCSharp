using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainCSharp.Core
{
    public class BlockChain
    {
        private Block[] ChainedBlocks;

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
            ChainedBlocks = new Block[0];
            //This is where the blockChain starts (for now :-P)
            do
            {
                Console.ReadLine();
                GenerateBlock();
                Console.WriteLine(GetHeight());
            } while (x < 100);
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
            Block newBlock = new Block();
            Array.Resize(ref ChainedBlocks, ChainedBlocks.Length + 1);
            //Add a new block to the chain
            ChainedBlocks[ChainedBlocks.Length -1] = newBlock.CreateBlock(this);
        }
    }
}
