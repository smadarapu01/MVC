using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Company
    {
		private string _companyName;
	
		public Company(string companyName)
		{
			_companyName = companyName;
		}

		public List<Department> Departments 
		{
			get
			{
				List<Department> departments = new List<Department>();
				EmployeeDBEntities db = new EmployeeDBEntities();
				foreach (var item in db.tblDepartments.ToList())
				{
					departments.Add(TransformDeptToModel(item));
				}
				return departments;
			}
		}



		public string companyName
		{
			get { return _companyName; }
			set { _companyName = value; }
		}

		private static Models.Department TransformDeptToModel(DataAccess.tblDepartment dDept)
		{
			Models.Department dept = new Models.Department();

			dept.DeptId = dDept.Id;
			dept.DeptName = dDept.Name;

			return dept;
		}

	}
}