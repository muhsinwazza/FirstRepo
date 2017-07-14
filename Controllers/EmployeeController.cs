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

        public ActionResult GetEmp()
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
        public ActionResult AddEmployee(string name,string job,string dept)
        {

            emp.InsertEmp();
            return PartialView();
        }
    }
}
