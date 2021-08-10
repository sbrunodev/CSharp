using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Model
{
    public class GeneratePerson
    {
        public static People ReturnTypePeopleAccordingToNumber(int number)
        {
            People people;
            if (number % 2 == 0)
                people = new Client();
            else
                people = new Supplier();

            people.Nome = people.GetType() + number.ToString();

            return people;
        }

    }
}
