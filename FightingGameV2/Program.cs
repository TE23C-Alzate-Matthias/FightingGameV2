// bundle everything into one exe file with .NET runtime (do it in Terminal (Ctrl + Shift + Ö))
// dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
Console.WriteLine("Version 2.0");
Console.WriteLine("Click Anything to Continue");
Console.ReadLine();

Player p1 = new();

Enemy e1 = new();

string keepPlaying = "yes";

while (keepPlaying == "yes")
{
    Console.Clear();
    Console.WriteLine("Inside the game logic");
    Console.ReadLine();
    keepPlaying = "";
    (p1, e1) = Character.TurnOrder(p1, e1);
}

Console.WriteLine("Outside the game logic");
Console.ReadLine();