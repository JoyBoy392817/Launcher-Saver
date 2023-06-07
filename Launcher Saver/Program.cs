using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography.X509Certificates;
using Závěrečný_projekt___Launcher_Login_Saver;
Launchers instance = new Launchers();
bool loop = false;
string uloziste = $"{instance.Poles[instance.Choose]}.txt";
instance.Load(uloziste);
while (!loop)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine("MENU - Vyber si operaci");
    Console.WriteLine("----------------------------------------------------");
    Console.ResetColor();
    Console.WriteLine("1) Přídat / změnit přihlašovací údaje");
    Console.WriteLine("2) Vypsat údaje o vybraném launcheru");
    Console.WriteLine("3) Vypsat údaje o všech dostupných launcherech");
    Console.WriteLine("4) ukončit program");
    Console.WriteLine("----------------------------------------------------");
    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
    switch (keyInfo.Key)
    {
        case ConsoleKey.D1:
        case ConsoleKey.NumPad1:
            Console.Clear();
            instance.WriteDown();
            break;
        case ConsoleKey.D2:
            instance.ChooseInventory();
            break;
        case ConsoleKey.D3:
            Console.Clear();
            instance.InventoryShow();
            break;
        case ConsoleKey.D4:
            loop = true;
            break;
        case ConsoleKey.D5:
            instance.Save(uloziste);
            break;
        case ConsoleKey.D6:
            instance.Load(uloziste);
            break;
        default:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************");
            Console.WriteLine("Chyba při výběru");
            Console.WriteLine("*****************");
            Console.ResetColor();
            break;
    }
}
