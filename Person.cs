using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MOD3
{
    abstract internal class Person
    {
        const string pattern = @"^[А-ЯІЇЄ][а-яіїє]+$";
        public string name;
        public string surname;
        public Person(string name, string surname)
        {
            this.name = Regex.IsMatch(name, pattern) ? name : "No name";
            this.surname = Regex.IsMatch(surname, pattern) ? surname : "No name";
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (Regex.IsMatch(value, pattern))
                    name = value;
                else
                    name = "No name";
            }

        }
        public string Surname
        {
            get { return surname; }
            set
            {
                if (Regex.IsMatch(value, pattern))
                    surname = value;
                else
                    surname = "No name";
            }
        }
    }
}
