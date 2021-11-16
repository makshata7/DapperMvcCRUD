using DapperMvcCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace DapperMvcCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<EmployeeModel>("EmployeeViewAll"));
        } 
      [HttpGet]
        
        public ActionResult AddOrEdit( int id = 0)
        {
          if(id == 0)
            return View();
          else
          {
              DynamicParameters param = new DynamicParameters();
              param.Add("@EmployeeID", id);
              return View(DapperORM.ReturnList<EmployeeModel>("EmployeeViewByID", param).FirstOrDefault<EmployeeModel>());

          }
        }
        [HttpPost]
        public ActionResult AddOrEdit(EmployeeModel employeeModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeID", employeeModel.EmployeeID);
            param.Add("@Name", employeeModel.Name);
            param.Add("@City", employeeModel.City);
            param.Add("@Age", employeeModel.Age);
            param.Add("@Salary", employeeModel.Salary);
            DapperORM.ExecuteWithoutReturn("EmployeeAddOrEdit", param);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeID",id);
            DapperORM.ExecuteWithoutReturn("EmployeeDeleteByID", param);
            return RedirectToAction("Index");
        }
    }
}