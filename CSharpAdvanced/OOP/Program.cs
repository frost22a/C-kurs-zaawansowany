using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            var userPermissions = UserPermissions.Create | UserPermissions.Delete; // dwójkowo 01 lub 10 daje 11
            Console.WriteLine(userPermissions);
            if ((userPermissions & UserPermissions.Create) == UserPermissions.Create) // (userPermissions & UserPermissions.Create) dwójkowo mamy 11 & 01, stąd wynik to 01, zatem równy UserPermissions.Create 
            {
                Console.WriteLine("ok");
            }
        }
    }

    
    public enum UserPermissions
    {
        // w wykładzie wyjasnione dlaczego należy brać watości dwójkowo - do | oraz &
        None = 0,  //dwójkowo 0
        Create = 1, // dwójkowo 1 
        Delete = 2, // dwójkowo 10 
        Write = 0b100,  // dwójkowo 100
        Read = 0b1000   // dwójkowo 1000
    }
}

