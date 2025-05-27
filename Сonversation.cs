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

            TimeSpan directorDaye = new TimeSpan(director.DateOfBirth.Ticks);
            TimeSpan span;
            NearestToDirectro[] nearestToDirectors = new NearestToDirectro[employees.Length];
            Employee closest = null;
            for (int k = 0; k < employees.Length; ++k)
            {
                span = new TimeSpan(employees[k].DateOfBirth.Ticks);
                TimeSpan diff = (span - directorDaye).Duration();
                nearestToDirectors[k] = new NearestToDirectro(diff, employees[k]);

            }
            Array.Sort(nearestToDirectors);
            return nearestToDirectors[0 + i].Employee;

        }
        public void GetCandidateToConversation()
        {

            int countOfCandidates = 0;
            Employee[] candidates = new Employee[5];
            Array.Sort(employees);
            candidates[countOfCandidates++] = employees[employees.Length - 1];
            for (int k = 0; k < employees.Length; ++k)
            {
                if (employees[k].workExperience == 0)
                {
                    candidates[countOfCandidates++] = employees[k];
                }
            }
            for (int k = 0; k < employees.Length; ++k)
            {
                if (employees[k].Building % 2 != 0 && employees[k].Apartment % 2 == 0)
                {
                    bool isDuplicate = false;
                    foreach (var cand in candidates)
                    {
                        if (employees[k] == cand)
                        {
                            isDuplicate = true;
                            break;
                        }
                    }
                    if (isDuplicate) continue;
                    candidates[countOfCandidates++] = employees[k];
                    break;
                }
            }
            for (int k = 0; k < employees.Length; ++k)
            {
                if (employees[k].Name == director.Name)
                {
                    bool isDuplicate = false;
                    foreach (var cand in candidates)
                    {
                        if (employees[k] == cand)
                        {
                            isDuplicate = true;
                            break;
                        }
                    }
                    if (isDuplicate) continue;
                    candidates[countOfCandidates++] = employees[k];
                    nameIsFound = true;
                }
            }
            if (!nameIsFound)
            {
                for (int k = 0; k < employees.Length; ++k)
                {
                    if (employees[k].Name == employees[k].dad.Name)
                    {
                        bool isDuplicate = false;
                        foreach (var cand in candidates)
                        {
                            if (employees[k] == cand)
                            {
                                isDuplicate = true;
                                break;
                            }
                        }
                        if (isDuplicate) continue;
                        candidates[countOfCandidates++] = employees[k];
                    }

                }
            }
            int i = -1;
            while (true)
            {

                Employee closest = FindClosestByBirthdate(i++);
                bool isDuplicate = false;
                foreach (var cand in candidates)
                {

                    if (closest == cand)
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                {
                    candidates[countOfCandidates++] = closest;
                    break;
                }
                else
                {
                    continue;
                }
            }
            Employee[] temp = new Employee[countOfCandidates];
            Array.Copy(candidates, temp, countOfCandidates);
            candidates = temp;
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
