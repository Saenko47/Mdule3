using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MOD3
{
    internal class Director : Person
    {
        const string datepattern = @"^\d{4},\d{2},\d{2}$";
        DateTime dateOfBirth;

        public Director(string name, string surname, DateTime dateOfBirth) : base(name, surname)
        {
            this.dateOfBirth = Regex.IsMatch(dateOfBirth.ToString("yyyy,MM,dd"), datepattern) ? dateOfBirth : new DateTime(2006, 02, 07);
        }
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = Regex.IsMatch(value.ToString("yyyy,MM,dd"), datepattern) ? value : new DateTime(2006, 02, 07); }

        }
    }
}
