using MVCApplication.Models;
using MVCApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;
using System.Web.Services.Description;
using MVCApplication.Filters;
using Antlr.Runtime.Misc;
using MVCApplication.ContextClass;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;

namespace MVCApplication.Controllers
{
    //using the filters
    [MyErrorFilter]
    [MyActionFilter]
    [MyResultFilter]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        //using Route attribute we need to call a method in RouteConfig.cs
        // [Route("Employee/InsertEmployee")]
        // [Route("InsertNewEmployee")]
        // [Route("AddNewEmployee")]


        //Displaying the rest fields after selecting values from drop down
        public ActionResult GetDropdownValue(Employee e1)
        {
            var res = new EmployeeContext();            
            e1.EmpIdList = res.emps.Select(emp =>
            new SelectListItem { Value = emp.Emp_id.ToString(), Text = emp.Emp_id.ToString() }).ToList();
                
            return View(e1);
        }
        [HttpPost]
        [ActionName("GetDropdownValue")]
        public ActionResult GetDropdownValue2(string bt,Employee Emp)
        {
            var res = new EmployeeContext();
            //Get data for the corresponding employee id selected from drop down
            if (bt == "Get Data")
            {
                string Emp_id = Emp.Emp_id.ToString();
                
                if (Emp_id == "")
                {

                    Employee e1 = new Employee();
                    e1.EmpIdList = res.emps.Select(emp =>
                    new SelectListItem { Value = emp.Emp_id.ToString(), Text = emp.Emp_id.ToString() }).ToList();
                    return View(e1);
                }
                ViewBag.Post = "yes";

                Employee emp1 = res.emps.Find(Convert.ToInt32(Emp_id));
                emp1.EmpIdList = res.emps.Select(emp =>
                new SelectListItem { Value = emp.Emp_id.ToString(), Text = emp.Emp_id.ToString() }).ToList();
                ModelState.Clear();
                return View("GetDropdownValue", emp1);
            }
            else
            {
                //Updating the dropdown values in database
                Employee emp1 = res.emps.Find(Convert.ToInt32(Emp.Emp_id));
                emp1.Emp_mailid = Emp.Emp_mailid;
                emp1.Emp_name = Emp.Emp_name;
                emp1.Emp_salary = Emp.Emp_salary;
                res.SaveChanges();
                return RedirectToAction("GetEmployeeDetailsTable");
            }
        }


        //Displaying the table data in grid- get method
        public ActionResult GetEmployeeDetailsTable()
        {
            EmployeeContext ec = new EmployeeContext();     
            var data = ec.emps.ToList();
            return View(data);
        }

        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            //Creating custom exception-Divide by zero exception
            //int i = 10, j=0;
            //i = i / j;

            //applying condition that salary should be a multiple of 10
            if (emp.Emp_salary%10!=0)
                {
                    ModelState.AddModelError("", "The Salary must be a multiple of 10.");
                }
            //Checking if there are validations and are true
            if (ModelState.IsValid)
            {
                //Adding employees to the database
                EmployeeContext ctx = new EmployeeContext();
                ctx.emps.Add(emp);
                ctx.SaveChanges();
                //Adding employees end here

                //Displaying data in another view
                ViewBag.Empvb = emp.Emp_id;
                TempData["Emp"] = emp.Emp_name;
                ViewData["Empvd"] = emp.Emp_mailid;
                TempData["Empt"] = emp.Emp_salary;
                return View("ShowEmployeeDetails");
            }
            else
                return View();
        }

        public ActionResult DeleteEmployee()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult DeleteEmployee(Employee Emp)
        {
            //Deleting Employees from database
            EmployeeContext db = new EmployeeContext();
            Employee emp = db.emps.Find(Emp.Emp_id);
            db.emps.Remove(emp);
            db.SaveChanges();
            return View();
        }

        public ActionResult UpdateEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEmployee([Bind(Include ="Emp_id,Emp_name,Emp_mailid,Emp_salary")]Employee emp)
        {
            //Updating Employee data from database
            EmployeeContext etc = new EmployeeContext();
            Employee emp1 = etc.emps.Find(emp.Emp_id);
            emp1.Emp_mailid = emp.Emp_mailid;
            emp1.Emp_name = emp.Emp_name;
            emp1.Emp_salary = emp.Emp_salary;
            etc.SaveChanges();
            return View();
        }

        //Displaying Partial View through action method
        public PartialViewResult MyView()
        {
            return PartialView("~/Views/MyPartialViewTest.cshtml");
        }

        //Returing values of a textbox in the same view
        public ActionResult DisplayResultInSameView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DisplayResultInSameView(string Name,int num1,int num2)
        {
            int result = num1 + num2;
            ViewBag.output = result;
            ViewBag.name = Name;
            return View();
        }

        public ActionResult ViewResultFromModel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewResultFromModel(MyViewModel mvm)
        {
            //Displaying the result from model properties-ViewModel
            int i, j;
            i = mvm.num1;
            j = mvm.num2;
            mvm.Result = i + j;
            return View(mvm);
        }

        public ActionResult CustomErrors()
        {
            return View("CustomErrors");
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            string msg = ex.Message;
            filterContext.ExceptionHandled = true;

            filterContext.Result = new ViewResult
            {

                ViewName = "~/Views/Shared/CustomErrors.cshtml",
                ViewBag = { Message=msg }
            };
        }
    }
}