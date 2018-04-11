# BlockChainCSharp
Blockchain in C#<BR><BR>
Travis link: https://www.travis-ci.org/JohnJohnssonnl/BlockChainCSharp<BR>
Travis Build status:   ![alt text](https://travis-ci.org/JohnJohnssonnl/BlockChainCSharp.svg?branch=master)<BR><BR>
<B>Securing the blockchain</B><BR>
No POW (Proof Of Work) and POS (Proof Of Stake), both are really bad solutions in my opinion.<BR>
Going to implement a totally new way of securing the blockchain...Let's call it "Secured by Demand" --> Randomly x number of miners are selected after x time to create a new Block, this block should end up with a correct "Checksum" (the result of cryptographing data (transactions) + previous hash. If more than 90% of the blocks match, the block is validated, the block reward shared with the miners which came up with the correct answer and the faulty blocks blacklisted).<BR><BR>PROS: No need for constant calculating for a miner and eating power from the grid, therewith "Greener"<BR>CONS: We'll find along the way :-P

