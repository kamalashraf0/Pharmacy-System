using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Day_3.Data;

namespace MVC_Day_3.Controllers
{
    public class DrugController : Controller
    {

        ApplicationDBContext _context;
        ImageHelper _imageHelper;

        public DrugController(ApplicationDBContext context, ImageHelper imageHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
        }
        public IActionResult Index()
        {
            var Drugs = _context.Drugs.ToList();
            return View(Drugs);
        }

        public IActionResult DrugDetails(int id)
        {
            var drug = _context.Drugs.Find(id);
            var company = _context.Companies.Find(drug.CompanyId);
            ViewBag.compName = company.Name;
            return PartialView(drug);
        }





        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Comps = new SelectList(_context.Companies, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Drug drug, IFormFile ImagePath)
        {
            if (drug.CompanyId == 0)
            {
                ModelState.AddModelError("CompanyId", "Please select a valid company.");
            }

            if (ModelState.IsValid)
            {
                if (ImagePath != null)
                {
                    drug.ImagePath = _imageHelper.SaveImage(ImagePath);
                }


                _context.Drugs.Add(drug);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Comps = new SelectList(_context.Companies, "Id", "Name");
            return View(drug);
        }





        [HttpGet]
        public IActionResult Edit(int id)
        {

            var drug = _context.Drugs.Find(id);
            if (drug == null)
            {
                return NotFound();
            }
            ViewBag.Comps = new SelectList(_context.Companies, "Id", "Name");
            return View(drug);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Drug drug, IFormFile? ImagePath)
        {
            if (ModelState.IsValid)
            {
                var existingDrug = _context.Drugs.AsNoTracking().FirstOrDefault(d => d.Id == drug.Id);
                if (ImagePath != null)
                {
                    drug.ImagePath = _imageHelper.UpdateImage(ImagePath, existingDrug.ImagePath);
                }
                else
                {
                    drug.ImagePath = existingDrug.ImagePath;
                }
                _context.Drugs.Update(drug);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Comps = new SelectList(_context.Companies, "Id", "Name");

            return View(drug);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null && id == 0)
            {
                NotFound();
            }

            var drug = _context.Drugs.Find(id);

            return View(drug);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var drug = _context.Drugs.Find(id);

            if (drug == null)
            {
                NotFound();
            }

            _imageHelper.DeleteImage(drug.ImagePath);
            _context.Drugs.Remove(drug);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }


        public IActionResult UniqueName(string name, int id)
        {
            var drug = _context.Drugs.FirstOrDefault(x => x.Name == name && x.Id != id);

            if (drug == null)
            {
                return Json(true);
            }
            return Json(false);
        }

        public IActionResult PastManufacture(string manufactureDate)
        {
            if (DateTime.TryParse(manufactureDate, out DateTime date) && date < DateTime.Now)
            {
                return Json(true);
            }
            return Json(false);
        }

        public IActionResult FutureExpiration(string expirationDate)
        {
            if (DateTime.TryParse(expirationDate, out DateTime date) && date >= DateTime.Now)
            {
                return Json(true);
            }
            return Json(false);
        }


    }
}
