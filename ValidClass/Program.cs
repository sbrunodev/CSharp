using System;
using System.Collections.Generic;

namespace ValidClass
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PeopleDTO> peopleList = new List<PeopleDTO>();
            peopleList.Add(new PeopleDTO()
            {
                Name = "P1",
                LastName = "",
                City = "",
                Age = "10",
                Email = "",
                BirthDate = "25/02/195"
            }
            );
            peopleList.Add(new PeopleDTO()
            {
                Name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                LastName = "",
                City = "",
                Age = "10",
                Email = "brunosilva.dev@outlook.com.br",
                BirthDate = "1995-2-25"
            }
            );
            peopleList.Add(new PeopleDTO()
            {
                Name = "P2",
                LastName = "",
                City = "",
                Age = "10",
                Email = "brunosilva.dev@outlook.com.br",
                BirthDate = "1995-0aaa2-25"
            }
            );

            PeopleService service = new PeopleService();
            var errorsList = service.ValidPeoples(peopleList);


            foreach(var error in errorsList)
            {
                Console.WriteLine(error);
            }

            Console.ReadKey();


        }
    }
}
