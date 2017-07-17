using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAppFirst.Models;

namespace MvcAppFirst.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        public Employee emp = new Employee();
        public List<Employee> Search()
        {
           
            return new List<Employee>{
                new Employee{
                    Name="Wayne Rooney",
                    Department="Forward",
                    id=10
                },
                new Employee{
                    Name="Muhsin Wazza",
                    Department="Midfield",
                    id=11
                }
            };
            
        }

        public ActionResult GetEmp(string save="0")
        {
            return View(emp.GetEmployee());
        }

        public ActionResult Details(int id)
        {
            return View(emp.GetEmployee(id));
            
        }

        
        public ActionResult NewEmployee()
        {

            return View(emp.GetDept());
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee Input)
        {
            emp.Name = Input.Name;
            emp.deptid = Input.deptid;
            emp.Job = Input.Job;
            string ret = emp.InsertEmp();
            return  View("GetEmp",emp.GetEmployee());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.department = emp.GetDept();
            return View(emp.GetEmployee(id));
        }

        [HttpPost]
        public ActionResult Edit(Employee input)
        {
            emp.id = input.id;
            emp.Name = input.Name;
            emp.Job = input.Job;
            emp.deptid = input.deptid;
            ViewBag.UpdateState = emp.Update();
            ViewBag.department = emp.GetDept();
            return View(emp.GetEmployee(input.id));
        }

        public ActionResult Delete(int id)
        {
            emp.id = id;
          
            ViewBag.DeleteStatus = emp.delete();
            return View("GetEmp", emp.GetEmployee());
        }
    }
}
