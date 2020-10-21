using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // klasa anonimowa:

            var a = new
            {
                valueOFSomething = 5,
                valueOFSomethingElse = "some text"
            };

            //linq - zbiór metod, które używamy dla danych 

            var listOfInts = new List<int>
            {
                2, 5, 8, 1, 10, 15
            };

            var listOfStrings = new List<string>
            {
                "cos", "tam", "jest", "fajnego"
            };

            var listOfUsers = new List<User>
            {
                new User
                {
                    Name = "Patryk",
                    Age = 21,
                    Emial = "przykładowy@gmail.com"
                },
                new User
                {
                    Name = "Tomek",
                    Age = 24,
                    Emial = "przykładowy@gmail.com"
                },
                new User
                {
                    Name = "Krzysiek",
                    Age = 210,
                    Emial = "przykładowy2@gmail.com"
                },
            };

            //przykłady linq:

            foreach (var someInt in listOfInts)
            {
                if (someInt > 5)
                    Console.WriteLine(someInt);

            }

            //pierwsza wersja z linq: (tylko tutaj mamy Ienumerable jako wynik, czyli nie mamy utworzonej nowej listy)
            foreach (var someInt in listOfInts.Where(x => x > 5))
            {
                Console.WriteLine(someInt);
            }

            // druga wersja z linq: (plus stworzenie nowej listy jako wynik sortowania starej)

            var newList = listOfInts.Where(x => x > 5).ToList();

            var newList2 = listOfInts.Where((x, i) => x > 4 && i % 2 == 0);
            var newList3 = listOfInts.OrderByDescending(x => x).Take(2);

            //foreach za pomocą linq:

            listOfInts.ForEach(x =>
            {
                Console.WriteLine(x);
            }
            );

            // lub prościej:

            listOfInts.ForEach(x => Console.WriteLine(x));

            // kolejne przykłady użycia linq
            Console.WriteLine(listOfInts.Average());
            Console.WriteLine(listOfUsers.Average(x => x.Age));
            Console.WriteLine(listOfInts.FirstOrDefault(x => x > 30));
            Console.WriteLine(listOfInts.Where(x => x > 5).Skip(1).FirstOrDefault());

            var someStrings = listOfStrings.Skip(1).Take(2);

            var convertedIntsToStrings = listOfInts.Select(x => x.ToString()).ToList();

            var AddStrings = listOfStrings.Select(x => x + "costam").ToList();

            AddStrings.ForEach(x =>
            {
                Console.WriteLine(x);
            });

            Console.WriteLine("-------------------------------------");

            var viewModels = listOfUsers.Select(x => new UserViewModel
            {
                Name = x.Name,
                Age = x.Age,
                Emial = x.Emial,
                Title = GetUserTitle(x.Age)
            }).ToList();

            viewModels.ForEach(x =>
            {
                Console.WriteLine(x.Title);
            });

            Console.WriteLine("-------------------------------------");

            // przykład, gdzie mamy do wykonania 3 razy tą samą funkcję GetUserTitle (dodajemy dwie takie same propercje w UserViewModel)
            //korzystamy z klasy anonimowe, żeby wykonać funkcję tylko raz:

            var viewModels2 = listOfUsers
                .Select(x => new
            {
                UserData = x,
                Title = GetUserTitle(x.Age)
            })
                .Select(x => new UserViewModel
            {
                Name = x.UserData.Name,
                Age = x.UserData.Age,
                Emial = x.UserData.Emial,
                Title = x.Title,
                Title2 = x.Title,
                Title3 = x.Title
            }).ToList();
        }

        private static string GetUserTitle(int userAge) => userAge > 20 ? "Mr. " : "A boy "; // warunek "?" true ":" false - > zamiast if
    }
}
