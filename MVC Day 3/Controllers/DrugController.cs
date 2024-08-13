using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Day_3.Data;
using MVC_Day_3.Models;

namespace MVC_Day_3.Controllers
{
    public class DrugController : Controller
    {



        ApplicationDBContext _context;

        public DrugController(ApplicationDBContext context)
        {
            _context = context;
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
        public IActionResult Create(Drug drug)
        {
            if (ModelState.IsValid)
            {
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
        public IActionResult Edit(Drug drug)
        {
            if (ModelState.IsValid)
            {
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

            _context.Drugs.Remove(drug);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }



    }
}
