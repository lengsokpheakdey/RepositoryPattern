using System;
using System.Net;
using System.Web.Mvc;
using RepositoryPattern.Core.Domain;
using RepositoryPattern.Persistence;

namespace RepositoryPattern.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new SchoolModel());

        // GET: Authors
        public ActionResult Index()
        {
            return View(_unitOfWork.Authors.GetAll());
        }

        // GET: Authors/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAuthor tblAuthor = _unitOfWork.Authors.Get(id);
            if (tblAuthor == null)
            {
                return HttpNotFound();
            }
            return View(tblAuthor);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblAuthor tblAuthor)
        {
            if (ModelState.IsValid)
            {
                tblAuthor.id = Guid.NewGuid();
                _unitOfWork.Authors.Add(tblAuthor);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(tblAuthor);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAuthor tblAuthor = _unitOfWork.Authors.Get(id);
            if (tblAuthor == null)
            {
                return HttpNotFound();
            }
            return View(tblAuthor);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblAuthor tblAuthor)
        {
            if (ModelState.IsValid)
            {
               _unitOfWork.Authors.Update(tblAuthor);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(tblAuthor);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAuthor tblAuthor = _unitOfWork.Authors.Get(id);
            if (tblAuthor == null)
            {
                return HttpNotFound();
            }
            return View(tblAuthor);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tblAuthor tblAuthor = _unitOfWork.Authors.Get(id);
            _unitOfWork.Authors.Remove(tblAuthor);
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
