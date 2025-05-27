using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD3
{
    internal class NearestToDirectro: IComparable<NearestToDirectro>
    {
        public double near;
        public Employee employee;
        private object value;

        public NearestToDirectro(int near, Employee employee)
        {
            this.near = near;
            this.employee = employee;
        }

        public NearestToDirectro(object value, Employee employee)
        {
            this.value = value;
            this.employee = employee;
        }

        public double Near
        {
            get { return near; }
            set
            {
                if (value >= 0)
                    near = value;
                else
                    near = 0;
            }
        }
        public Employee Employee
        {
            get
            {
                return employee;
            }
            set { employee = value; }
        }
        public int CompareTo(NearestToDirectro other)
        {
            if (other == null) return 1;
            return this.near.CompareTo(other.near);
        }
    }
}
