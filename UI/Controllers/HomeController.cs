﻿using Entity;
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

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost] //veriinin geldiği yer
        public ActionResult CreateEmployee(Employee model)
        {
            model.DateOfBirth = Convert.ToDateTime(model.DateOfBirth.ToShortDateString());
            model.StartDate = DateTime.Now;
            MvcDBHelper.Repository.Insert(QueryWarehouse.Employee.Insert, model);
            return View();
        }

        public ActionResult DeleteEmployee(int Id)
        {
            Employee model = new Employee() { Id = Id };

            MvcDBHelper.Repository.Delete<Employee>(QueryWarehouse.Employee.Delete, model);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult DetailsEmployee(int Id)
        {
            var model = MvcDBHelper.Repository.GetById<Employee>(QueryWarehouse.Employee.GetById, new { Id=Id}).FirstOrDefault();
            return View(model);
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