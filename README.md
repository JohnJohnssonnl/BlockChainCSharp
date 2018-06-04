# BlockChainCSharp
Blockchain in C#<BR><BR>
Travis link: https://www.travis-ci.org/JohnJohnssonnl/BlockChainCSharp<BR>
Travis Build status:   ![alt text](https://travis-ci.org/JohnJohnssonnl/BlockChainCSharp.svg?branch=master)<BR><BR>

<B>Green securing the blockchain</b><BR><BR>
  <I>Background</I><BR>
POW (Proof Of Work) and POS (Proof Of Stake), both are really bad solutions to secure the blockchain for multiple reasons:
1)	The energy consumption required for “guessing” the correct hash. When blockchain technology becomes even more the standard, even more hashing power (more energy) is required to solve the block hash.
2)	The 51 % attack possibility. Basically the person/pool with the highest hashrate can perform a 51 % attack. This possibility cannot be ruled out, especially considering quantum computing
3)	Due to the fact that the person who guessed the hash correctly gets the reward, the richer will become richer and at the end, any household PC will never be able to keep up. This has to change.<BR><BR>
  <I>Solution</I><BR>
Implement a totally new way of securing the blockchain...Let's call it "Secured by Demand". Out of the pool of miners which applied for mining the chain, randomly x number of miners are selected after x time to secure a new block by calculate the hash of the transaction(s) within the block + the hash of the previous block. This calculation should be quite easy to solve (let’s say 1 second on average for a standard PC) and always end with the correct result (as it is not guessing as normally). If more than 90% of the results match, the block is validated (consensus reached), the block reward shared with the miners which came up with the correct answer and the faulty result miner(s) blacklisted). In this way we solve problem 1,2 and 3 in one go and be a “greener” chain than other blockchain technologies.


