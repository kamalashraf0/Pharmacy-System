using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Day_3.Data;
using MVC_Day_3.Helpers;
using MVC_Day_3.Models;

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

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Comps = new SelectList(_context.Companies, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Drug drug, IFormFile ImagePath)
        {
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
        public IActionResult Edit(Drug drug, IFormFile ImagePath)
        {
            if (ModelState.IsValid)
            {
                var existingDrug = _context.Drugs.AsNoTracking().FirstOrDefault(d => d.Id == drug.Id);
                drug.ImagePath = _imageHelper.UpdateImage(ImagePath, existingDrug.ImagePath);
                _context.Drugs.Update(drug);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {

                foreach (var modelState in ModelState)
                {
                    foreach (var error in modelState.Value.Errors)
                    {
                        Console.WriteLine($"Key: {modelState.Key}, Error: {error.ErrorMessage}");
                    }
                }
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



    }
}
