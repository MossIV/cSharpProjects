﻿Random random = new Random();

Console.WriteLine("Would you like to play? (Y/N)");
if (ShouldPlay()) 
{
    PlayGame();
}

void PlayGame() 
{
    var play = true;

    while (play) 
    {
        var target = -1;
        var roll = -1;

        roll = random.Next(1,7);
        target = random.Next(1,7);

        Console.WriteLine($"Roll a number greater than {target} to win!");
        Console.WriteLine($"You rolled a {roll}");
        Console.WriteLine(WinOrLose(roll, target));
        Console.WriteLine("\nPlay again? (Y/N)");

        play = ShouldPlay();


    }
}

string WinOrLose(int roll, int target){
    if(roll > target){
        return "You win!";
    }
    else{
        return "You lose!";
    }
}