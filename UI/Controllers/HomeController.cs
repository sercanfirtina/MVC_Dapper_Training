using Entity;
using Entity.SqlQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            GetEmployees();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }



        #region Employee Partial

        public ActionResult _partialEmployeeList()
        {
            return View(GetEmployees());
        }


        #endregion



        #region EmployeeCrud
        public List<Employee> GetEmployees()
        {
            var employeeResult = MvcDBHelper.Repository.GetAll<Employee>(QueryWarehouse.Employee.GetAll).ToList();
            return employeeResult;
        } 
        #endregion
    }
}