using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVKLesson7.Models;

namespace PVKLesson7.Controllers
{
    public class PvkMemberController : Controller
    {
        private static List<PvkMember> _members = new List<PvkMember>();
        // GET: PvkMemberController
        public ActionResult Index()
        {
            return View(_members);
        }

        // GET: PvkMemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PvkMemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PvkMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PvkMember pvkMember)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(pvkMember);
                }
                pvkMember.Id = pvkMember.Id;
                _members.Add(pvkMember);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PvkMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PvkMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PvkMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PvkMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
