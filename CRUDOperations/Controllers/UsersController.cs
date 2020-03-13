using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDOperations.Models;

namespace CRUDOperations.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index(string searchString)
        {
            if (searchString == null) {
                searchString = "";
            }
            using (var user = new UsersEntities())
            {
                var users = user.People.ToList().Where(x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString)).Select(x => new UsersViewModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Birthdate = x.Birthdate,
                    Birthplace = x.Birthplace,
                    MartialStatus = x.MartialStatus,
                    Gender = x.Gender,
                    Employed = x.Employed,
                    Phone = x.Phone,
                    UserId = x.UserId
                });
                return View(users);
            }
        }

        [HttpGet]
        public ActionResult Search(string searchString)
        {
            using (var user = new UsersEntities())
            {
                var users = user.People.ToList().Where(x => x.FirstName.Contains(searchString)).Where(x => x.FirstName.Contains(searchString)).Select(x => new UsersViewModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Birthdate = x.Birthdate,
                    Birthplace = x.Birthplace,
                    MartialStatus = x.MartialStatus,
                    Gender = x.Gender,
                    Employed = x.Employed,
                    Phone = x.Phone,
                    UserId = x.UserId
                });
                return View(users);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UsersViewModel objuser)
        {
            var User = new Person {Birthdate=objuser.Birthdate, MartialStatus=objuser.MartialStatus, Phone=objuser.Phone, Birthplace=objuser.Birthplace,Employed=objuser.Employed, Gender=objuser.Gender ,FirstName = objuser.FirstName, LastName = objuser.LastName };
            using (var user = new UsersEntities())
            {
                user.People.Add(User);
                user.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Int64? id)
        {
            var userentities = new UsersEntities();
            var user = userentities.People.Find(id);
            UsersViewModel objuser = new UsersViewModel();
            objuser.Birthdate = user.Birthdate;
            objuser.MartialStatus = user.MartialStatus;
            objuser.Phone = user.Phone;
            objuser.Birthplace = user.Birthplace;
            objuser.Employed = user.Employed;
            objuser.Gender = user.Gender;
            objuser.FirstName = user.FirstName;
            objuser.LastName = user.LastName;
            objuser.UserId = user.UserId;
            return View(objuser);
        }

        [HttpPost]
        public ActionResult Edit(UsersViewModel user)
        {
            using (var users = new UsersEntities())
            {
                var objuser = users.People.Find(user.UserId);
                objuser.Birthdate = user.Birthdate;
                objuser.MartialStatus = user.MartialStatus;
                objuser.Phone = user.Phone;
                objuser.Birthplace = user.Birthplace;
                objuser.Employed = user.Employed;
                objuser.Gender = user.Gender;
                objuser.FirstName = user.FirstName;
                objuser.LastName = user.LastName;
                users.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(Int64? id)
        {
            UsersViewModel objuser = new UsersViewModel();
            using (var user = new UsersEntities())
            {
                var oneuser = user.People.Find(id);
                objuser.Birthdate = oneuser.Birthdate;
                objuser.MartialStatus = oneuser.MartialStatus;
                objuser.Phone = oneuser.Phone;
                objuser.Birthplace = oneuser.Birthplace;
                objuser.Employed = oneuser.Employed;
                objuser.Gender = oneuser.Gender;
                objuser.FirstName = oneuser.FirstName;
                objuser.LastName = oneuser.LastName;
            }
            return View(objuser);
        }

        public ActionResult Delete(Int64? id)
        {
            UsersViewModel objuser = new UsersViewModel();
            using (var user = new UsersEntities())
            {
                var oneuser = user.People.Find(id);
                objuser.Birthdate = oneuser.Birthdate;
                objuser.MartialStatus = oneuser.MartialStatus;
                objuser.Phone = oneuser.Phone;
                objuser.Birthplace = oneuser.Birthplace;
                objuser.Employed = oneuser.Employed;
                objuser.Gender = oneuser.Gender;
                objuser.FirstName = oneuser.FirstName;
                objuser.LastName = oneuser.LastName;
                objuser.UserId = oneuser.UserId;
            }
            return View(objuser);
        }

        [HttpPost]
        public ActionResult Delete(UsersViewModel objuser)
        {
            using (var user = new UsersEntities())
            {
                var oneuser = user.People.Find(objuser.UserId);
                user.People.Attach(oneuser);
                user.Entry(oneuser).State = System.Data.EntityState.Deleted;
                user.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
