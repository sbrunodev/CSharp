using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqAndLambdaSoluctions
{
    public class PeopleService
    {
        public string[] GetPeopleNamesAccordingToYearOfBirth(int year)
        {
            var people = new[]
            {
                new {Name = "José", DataBirth = new DateTime(1982, 03, 27), Active = true},
                new {Name = "Leandro", DataBirth = new DateTime(1978, 04, 03), Active = true},
                new {Name = "Pedro", DataBirth = new DateTime(1980, 05, 24), Active = true},
            };

            return people
                .Where(x => x.DataBirth.Year >= year)
                .Select(x => x.Name).ToArray();
                
        }

    }
}
