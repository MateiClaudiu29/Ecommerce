using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SpecialTagsController : Controller
    {
        private ApplicationDbContext _db;

        public SpecialTagsController(ApplicationDbContext db)
        {
            _db = db;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_db.SpecialTags.ToList());
        }

        //Create Get Action Method

        public ActionResult Create()
        {
            return View();
        }

        //Create Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                _db.SpecialTags.Add(specialTags);
                await _db.SaveChangesAsync();
                TempData["save"] = "Special Tag saved";
                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }

        //Edit Get Action Method

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialTags = _db.SpecialTags.Find(id);

            if (specialTags == null)
            {
                return NotFound();
            }
            return View(specialTags);
        }

        //Edit Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                _db.Update(specialTags);
                await _db.SaveChangesAsync();
                TempData["save"] = "Special Tag updated";
                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }


        //Details Get Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialTags = _db.SpecialTags.Find(id);

            if (specialTags == null)
            {
                return NotFound();
            }
            return View(specialTags);
        }

        //Details Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(SpecialTags specialTags)
        {
            return RedirectToAction(nameof(Index));

        }

        //Delete Get Action Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialTags = _db.SpecialTags.Find(id);

            if (specialTags == null)
            {
                return NotFound();
            }
            return View(specialTags);
        }

        //Delete Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, SpecialTags specialTags)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != specialTags.Id)
            {
                return NotFound();
            }
            var specialTag = _db.SpecialTags.Find(id);

            if (specialTag == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(specialTag);
                await _db.SaveChangesAsync();
                TempData["del"] = "Special Tag deleted";
                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }
    }
}
