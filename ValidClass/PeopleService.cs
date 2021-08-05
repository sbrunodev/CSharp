using System;
using System.Collections.Generic;
using System.Text;

namespace ValidClass
{
    public class PeopleService
    {
        private List<string> _errorsList;

        public PeopleService()
        {
            _errorsList = new List<String>();
        }

        public List<string> ValidPeoples(IEnumerable<PeopleDTO> list)
        {
            _errorsList = new List<string>();

            foreach (var people in list)
            {
                ValidateValue<string>(people.Name, "Name", true, true, 25);
                ValidateValue<int>(people.Age, "Age");
                ValidateValue<int>(people.Age, "Age");
                ValidateValue<int>("10A", "Age");
                ValidateValue<DateTime>(people.BirthDate, "BirthDate");
            }

            return _errorsList;
        }


        public string ValidateValue<T>(
            string value,
            string fieldName,
            bool isRequired = false,
            bool validateSize = false,
            int maxSize = 0
         )
        {
            if (isRequired || value.Length > 0)
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value))
                    _errorsList.Add($"O Campo {fieldName} não foi informado");
                else
                    if (validateSize && value.Length > maxSize)
                    _errorsList.Add($"O campo {fieldName} tem mais caracteres do que o esperado");


                if (typeof(T) != typeof(string))
                {
                    T valueType;
                    if (!TryParse<T>(value, out valueType))
                        _errorsList.Add($"O Campo {fieldName} está em um formato inválido");
                }
            }

            return "";
        }

        static bool TryParse<T>(string text, out T value)
        {
            value = default(T);

            try
            {
                value = (T)Convert.ChangeType(text, typeof(T));
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
