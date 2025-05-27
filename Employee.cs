using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MOD3
{
    internal class Employee : Person, IComparable<Employee>
    {
        const string datepattern = @"^\d{4},\d{2},\d{2}$";
        const string adressPattern = @"^вул\. ([А-ЯІЇЄ][а-яіїє']+)( [А-ЯІЇЄ][а-яіїє']+)* буд\. \d+ кв\. \d{1,3} $";
        public int workExperience;
        public decimal desirebleSalary;
        public string adress;
        public int building;
        public int apartment;
        public string[] hobies;
        public DateTime dateOfBirth;
        public string fathername;
        public Father dad;
        public Mother mom;
        public int age => DateTime.Now.Year - dateOfBirth.Year;
        public Employee(string name, string surname, string fathername, DateTime dateOfBirth, int workExperience, decimal desirebleSalary, string adress, string[] Hobies, Father dad, Mother mom) : base(name, surname)
        {
            this.fathername = fathername;
            this.dateOfBirth = Regex.IsMatch(dateOfBirth.ToString("yyyy,MM,dd"), datepattern) ? dateOfBirth : new DateTime(2006, 02, 07);
            this.workExperience = workExperience;
            this.desirebleSalary = desirebleSalary;
            this.adress = Regex.IsMatch(adress, adressPattern) ? adress : "вул. Сагайдачного буд. 20 кв. 88 ";
            this.building = GetBuilding();
            this.apartment = GetApartment();
            this.hobies = Hobies;
            this.dad = dad;
            this.mom = mom;
        }

        public int GetBuilding()
        {
            string[] parts = adress.Split(' ');
            int build = 0;
            for (int k = 0; k < parts.Length; ++k)
            {
                if (parts[k] == "буд.")
                {
                    return int.Parse(parts[k + 1]);
                }

            }
            return 0;


        }
        public int GetApartment()
        {
            string[] parts = adress.Split(' ');
            int apart = 0;
            for (int k = 0; k < parts.Length; ++k)
            {
                if (parts[k] == "кв.")
                {
                    return int.Parse(parts[k + 1]);
                }

            }
            return 0;
        }
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = Regex.IsMatch(value.ToString("yyyy,MM,dd"), datepattern) ? value : new DateTime(2006, 02, 07); }

        }
        public int WorkExperience
        {
            get { return workExperience; }
            set { workExperience = value >= 0 ? value : 0; }
        }
        public decimal DesirebleSalary
        {
            get { return desirebleSalary; }
            set { desirebleSalary = value >= 0 ? value : 0; }
        }
        public Father Dad
        {
            get { return dad; }
            set { dad = value; }
        }
        public Mother Mom
        {
            get { return mom; }
            set { mom = value; }
        }
        public string thisAdress
        {
            get { return adress; }
            set
            {
                if (Regex.IsMatch(value, adressPattern))
                    adress = value;
                else
                    adress = "вул. Невідома буд. 0 кв. 0";
            }
        }
        public int Building
        {
            get { return building; }
            set { building = value >= 0 ? value : 0; }
        }
        public int Apartment
        {
            get { return apartment; }
            set { apartment = value >= 0 ? value : 0; }
        }
        public string[] Hobies
        {
            get { return Hobies; }
            set
            {
                if (value.Length > 0)
                    Hobies = value;
                else
                    Hobies = new string[] { "No hobies" };
            }
        }
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < hobies.Length)
                    return hobies[index];
                else
                    return "No hobies";
            }
            set
            {
                if (index >= 0 && index < hobies.Length)
                {
                    if (!string.IsNullOrEmpty(value))
                        hobies[index] = value;
                    else
                        hobies[index] = "No hobies";
                }
            }
        }
        public int CompareTo(Employee? other)
        {
            if (other == null) return 1;
            if (this.workExperience > other.workExperience) return 1;
            if (this.workExperience < other.workExperience) return -1;
            return 0;
        }
        public override string ToString()
        {
            return $"{name} {surname} {fathername} {dateOfBirth.ToString("yyyy,MM,dd")} {workExperience} {desirebleSalary} {adress} {string.Join(", ", hobies)}";

        }
    }
}
