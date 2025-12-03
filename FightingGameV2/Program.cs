// bundle everything into one exe file with .NET runtime (do it in Terminal (Ctrl + Shift + Ö))
// dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

//      _______ ____      _____   ____      _      _____  _____ _______ 
//     |__   __/ __ \    |  __ \ / __ \    | |    |_   _|/ ____|__   __|
//        | | | |  | |   | |  | | |  | |   | |      | | | (___    | |   
//        | | | |  | |   | |  | | |  | |   | |      | |  \___ \   | |   
//        | | | |__| |   | |__| | |__| |   | |____ _| |_ ____) |  | |   
//        |_|  \____/    |_____/ \____/    |______|_____|_____/   |_|                                                                      
//                                                                      
// 4. Update so the attacks uses the stats (SPD is gonna be unusable for a long while)
// 5. Add more different enemies to fight
// 6. Add an in between menu for the player to do stuff
//      1. Start Next Fight
//      2. Check Players Stats
//      3. Check Enemies Stats
//      4. Stat Menu To Reconfig Stats
//      4. Exit Game
// 7. A bit better Logic for enemies decisions
// 8. Optimise different methods by splitting them or better code
//      1. Stats Method
// 9. Even better Logic for enemies decisions

Console.WriteLine("Version 2.0");
Console.WriteLine("Click Anything to Continue");

Player p1 = new();

Enemy e1 = new();
e1.GiveStats("bob", 10, 5, 0, 0, 5, 5);

string keepPlaying = "yes";

while (keepPlaying == "yes")
{   
    Console.Clear();
    Console.WriteLine("Inside the game logic");
    p1.stats();
    Console.ReadLine();
    p1.TurnOrder(p1, e1);

    Console.Clear();
    Console.WriteLine("Do you want to continue playing [yes/no]");
    keepPlaying = Console.ReadLine();
    keepPlaying = keepPlaying.ToLower();
}

Console.WriteLine("Outside the game logic");
Console.ReadLine();

//      _____                       _      _     _   
//     |  __ \                     | |    (_)   | |  
//     | |  | | ___  _ __   ___    | |     _ ___| |_ 
//     | |  | |/ _ \| '_ \ / _ \   | |    | / __| __|
//     | |__| | (_) | | | |  __/   | |____| \__ \ |_ 
//     |_____/ \___/|_| |_|\___|   |______|_|___/\__|
//                                                   
// 1. Add so if one is downed they cant attack
// 2. Add so you can customize your player with stats
// 3. Give the enemy stats easily                                  