// bundle everything into one exe file with .NET runtime (do it in Terminal (Ctrl + Shift + Ö))
// dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
Console.WriteLine("Version 2.0");
Console.WriteLine("Click Anything to Continue");
Console.ReadLine();

Player p1 = new();

Enemy e1 = new();
e1.name = "Bob";

string keepPlaying = "yes";

while (keepPlaying == "yes")
{
    Console.Clear();
    Console.WriteLine("Inside the game logic");
    Console.ReadLine();
    (p1, e1) = Character.TurnOrder(p1, e1);

    Console.Clear();
    Console.WriteLine("Do you want to continue playing");
    keepPlaying = Console.ReadLine();
}

Console.WriteLine("Outside the game logic");
Console.ReadLine();