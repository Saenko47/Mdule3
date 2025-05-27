using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD3
{
    internal class Father:Person, IEquatable<Father>
    {
        public Father(string name, string surname) : base(name, surname)
        {
        }
        public bool Equals(Father? other)
        {
            if (other == null) return false;
            return this.Name == other.Name && this.Surname == other.Surname;
        }

    }
}
