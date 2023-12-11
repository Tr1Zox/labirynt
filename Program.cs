using labirynt;

List<Labyrint> Labyrints= new List<Labyrint>();

int selectLabyrint(string title)
{
    Console.WriteLine(title);
    int i = 0;
    foreach (Labyrint b in Labyrints){
        Console.WriteLine(i + ". " + b.Name);
        i++;
    }

    int x;
    while (true) {
        Console.Write("Podaj labyrint:");
        try { x = Convert.ToInt32(Console.ReadLine()); }
        catch{
            Console.WriteLine("Zła wartość!");
            continue;
        }
        if (x < 0 || x > Labyrints.Count - 1){
            Console.WriteLine("Zła wartość!");
            continue;
        }
        break;
    }

    return x;
}

while(true){
    Console.Clear();
    Console.WriteLine("LabyrintUVovy");
    Console.WriteLine("1. Stwórz nowy labyrint");
    Console.WriteLine("2. Usuń labyrint");
    Console.WriteLine("3. Wyświetl labyrint");
    Console.WriteLine("4. Edytuj labyrint");
    Console.WriteLine("5. Wyjdź z programu");
    Console.Write("Twój wybór:");

    switch (Console.ReadLine()){
        case "1":
            Labyrints.Add(new Labyrint());
            break;

        case "2":
            Labyrints.RemoveAt(selectLabyrint("Usuwanie"));
            break;

        case "3":
            Labyrints[selectLabyrint("Wyświetlenie")].Wyświetlacz();
            Console.Write("Kliknij cokolwiek aby wrócić...");
            Console.ReadLine();
            break;

        case "4":
            Labyrint edit = Labyrints[selectLabyrint("Edytowanie")];
            edit.Wyświetlacz();
            edit.Zmień();
            Console.Write("Kliknij cokolwiek aby wrócić...");
            Console.ReadLine();
            break;

        case "5":
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Zła wartość!");
            Console.ReadLine();
            Console.Clear();
            break;
    }
}