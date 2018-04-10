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

        public Block GetBlock(Int64 _Height)
        {
            //Returns requested block
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

            //Add a new block to the chain
            ChainedBlocks[ChainedBlocks.Length] = newBlock.CreateBlock(this);
        }
    }
}
