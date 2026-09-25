using Microsoft.AspNetCore.Mvc;
using PVKLesson6.Models;

namespace PVKLesson6.Controllers
{
    public class PvkMemberController : Controller
    {
        private static readonly List<PvkMember> _pvkMembers = new List<PvkMember>()
        {
            new PvkMember { Id = "MB001", Username = "nguyenvana", Password = "Password123!", Email = "nva@gmail.com", Fullname = "Nguyễn Văn A" },
            new PvkMember { Id = "MB002", Username = "tranthib", Password = "Password123!", Email = "ttb@gmail.com", Fullname = "Trần Thị B" },
            new PvkMember { Id = "MB003", Username = "lehoangc", Password = "Password123!", Email = "lhc@gmail.com", Fullname = "Lê Hoàng C" },
            new PvkMember { Id = "MB004", Username = "phamvand", Password = "Password123!", Email = "pvd@gmail.com", Fullname = "Phạm Văn D" },
            new PvkMember { Id = "MB005", Username = "hoangthie", Password = "Password123!", Email = "hte@gmail.com", Fullname = "Hoàng Thị E" }
        };
        public IActionResult Index()
        {
            return View(_pvkMembers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PvkMember pvkMember)
        {
            pvkMember.Id = Guid.NewGuid().ToString();
            _pvkMembers.Add(pvkMember);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            var pvkMember = _pvkMembers.FirstOrDefault(x=>x.Id.Equals(id));
            return View(pvkMember);
        }

        [HttpPost]
        public IActionResult Edit(string id,PvkMember pvkMember)
        {
            for (int i =0; i< _pvkMembers.Count; i++)
            {
                if(_pvkMembers[i].Id == id)
                {
                    _pvkMembers[i].Id = pvkMember.Id;
                    _pvkMembers[i].Username = pvkMember.Username;
                    _pvkMembers[i].Password = pvkMember.Password;
                    _pvkMembers[i].Email = pvkMember.Email;
                    _pvkMembers[i].Fullname = pvkMember.Fullname;
                    break;
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            var pvkMember = _pvkMembers.FirstOrDefault(x=>x.Id.Equals(id));
            return View(pvkMember);
        }
    }
}
