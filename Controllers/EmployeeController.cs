using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP1_mvc.Models;
using TP1_mvc.Models.Repositories;

namespace TP1_mvc.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IRepository<Employee> employeeRepository;
        // GET: Employee
        public EmployeeController(IRepository<Employee> empRepository) {
            employeeRepository = empRepository; 
        }
        public ActionResult Index()
        {
            var employees = employeeRepository.GetAll();
            ViewData["EmployeesCount"] = employees.Count();
            ViewData["SalaryAverage"] = employeeRepository.SalaryAverage();
            ViewData["MaxSalary"] = employeeRepository.MaxSalary();
            ViewData["HrEmployeesCount"] = employeeRepository.HrEmployeesCount();
            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var employee = employeeRepository.FindByID(id);
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee e )
        {
            try
            {
                // TODO: Add insert logic here
                employeeRepository.Add(e);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = employeeRepository.FindByID(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee newEmployee)
        {
            try
            {
                // TODO: Add update logic here
                employeeRepository.Update(id, newEmployee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = employeeRepository.FindByID(id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Employee e)
        {
            try
            {
                // TODO: Add delete logic here
                employeeRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string term)
        {
            var result = employeeRepository.Search(term);
            return View("index", result);
            }
        }
}