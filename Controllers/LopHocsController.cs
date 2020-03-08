using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_SEM3.Models;

namespace ASP_SEM3.Controllers
{
    public class LopHocsController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: LopHocs
        public ActionResult Index()
        {

            long TongTien = 0;
            long TongCD = 0;
            foreach (var i in db.LopHocs)
            {
                if (i.Hinh_Thuc_Nop_Phat == LopHoc.EnumHinhThucNopPhat.Chong_Day)
                {
                    TongCD = TongCD + i.NopPhat;
                }

                if (i.Hinh_Thuc_Nop_Phat == LopHoc.EnumHinhThucNopPhat.Nop_Tien)
                {
                    TongTien = TongTien + i.NopPhat;
                }
            }

            TempData["TongTien"] = TongTien;
            TempData["TongCD"] = TongCD;
            return View(db.LopHocs.ToList());
        }

        // GET: LopHocs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopHoc lopHoc = db.LopHocs.Find(id);
            if (lopHoc == null)
            {
                return HttpNotFound();
            }
            return View(lopHoc);
        }

        // GET: LopHocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LopHocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MSV,Hinh_Thuc_Nop_Phat,NopPhat,NgayNop")] LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                db.LopHocs.Add(lopHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lopHoc);
        }

        // GET: LopHocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopHoc lopHoc = db.LopHocs.Find(id);
            if (lopHoc == null)
            {
                return HttpNotFound();
            }
            return View(lopHoc);
        }

        // POST: LopHocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MSV,Hinh_Thuc_Nop_Phat,NopPhat,NgayNop")] LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lopHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lopHoc);
        }

        // GET: LopHocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopHoc lopHoc = db.LopHocs.Find(id);
            if (lopHoc == null)
            {
                return HttpNotFound();
            }
            return View(lopHoc);
        }

        // POST: LopHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LopHoc lopHoc = db.LopHocs.Find(id);
            db.LopHocs.Remove(lopHoc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
