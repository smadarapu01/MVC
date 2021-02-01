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
        public ActionResult Index()
        {
            List<Models.Employee> emps = new List<Models.Employee>();

            EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();

            List<DataAccess.Employee> employees = employeeDBEntities.Employees.ToList();

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
            Models.Employee emp = GetEmployeeById(Id);

            return View(emp);
        }

        private static Models.Employee GetEmployeeById(int Id)
        {
            EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();

            var employee = employeeDBEntities.Employees.FirstOrDefault(x => x.ID == Id);

            Models.Employee emp = TransformEmpToModel(employee);
            return emp;
        }

        private static Models.Employee TransformEmpToModel(DataAccess.Employee employee)
        {
            Models.Employee emp = new Models.Employee();

            emp.Id = employee.ID;
            emp.FirstName = employee.FirstName;
            emp.Gender = employee.Gender;
            emp.Salary = int.Parse(employee.Salary.ToString());
            emp.DeptId = int.Parse(employee.DeptId.ToString());
            return emp;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        // POST: Employee/Create
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Add()
        {
            try
            {
                DataAccess.Employee employee = new DataAccess.Employee();

                TryUpdateModel(employee);

                EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();
                DataAccess.Employee emp = new DataAccess.Employee();


                //emp.ID = 1003;
                //emp.FirstName = collection["FirstName"];
                //emp.Gender = collection["Gender"];
                //emp.Salary = Convert.ToInt32(collection["Salary"]);
                //emp.DeptId = Convert.ToInt32(collection["DeptId"]);

               

                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    employeeDBEntities.Employees.Add(emp);
                    employeeDBEntities.SaveChanges();
                }

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
            Models.Employee emp = GetEmployeeById(id);

            return View(emp);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();

                DataAccess.Employee dEmp = new DataAccess.Employee();

                TryUpdateModel(employee);

             
                if (ModelState.IsValid)
                {
                    employeeDBEntities.Employees.Attach(employee);
                    employeeDBEntities.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                    employeeDBEntities.SaveChanges();
                }

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
