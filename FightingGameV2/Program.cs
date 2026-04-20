// bundle everything into one exe file with .NET runtime (do it in Terminal (Ctrl + Shift + Ö))
// dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

//      _______ ____      _____   ____      _      _____  _____ _______ 
//     |__   __/ __ \    |  __ \ / __ \    | |    |_   _|/ ____|__   __|
//        | | | |  | |   | |  | | |  | |   | |      | | | (___    | |   
//        | | | |  | |   | |  | | |  | |   | |      | |  \___ \   | |   
//        | | | |__| |   | |__| | |__| |   | |____ _| |_ ____) |  | |   
//        |_|  \____/    |_____/ \____/    |______|_____|_____/   |_|                                                                      
//                                                                      
// 7. Add a simple inventory for the player, with some items.
// 8. A bit better Logic for enemies decisions
// 9. Optimise different methods by splitting them or better code
//      1. Stats Method
// 10. Even better Logic for enemies decisions

using System.Text.Json;
Console.WriteLine("Version 2.0");
Console.WriteLine("Click Anything to Continue");
Console.ReadLine();
string e = File.ReadAllText("enemies.json");
List<Enemy> enemies = JsonSerializer.Deserialize<List<Enemy>>(e);

Player p1 = new();

string keepPlaying = "yes";

// the game logic
while (keepPlaying == "yes")
{   
    p1.ChooseName();
    Console.Clear();
    p1.Stats();
    foreach(Enemy enemy in enemies)
    {   
        enemy.FixHp();
        Menu.Intermission(p1, enemy);
        // check for if you have died and lost
        if (p1.StoryPoint == 4)
        {
            Console.WriteLine("You died and lost");
            Console.ReadKey();
            break;
        }
    }

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
// 4. Update so the attacks uses the stats (SPD is gonna be unusable for a long while)
// 5. Add more different enemies to fight
// 6. Add an in between menu for the player to do stuff
//      1. Check Players Stats
//      2. Check Enemies Stats
//      3. Start Next Fight
//      4. Exit Game                              