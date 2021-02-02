using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        public ActionResult CityIndex()
        {
            EmployeeDBEntities dbContext = new EmployeeDBEntities();
            List<SelectListItem> listSelectedItem = new List<SelectListItem>();

            foreach (var item in dbContext.Cities)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.ID.ToString(),
                    Selected = item.IsSelected
                };
                listSelectedItem.Add(selectListItem);
            }

            Models.City city = new Models.City();
            city.Cities = listSelectedItem;
            return View(city);
        }

        [HttpPost]
        public string CityIndex(IEnumerable<string> SelectedCities)
        {
           if(SelectedCities == null)
            {
                return "You did not selected any city;";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected - " + string.Join(",", SelectedCities));
                return sb.ToString();
            }
        }



        //public ActionResult Index1()
        //{
        //    Company company = new Company("SriniTech");
        //    return View(company);
        //}

        //[HttpPost]
        //public ActionResult Index1(Company company)
        //{
        //    return View();
        //}

        //public ActionResult City()
        //{
        //    EmployeeDBEntities dBEntities = new EmployeeDBEntities();

        //    return View(dBEntities.Cities);
        //}


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