using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeDBEntities dbContext = new EmployeeDBEntities();

            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (var item in dbContext.tblDepartments.ToList())
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Name,
                };

                selectList.Add(selectListItem);
            }

            ViewBag.Departments = selectList;

            //ViewBag.Departments = new SelectList(dbContext.tblDepartments.ToList(), "Id", "Name", "2");

            return View();
        }


        public ActionResult Index1()
        {
            Company company = new Company("SriniTech");

            return View(company);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}