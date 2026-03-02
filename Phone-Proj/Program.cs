using System;
using ClassLibrary;

class Program
{
    static void Main()
    {
        var phone = new Phone("Robert", "123456789");

        while (true)
        {
            Console.WriteLine("\n1 - Add Contact");
            Console.WriteLine("2 - Call Contact");
            Console.WriteLine("0 - Exit");

            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Name: ");
                var name = Console.ReadLine();

                Console.Write("Number: ");
                var number = Console.ReadLine();

                phone.AddContact(name, number);
                Console.WriteLine("Contact added!");
            }
            else if (choice == "2")
            {
                Console.Write("Name: ");
                var name = Console.ReadLine();

                try
                {
                    Console.WriteLine(phone.Call(name));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (choice == "0")
            {
                break;
            }
        }
    }
}