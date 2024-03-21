using System;

Random random = new Random();
Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;

// Console position of the player
int playerX = 0;
int playerY = 0;

// Console position of the food
int foodX = 0;
int foodY = 0;

// Available player and food strings
string[] states = { "('-')", "(^-^)", "(X_X)" };
string[] foods = { "@@@@@", "$$$$$", "#####" };

// Current player string displayed in the Console
string player = states[0];

// Index of the current food
int food = 0;

InitializeGame();
while (!shouldExit)
{
    if (TerminalResized())
    {
        shouldExit = true;
        Console.Clear();
        Console.WriteLine("Console was resized. Program exiting.");
        break;
    }
    if (CheckSpeedState())
    {
        Move(movespeed: false);
    }
    else
    {
        Move();
    }
    if (EatFood())
    {
        ShowFood();
        ChangePlayer();
    }
    if (CheckStopState())
    {
        FreezePlayer();
    }
}

// Returns true if the Terminal was resized 
bool TerminalResized()
{
    return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
}
bool CheckSpeedState()
{
    if (player == states[1])
    {
        return true;
    }
    else
    {
        return false;
    }
}
bool CheckStopState()
{
    if (player == states[2])
    {
        return true;
    }
    else
    {
        return false;
    }
}
bool EatFood()
{
    if (playerX == foodX & playerY == foodY)
    {
        return true;
    }
    else
    {
        return false;
    }

}
// Displays random food at a random location
void ShowFood()
{
    // Update food to a random index
    food = random.Next(0, foods.Length);

    // Update food position to a random location
    foodX = random.Next(0, width - player.Length);
    foodY = random.Next(0, height - 1);

    // Display the food at the location
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[food]);
}

// Changes the player to match the food consumed
void ChangePlayer()
{
    player = states[food];
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Temporarily stops the player from moving
void FreezePlayer()
{
    System.Threading.Thread.Sleep(1000);
    player = states[0];
}

// Reads directional input from the Console and moves the player
void Move(bool nondirectionalKey = false, bool movespeed = false)
{
    int lastX = playerX;
    int lastY = playerY;

    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.UpArrow:
            if (movespeed)
            {
                playerY -= 3;
            }
            else { playerY--; }
            break;
        case ConsoleKey.DownArrow:
            if (movespeed)
            {
                playerY += 3;
            }
            else { playerY++; }
            break;
        case ConsoleKey.LeftArrow:
            if (movespeed)
            {
                playerX -= 3;
            }
            else { playerX--; }
            break;
        case ConsoleKey.RightArrow:
            if (movespeed)
            {
                playerX += 3;
            }
            else { playerX++; }
            break;
        case ConsoleKey.Escape:
            shouldExit = true;
            break;
        default:
            if (nondirectionalKey)
            {
                shouldExit = true;
            }
            break;
    }

    // Clear the characters at the previous position
    Console.SetCursorPosition(lastX, lastY);
    for (int i = 0; i < player.Length; i++)
    {
        Console.Write(" ");
    }

    // Keep player position within the bounds of the Terminal window
    playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
    playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

    // Draw the player at the new location
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Clears the console, displays the food and player
void InitializeGame()
{
    Console.Clear();
    ShowFood();
    Console.SetCursorPosition(0, 0);
    Console.Write(player);
}