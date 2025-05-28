using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD3
{
    internal class Сonversation
    {
        bool nameIsFound = false;
        public Employee[] employees;
        public Director director;
        public Сonversation(Employee[] employees, Director director)
        {
            this.employees = employees;
            this.director = director;
        }
        public Employee FindClosestByBirthdate(int i)
        {
            if (i < 0 || i >= employees.Length) return null;
int directorYear = director.DateOfBirth.Year;
            NearestToDirectro[] nearestToDirectors = new NearestToDirectro[employees.Length];
            for (int k = 0; k < employees.Length; ++k)
            {
                int yearDiff = Math.Abs(employees[k].DateOfBirth.Year - directorYear);
                nearestToDirectors[k] = new NearestToDirectro(yearDiff, employees[k]);
            }
            Array.Sort(nearestToDirectors);
            return nearestToDirectors[i].Employee;

        }
        public Employee GetCandidateByExp()
        {
            Employee[] temp = new Employee[employees.Length];
            Array.Copy(employees, temp, employees.Length);
            Array.Sort(temp);
            return temp[temp.Length - 1];
        }
        public Employee GetCandidateByZeroExp(Employee[] candidates)
        {
            for (int k = 0; k < employees.Length; ++k)
            {
                if (!candidates.Contains(employees[k]) && employees[k].WorkExperience == 0)
                {
                    return employees[k];
                }
               
            }
            return null;
        }
        public Employee GetCandidateByBuilding(Employee[] candidates)
        {
            for (int k = 0; k < employees.Length; ++k)
            {
                if (!candidates.Contains(employees[k]) && employees[k].Building % 2 != 0 && employees[k].Apartment % 2 == 0)
                {
                    return employees[k];
                }
            }
            return null;
        }
        public Employee GetCandidateByName(Employee[] candidates)
        {
            bool isFound = false;
            for (int k = 0; k < employees.Length; ++k)
            {
                if (!candidates.Contains(employees[k]) && employees[k].Name == director.Name)
                {
                    isFound = true;
                    return employees[k];
                    
                }
            }
            if (!isFound)
            {
                for (int k = 0; k < employees.Length; ++k)
                {
                    if (!candidates.Contains(employees[k]) && employees[k].dad != null && employees[k].Name == employees[k].dad.Name)
                    {
                        return employees[k];
                    }
                }
                
            }
            return null;
        }
        public Employee GetCandidateByDate(Employee[] candidates) {
            int i = 0;
            while (true)
            {

                Employee closest = FindClosestByBirthdate(i);
                if (closest == null) break;
                if (!candidates.Contains(employees[i]))
                {
                    return closest;
                }
                ++i;
               
            }
            return null;
        }
        public void GetCandidateToConversation()
        {

            Employee temp;
            Employee[] candidates = new Employee[5];
            int countOfCandidates = 0;
           
           candidates[countOfCandidates++] = GetCandidateByExp();
            temp = GetCandidateByZeroExp(candidates);
            if (temp != null)
            {
                candidates[countOfCandidates++] = temp;
            }
            temp = GetCandidateByBuilding(candidates);
            if (temp != null)
            {
                candidates[countOfCandidates++] = temp;
            }
            temp = GetCandidateByName(candidates);
            if (temp != null)
            {
                candidates[countOfCandidates++] = temp;
            }
            temp = GetCandidateByDate(candidates);
            if (temp != null)
            {
                candidates[countOfCandidates++] = temp;
            }



            Employee[] temp1 = new Employee[countOfCandidates];
            Array.Copy(candidates, temp1, countOfCandidates);
            candidates = temp1;
            Console.WriteLine("Кандидати на розмову:");
            foreach (var cand in candidates)
            {
               
                Console.WriteLine($"{cand.Name} {cand.Surname}, {cand.DateOfBirth.ToShortDateString()}, {cand.WorkExperience} років досвіду, бажана зарплата: {cand.DesirebleSalary} грн");
              
            }
            Console.WriteLine($"Кандидатів на розмову: {countOfCandidates}");
            Console.WriteLine($"////////////////////////");
            foreach(var emp in employees)
            {
                Console.WriteLine(emp.ToString());
            }
        }
    }
}
