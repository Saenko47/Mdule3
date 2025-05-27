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
        public void GetCandidateToConversation()
        {

            
            Employee[] candidates = new Employee[5];
            int countOfCandidates = 0;
            Employee[] temp = new Employee[employees.Length];
            Array.Copy(employees, temp, employees.Length);
            Array.Sort(temp);
           

            candidates[countOfCandidates++] = temp[temp.Length - 1];
            for (int k = 0; k < employees.Length; ++k)
            {
                if (employees[k].WorkExperience == 0)
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
                    if (isDuplicate) { continue; }
                    else
                    {
                        if (countOfCandidates < candidates.Length)
                        {
                            candidates[countOfCandidates++] = employees[k];
                            break;
                        }
                    }
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
                    if (isDuplicate) { continue; }
                    else
                    {
                        if (countOfCandidates < candidates.Length)
                        {
                            candidates[countOfCandidates++] = employees[k];
                            nameIsFound = true;
                        }
                    }
                }
            }
            if (!nameIsFound)
            {
                for (int k = 0; k < employees.Length; ++k)
                {
                    if (employees[k].dad != null && employees[k].Name == employees[k].dad.Name)
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
                        if (isDuplicate) { continue; }
                        else
                        {
                            if (countOfCandidates < candidates.Length)
                            {
                                candidates[countOfCandidates++] = employees[k];
                            }
                        }
                    }

                }
            }
            int i = 0;
            while (true)
            {
                
                Employee closest = FindClosestByBirthdate(i++);
                if (closest == null) break;
                bool isDuplicate = false;
                foreach (var cand in candidates)
                {
                    if (cand != null && closest == cand)
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate && countOfCandidates < candidates.Length)
                {
                    
                    candidates[countOfCandidates++] = closest;
                    break;
                }
                else
                {
                    continue;
                }
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
