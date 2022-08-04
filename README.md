# DiceGameSimulator
Finding the optimal game strategy for the 3 dice game. https://groupgames101.com/3-dice-game

# Procedure

The goal of the game is to get the lowest scrore. Die faces are worth their shown amount except 3s are worth 0. You roll all 5 dice to start and then select to keep as many or as little of them as you would like, the only rule is you must keep at least one each roll. The person with the lowest score after evryone rolls is the winner. Winner goes first next time round. 

This app works by creating a common interface for diffrent stratagies and then simulating games to see which stratgy wins the most often. 

# Results

## Names 

The name of the stragey describes how it plays:

* TakeOnes X means start taking 1s or lower after X turns
* TakeTwos X Y means start taking 1s or lower after X turns and start taking 2s or lower after Y turns
* All stratigies will ignore the above if doing so means they lose 
	* Ex. the person before them had a final score of 5 and taking 5 twos would put them at 10

## Numbers

100,000 games all playing at once:

|Name			|Number of wins|
|---------------|--------------|
|TakeTwos 6 5   | 3271         |
|TakeTwos 6 4   | 3483         |
|TakeTwos 5 3   | 3538         |
|TakeTwos 5 4   | 3582         |
|TakeTwos 6 3   | 3618         |
|TakeTwos 6 2   | 3712         |
|TakeTwos 5 2   | 3829         |
|TakeTwos 5 1   | 3870         |
|TakeOnes 6     | 3926         |
|TakeOnes 5     | 3957         |
|TakeTwos 6 1   | 4050         |
|TakeTwos 4 3   | 4155         |
|TakeTwos 4 2   | 4560         |
|TakeTwos 4 1   | 4631         |
|TakeOnes 4     | 4764         |
|TakeTwos 3 2   | 5132         |
|TakeTwos 3 1   | 5426         |
|TakeOnes 3     | 5442         |
|TakeTwos 2 1   | 5959         |
|TakeOnes 2     | 5970         |
|TakeOnes 0     | 6528         |
|TakeOnes 1     | 6597         |

Every combination of 5 stratigies (of 22) playing each other 100 times

|Name			|Number of wins|
|---------------|--------------|
|TakeTwos 6 5   | 67908        |
|TakeTwos 6 4   | 85737        |
|TakeTwos 5 4   | 87098        |
|TakeTwos 6 3   | 92562        |
|TakeTwos 5 3   | 93883        |
|TakeTwos 6 2   | 98185        |
|TakeTwos 5 2   | 100876       |
|TakeTwos 6 1   | 100961       |
|TakeTwos 5 1   | 103309       |
|TakeOnes 6     | 110681       |
|TakeOnes 5     | 112068       |
|TakeTwos 4 3   | 114154       |
|TakeTwos 4 2   | 125403       |
|TakeTwos 4 1   | 130947       |
|TakeOnes 4     | 139600       |
|TakeTwos 3 2   | 140245       |
|TakeTwos 3 1   | 147403       |
|TakeOnes 0     | 148910       |
|TakeTwos 2 1   | 153992       |
|TakeOnes 3     | 155784       |
|TakeOnes 1     | 159442       |
|TakeOnes 2     | 164252       |
