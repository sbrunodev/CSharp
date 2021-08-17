using System;

namespace LinqAndLambdaSoluctions
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PeopleService();

            var peoples = service.GetPeopleNamesAccordingToYearOfBirth(1980);

            foreach (var peopleName in peoples)
                Console.WriteLine(peopleName);

            Console.ReadKey();

        }
    }
}
