using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RepositoryPattern.Core.Domain;
using RepositoryPattern.Persistence;

namespace RepositoryPattern.Controllers
{
    public class CoursesController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new SchoolModel());

        // GET: Courses
        public ActionResult Index()
        {
            return View(_unitOfWork.Courses.GetAll());
        }

        // GET: Courses/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCourse tblCourse = _unitOfWork.Courses.Get(id);
            if (tblCourse == null)
            {
                return HttpNotFound();
            }
            return View(tblCourse);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblCourse tblCourse)
        {
            if (ModelState.IsValid)
            {
                tblCourse.id = Guid.NewGuid();
                _unitOfWork.Courses.Add(tblCourse);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(tblCourse);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCourse tblCourse = _unitOfWork.Courses.Get(id);
            if (tblCourse == null)
            {
                return HttpNotFound();
            }
            return View(tblCourse);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblCourse tblCourse)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Courses.Update(tblCourse);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(tblCourse);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCourse tblCourse = _unitOfWork.Courses.Get(id);
            if (tblCourse == null)
            {
                return HttpNotFound();
            }
            return View(tblCourse);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tblCourse tblCourse = _unitOfWork.Courses.Get(id);
            _unitOfWork.Courses.Remove(tblCourse);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
