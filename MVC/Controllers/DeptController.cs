using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class DeptController : Controller
    {
        // GET: Dept
        public ActionResult Index()
        {
            List<Models.Department> depts = new List<Models.Department>();

            EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();

            List<DataAccess.tblDepartment> departments = employeeDBEntities.tblDepartments.ToList();

            foreach (DataAccess.tblDepartment item in departments)
            {
                Models.Department dept = TransformDeptToModel(item);

                depts.Add(dept);
            }

            return View(depts);
        }

        private static Models.Department TransformDeptToModel(DataAccess.tblDepartment department)
        {
            Models.Department emp = new Models.Department();

            emp.DeptId = department.Id;
            emp.DeptName = department.Name;
          
            return emp;
        }

        // GET: Dept/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dept/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dept/Create
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

        // GET: Dept/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dept/Edit/5
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

        // GET: Dept/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dept/Delete/5
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
