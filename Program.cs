using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO.Pipes;
using System.Linq;

class Program
{
    class famousPeople
    {
        public string Name { get; set; }
        public int? BirthYear { get; set; } = null;
        public int? DeathYear { get; set; } = null;
    }

    static void Main(string[] args)
    {
        IList<famousPeople> stemPeople = new List<famousPeople>() {
            new famousPeople() { Name= "Michael Faraday", BirthYear=1791, DeathYear=1867 },
            new famousPeople() { Name= "James Clerk Maxwell", BirthYear=1831, DeathYear=1879 },
            new famousPeople() { Name= "Marie Skłodowska Curie", BirthYear=1867, DeathYear=1934 },
            new famousPeople() { Name= "Katherine Johnson", BirthYear=1918, DeathYear=2020 },
            new famousPeople() { Name= "Jane C. Wright", BirthYear=1919, DeathYear=2013 },
            new famousPeople() { Name = "Tu YouYou", BirthYear= 1930 },
            new famousPeople() { Name = "Françoise Barré-Sinoussi", BirthYear=1947 },
            new famousPeople() { Name = "Lydia Villa-Komaroff", BirthYear=1947 },
            new famousPeople() { Name = "Mae C. Jemison", BirthYear=1956 },
            new famousPeople() { Name = "Stephen Hawking", BirthYear=1942, DeathYear=2018 },
            new famousPeople() { Name = "Tim Berners-Lee", BirthYear=1955 },
            new famousPeople() { Name = "Terence Tao", BirthYear=1975 },
            new famousPeople() { Name = "Florence Nightingale", BirthYear=1820, DeathYear=1910 },
            new famousPeople() { Name = "George Washington Carver", DeathYear=1943 },
            new famousPeople() { Name = "Frances Allen", BirthYear=1932, DeathYear=2020 },
            new famousPeople() { Name = "Bill Gates", BirthYear=1955 }
        };

        //Part A
        var a = from celebraty in stemPeople
                    where celebraty.BirthYear > 1900
                    select celebraty;

        Console.WriteLine("Celebraties with birthdates after 1900:");
        foreach (var celebraty in a)
        {
            Console.WriteLine($"Name: {celebraty.Name}, Birth Year: {celebraty.BirthYear}");
        }
        Console.WriteLine();

        //Part B
        var b = from celebraty in stemPeople
                where celebraty.Name.ToLower().Count(c => c == 'l') >= 2
                select celebraty;
        Console.WriteLine("Celebraties with 2 lower case l's in their name:");
        foreach (var celebraty in b)
        {
            Console.WriteLine($"Name: {celebraty.Name}");
        }
        Console.WriteLine();

        //Part C
        var c = (from celebraty in stemPeople
                 where celebraty.BirthYear > 1950
                 select celebraty).Count();
        Console.WriteLine($"Number of Celebraties born after 1950: {c}");
        Console.WriteLine();

        //Part D
        var d = from celebraty in stemPeople
                where celebraty.BirthYear >= 1920 && celebraty.BirthYear <= 2000
                select celebraty;
        Console.WriteLine("Celebraties with birthdates between 1920 and 2000:");
        int count = 0;
        foreach (var celebraty in d)
        {
            Console.WriteLine($"Name: {celebraty.Name}, Birth Year: {celebraty.BirthYear}");
            count++;
        }
        Console.WriteLine();    
        Console.WriteLine($"Number of Celebraties with birthdates between 1920 and 2000: {count}");
        Console.WriteLine();

        //Part E
        var e = from celebraty in stemPeople
                orderby celebraty.BirthYear
                select celebraty;
        Console.WriteLine("Sorted List");
        foreach(var celebraty in e) 
        {
            Console.WriteLine($"Name: {celebraty.Name}, BirthYear: {celebraty.BirthYear}, DeathYear: {celebraty.DeathYear}");
        }
        Console.WriteLine();

        //Part F
        var f = from celebraty in stemPeople
                orderby celebraty.Name
                where celebraty.DeathYear > 1960 && celebraty.DeathYear < 2015
                select celebraty;
        Console.WriteLine("Celebraties that died between 1960 to 2015");
        foreach(var celebraty in f)
        {
            Console.WriteLine($"Name: {celebraty.Name}, DeathYear: {celebraty.DeathYear}");
        }
    }
}
