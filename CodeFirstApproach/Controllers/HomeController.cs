using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace CodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var emp = db.Employees.ToList();

            return View(emp);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                db.Employees.Add(e);
                var a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage "] = "Data Inserted Successfully..!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["DefaultMessage"] = "Something went wrong..!";
                }
            }
            return View();

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editEmpDetail = db.Employees.Where(x => x.EmpId == id).FirstOrDefault();

            return View(editEmpDetail);
        }

        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(e).State = EntityState.Modified;
                var updaterecord = db.SaveChanges();
                if (updaterecord > 0)
                {
                    TempData["UpdateMessage"] = "Updted Successfully ..!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["DefaultMessage"] = "Something went wrong..!";
                }
            }
            return View();
        }

        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    var deleteRecordById = db.Employees.Where(x => x.EmpId == id).FirstOrDefault();
        //    return View(deleteRecordById);
        //}
        
        //public ActionResult Delete(Employee e)
        //{
        //    //if (id > 0)
        //    //{
        //    //    var deleteRecordById = db.Employees.Where(x => x.EmpId == id).FirstOrDefault();
        //    //    if (deleteRecordById != null)
        //    //    {
        //    //        db.Enti
        //    //    }
        //    //}

        //    db.Entry(e).State = EntityState.Deleted;
        //    int a = db.SaveChanges();
        //    if (a > 0)
        //    {
        //        TempData["DeleteMessage"] = "Delete Successfully ..!";

        //    }
        //    else
        //    {
        //        TempData["DefaultMessage"] = "Something went wrong..!";
        //    }

        //    return RedirectToAction("Index");
        //}

        public ActionResult Delete(int id)
        {
            if(id > 0)
            {
                var EmployeeId = db.Employees.Where(x => x.EmpId == id).FirstOrDefault();
                if(EmployeeId != null)
                {
                    db.Entry(EmployeeId).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if(a > 0)
                    {
                        TempData["DeleteMessage"] = "Delete Successfully ..!";
                    }
                    else
                    {
                        TempData["DefaultMessage"] = "Something went wrong..!";
                    }
                }
            }
            return RedirectToAction("Index");
        }

    }
}