using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        public static int Counter = 0;

        // GET: Test
        public ActionResult Index()
        {
            string result = string.Empty;

            BackgroundJob.Enqueue(() => StringJoin(result, "Fire-and-forget" + Counter));
            Response.Write("<br />");
            
            BackgroundJob.Schedule(() => StringJoin(result, "Delayed" + Counter), TimeSpan.FromDays(1));
            Response.Write("<br />");
     
            RecurringJob.AddOrUpdate(() => StringJoin(result, "Daily Job" + Counter), Cron.Daily);
            Response.Write("<br />");

            return Content(result);
        }

        public void StringJoin(string str1, string str2)
        {
            str1 = str1 + str2;
            Counter++;
        }

        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Test/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
