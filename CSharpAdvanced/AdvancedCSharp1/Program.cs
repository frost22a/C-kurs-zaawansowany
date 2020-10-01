using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace AdvancedCSharp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //wywołuyjemy funkcję:
            SomeFunction2(SomeFunction1);
            //przypisanie zmiennej do funkcji:
            var someVar = new DelegateName(SomeFunction1);
            // wywołanie zmiennej:
            someVar();

            //funkcje anonimowe, bez towrzenia funkcji "na sztywno", tylko wpisując ją w deklaracji delegata: 

            Delegate2 someVar2 = delegate (int a) { return 2; };

            // używając lambda (jest traktowana jako OBIEKT):

            Delegate2 someVar3 = (int a) => { return 2; };

            // po lewej stronie wyrażenia lambda parametry (jak nie ma używamy "()"), po prawej wyrażenie lub blok poleceń

            // najprosztsza postać:

            Delegate2 someVar4 = (a) => 2;

            // zamiast używać delegate public delegate int Delegate2(int a); możemy użyć Action, jeżeli funkcja nic nie zwraca, 
            // albo Func, jeżeli zwraca:

            Action<int> someVar5 = (a) => { };

            Func<int, int> someVar6 = (a) => 5;
            Func<int, int> someVar7 = (a) => { return 5; };

            // praktyczny przykład:

            var listOfStrings = new List<string>
            {
                "a", "b", "c", "d", "e", "f"
            };

            // funkcja -> pierwszy string, który zaczyna się od litery "b", wykorzystamy lambdę"
            var machingExpression = GetFirstOrDefault(listOfStrings, (someString) => { return someString.StartsWith("b"); });
            Console.WriteLine(machingExpression);
        }

        private static string GetFirstOrDefault(List<string> strings, Func<string, bool> functionToCheck)
        {
            foreach (var item in strings)
            {
                if (functionToCheck(item))
                {
                    return item;
                }
            }
            return null;
        }


        public delegate int Delegate2(int a);

        public delegate void DelegateName(); // aby wywoałć jedną funkcję w drugiej musimy użyć delegata -> zmiennej, która będzie
                                             // miała przypisaną funkcję i to waśnie delegata mozemy wywołać w funkcji:
        private static void SomeFunction1()
        {

        }
        private static void SomeFunction2(DelegateName delegateName)
        {
            
        }
    }
}
