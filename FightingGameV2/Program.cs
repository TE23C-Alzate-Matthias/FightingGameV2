// bundle everything into one exe file with .NET runtime (do it in Terminal (Ctrl + Shift + Ö))
// dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

//      _______ ____      _____   ____      _      _____  _____ _______ 
//     |__   __/ __ \    |  __ \ / __ \    | |    |_   _|/ ____|__   __|
//        | | | |  | |   | |  | | |  | |   | |      | | | (___    | |   
//        | | | |  | |   | |  | | |  | |   | |      | |  \___ \   | |   
//        | | | |__| |   | |__| | |__| |   | |____ _| |_ ____) |  | |   
//        |_|  \____/    |_____/ \____/    |______|_____|_____/   |_|   
//                                                                      
//                                                                      
// 1. Add so if one is downed they cant attack
// 2. Add so you can customize your player with stats
// 3. Give the enemy stats easily
// 4. Add more different enemies to fight
// 5. Add an in between menu for the player to do stuff
//      1. Start Next Fight
//      2. Check Players Stats
//      3. Check Enemies Stats
//      4. Stat Menu To Reconfig Stats
//      4. Exit Game

Console.WriteLine("Version 2.0");
Console.WriteLine("Click Anything to Continue");

Player p1 = new();

Enemy e1 = new();
e1.name = "Bob";

string keepPlaying = "yes";

while (keepPlaying == "yes")
{
    Console.Clear();
    Console.WriteLine("Inside the game logic");
    Console.ReadLine();
    p1.TurnOrder(p1, e1);

    Console.Clear();
    Console.WriteLine("Do you want to continue playing [yes/no]");
    keepPlaying = Console.ReadLine();
    keepPlaying = keepPlaying.ToLower();
}

Console.WriteLine("Outside the game logic");
Console.ReadLine();