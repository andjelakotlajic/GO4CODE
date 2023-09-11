//                                      prvi zadatak

//while (true)
//{
//    Console.WriteLine("Unesite broj ili x ako zelite da se program prekine: ");
//    string unos = Console.ReadLine();

//    if (unos == "x")
//    {
//        break;
//    }else if (!int.TryParse(unos,out int broj))
//    {
//        Console.WriteLine("Niste upisali broj.");
//    }
//    else
//    {
//        Console.WriteLine(int.Parse(unos) * int.Parse(unos));
//    }

//}

//                                           drugi zadatak

//Console.WriteLine("Unesite koliko brojeva fibonacijevog niza zelite da ispisete: ");
//int unos = int.Parse(Console.ReadLine());

//if(unos > 0)
//{

//    for(int i = 0; i < unos; i++)
//    {
//        if (i == 0 || i == 1)
//        {
//            Console.WriteLine(i);
//        }
//        else
//        {
//            Console.WriteLine((i-1)+(i-2));
//        }
//    }
//}

//                                  treci zadatak


//var numbers = Enumerable.Range(1, 10);

//Console.WriteLine("Unesite broj sa kojim zelite da promerite deljivost u nizu: ");
//int broj = int.Parse(Console.ReadLine());

////var result = 
////    from num in numbers
////    where num % broj == 0
////    select num;

//var result1 = numbers.Where(num => num % broj == 0);

//foreach(var num in result1) { 
//    Console.WriteLine(num);
//}


//                              cetvrti, peti i sesti zadatak



var people = new List<Osoba>()
{
    new Osoba("Aleksa", 21, Pol.Musko),
    new Osoba("Andjela", 22, Pol.Zensko),
    new Osoba("Veljko", 26, Pol.Musko),
    new Osoba("Vojkan", 50, Pol.Musko),
    new Osoba("Gaga", 49, Pol.Zensko)
};

var resultSesti = people.GroupBy(p => p.polOsobe);

foreach (var group in resultSesti)
{
    Console.WriteLine($"Grupa: {group.Key}");
    foreach (var person in group)
    {
        Console.WriteLine($"Ime: {person.v1}, Dob: {person.v2}");
    }
}


var resultsPeti = people.OrderByDescending(p => p.v2).ToList();
foreach (var person in resultsPeti)
{
    Console.WriteLine(person.v1);
}

public enum Pol
{
    Musko,
    Zensko
}



class Osoba
{
    public string v1;
    public int v2;
    public Pol polOsobe;

    public Osoba(string v1, int v2, Pol polOsobe)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.polOsobe = polOsobe;
    }

}



