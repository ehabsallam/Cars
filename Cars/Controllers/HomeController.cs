using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cars.Models;
using WebApplication2.Models;
using System.IO;
using Microsoft.AspNet.Identity;
using System.Net.Mail;


namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
       private ApplicationDbContext db= new ApplicationDbContext();
        public ActionResult Index()
        {

            return View(db.Categories.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            Session["JobId"] = id ;
            return View(car);
        }

        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(string Message )
        {
            var UserId = User.Identity.GetUserId();
            var carid = (int)Session["JobId"];

            var check = db.BuyCar.Where(a => a.UserId == UserId && a.CarId == carid).ToList();

            if(check.Count < 1) { 
            var car = new buyCar();
            car.UserId = UserId;
            car.CarId = carid;
            car.ApplyDate = DateTime.Now;
            car.message = Message;
            db.BuyCar.Add(car);
            db.SaveChanges();
                ViewBag.Result = "Apply sent succesfuly";
            }
            else
            {
                ViewBag.Result = " Alredy Applyed";
            }


            return View();
        }
        [Authorize]
        public ActionResult GetJobByUser()
        {
            var UserId = User.Identity.GetUserId();
            var car = db.BuyCar.Where(a => a.UserId == UserId);
            return View(car.ToList());
        }
        [Authorize]
        public ActionResult DetailsOfJob(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var car = db.BuyCar.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            
            return View(car);
        }



        public ActionResult GetJobsByPublisher()
        {
            var UserId = User.Identity.GetUserId();
            var cars = from app in db.BuyCar
                       join car in db.cars
                       on app.CarId equals car.Id
                       where car.User.Id == UserId
                       select app;

            var grouped = from j in cars
                          group j by j.car.CarTitle
                          into gr
                          select new CarsViewModel
                          {
                              CarTitle = gr.Key,
                              Items = gr
                          };
            return View(grouped.ToList());

        }






        public ActionResult Edit(int id)
        {
            var car = db.BuyCar.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }


            return View(car);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(buyCar car)
        {
            if (ModelState.IsValid)
            {
                car.ApplyDate = DateTime.Now;
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetJobByUser");
            }
            return View(car);

        }




        public ActionResult Delete(int id)
        {
            var car = db.BuyCar.Find(id);
            if (car == null)
            {
                return HttpNotFound();

            }
            return View(car);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(buyCar car)
        {

            // TODO: Add delete logic here
            var mycar = db.BuyCar.Find(car.Id);
            db.BuyCar.Remove(mycar);
            db.SaveChanges();

            return RedirectToAction("GetJobByUser");


        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
         

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel contact)
        {
            var mail = new MailMessage();
            //var loginInfo = new NetworkCredential("ehab.r.sallam@gmail.com", "ehab8121996");
            mail.From = new MailAddress(contact.Email);
            mail.To.Add(new MailAddress("ehab.ragab.a@gmail.com"));
            mail.Subject = contact.Subject;
            mail.Body = contact.Message;

            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("ehab.ragab.a@gmail.com", "passs");
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

           // smtpClient.Credentials = loginInfo;
            smtpClient.Send(mail);


            return RedirectToAction("Index");
        }



        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string SearchName)
        {
            var result = db.cars.Where(a => a.CarTitle.Contains(SearchName)
            || a.CarContent.Contains(SearchName)
            || a.category.CategoryName.Contains(SearchName)
            || a.category.CategoryDescription.Contains(SearchName)).ToList();
            return View(result);
        }

    }
}