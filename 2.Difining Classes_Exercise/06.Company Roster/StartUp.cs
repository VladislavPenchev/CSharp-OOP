﻿namespace _06.Company_Roster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            List<Employee> listOfEmployees = new List<Employee>();
            Dictionary<string, double> dictionaryOfDepartments = new Dictionary<string, double>();
            
            
            int numberOfEmployees = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEmployees; i++)
            {
                List<string> informationForEmployee = Console
                                                    .ReadLine()
                                                    .Split()
                                                    .ToList();

                Employee newEmp = new Employee();

                if (informationForEmployee.Count == 4)
                {
                    newEmp.Name = informationForEmployee[0];
                    newEmp.Salary = double.Parse(informationForEmployee[1]);
                    newEmp.Position = informationForEmployee[2];
                    newEmp.Department = informationForEmployee[3];
                }
                else if (informationForEmployee.Count == 5)
                {
                    newEmp.Name = informationForEmployee[0];
                    newEmp.Salary = double.Parse(informationForEmployee[1]);
                    newEmp.Position = informationForEmployee[2];
                    newEmp.Department = informationForEmployee[3];
                    if (informationForEmployee[4].Contains("@"))
                    {
                        newEmp.Email = informationForEmployee[4];
                    }
                    else
                    {
                        newEmp.Age = int.Parse(informationForEmployee[4]);
                    }
                }
                else
                {                    
                    newEmp.Name = informationForEmployee[0];
                    newEmp.Salary = double.Parse(informationForEmployee[1]);
                    newEmp.Position = informationForEmployee[2];
                    newEmp.Department = informationForEmployee[3];
                    newEmp.Email = informationForEmployee[4];
                    newEmp.Age = int.Parse(informationForEmployee[5]);

                }

                listOfEmployees.Add(newEmp);

            }


            for (var i = 0; i < listOfEmployees.Count; i++)
            {
                double highestAverageSalary = 0;

                if (dictionaryOfDepartments.Count != 0 && dictionaryOfDepartments.ContainsKey(listOfEmployees[i].Department))
                {
                    highestAverageSalary += listOfEmployees[i].Salary;

                    dictionaryOfDepartments[listOfEmployees[i].Department] += highestAverageSalary;

                }
                else
                {
                    //crate department in dictionary
                    dictionaryOfDepartments.Add(listOfEmployees[i].Department, 0);

                    highestAverageSalary = listOfEmployees[i].Salary;

                    dictionaryOfDepartments[listOfEmployees[i].Department] += highestAverageSalary;
                }
            }


            var ordedDic = dictionaryOfDepartments.OrderByDescending(x => x.Value);


            Print(dictionaryOfDepartments, listOfEmployees);
        }

        public static void Print(Dictionary<string, double> dicOfDep, List<Employee> listOfEmp)
        {
            Console.WriteLine($"Highest Average Salary: {dicOfDep.First().Key}");
 
            foreach (var emp in listOfEmp)
            {
                if (emp.Department == dicOfDep.First().Key)
                {
                    //Console.WriteLine($@"{emp.Name} {emp.Salary} {emp.Email == null ? emp.Email : "dasda"  } {emp.Age}");
                    
                    Console.WriteLine("{0} {1} {2} {3}",emp.Name,emp.Salary, emp.Email != null ? emp.Email : "n/a", emp.Age != 0 ? emp.Age : -1);
                }

            }

        }
    }    
}
