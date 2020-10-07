using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TP1_mvc.Models.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        List<Employee> Iemployees; public EmployeeRepository()
        {
            Iemployees = new List<Employee>() {
            new Employee {Id = 1, Name = "Sofien ben ali", Departement = "comptabilité", Salary = 1000 },
            new Employee { Id = 2, Name = "Mourad triki", Departement = "RH", Salary = 1500 },
            new Employee { Id = 3, Name = "ali ben mohamed", Departement = "informatique", Salary = 1700 },
            new Employee { Id = 4, Name = "omar haalbi", Departement = "informatique", Salary = 1300 },
            new Employee { Id = 5, Name = "salah amine", Departement = "informatique", Salary = 1500 },
            new Employee { Id = 6, Name = "fathi ammar", Departement = "informatique", Salary = 1000 },
            };
        }
            public void Add(Employee e)
            {
                Iemployees.Add(e);
            }

            public void Delete(int id)
            {
                var emp = FindByID(id);
                Iemployees.Remove(emp);
            }

            public Employee FindByID(int id)
            {
            var emp = Iemployees.SingleOrDefault(a => a.Id==id);
                return emp;
            }

            public IList<Employee> GetAll()
            {
                return Iemployees;
            }

        public int HrEmployeesCount()
        {
            return Iemployees.Where(x => x.Departement == "RH").Count();
        }

        public double MaxSalary()
        {
            return Iemployees.Max(x=>x.Salary);
        }

        public double SalaryAverage()
        {
            return Iemployees.Average(x => x.Salary);
        }

        public List<Employee> Search(string term)
            {
                return Iemployees.Where(a => a.Name.Contains(term)).ToList();
            }

            public void Update(int id, Employee newemployee)
            {
                var emp = FindByID(id);
                emp.Name = newemployee.Name;
                emp.Departement = newemployee.Departement;
                emp.Salary = newemployee.Salary;
            }
        }
    }


