using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(int Id)
        {
            List<Models.Employee> emps = new List<Models.Employee>();

            EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();

            List<DataAccess.Employee> employees = employeeDBEntities.Employees.Where(x => x.DeptId == Id).ToList();

            foreach (DataAccess.Employee item in employees)
            {
                Models.Employee emp = TransformEmpToModel(item);

                emps.Add(emp);
            }

            return View(emps);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int Id)
        {
            EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();

            var employee = employeeDBEntities.Employees.FirstOrDefault(x => x.ID == Id);

            Models.Employee emp = TransformEmpToModel(employee);

            return View(emp);
        }

        private static Models.Employee TransformEmpToModel(DataAccess.Employee employee)
        {
            Models.Employee emp = new Models.Employee();

            emp.Id = employee.ID;
            emp.FirstName = employee.FirstName;
            emp.Gender = employee.Gender;
            emp.Salary = int.Parse(employee.Salary.ToString());
            return emp;
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
