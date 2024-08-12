using Microsoft.AspNetCore.Mvc;
using MVC_Day_3.Models;

namespace MVC_Day_3.Controllers
{
    public class DrugController : Controller
    {

        public static List<Drug> Drugs = new List<Drug>()
        {
            new Drug { ID = 1, Name = "Comtrix" , Price = 45.50m , ImagePath ="~/images/img1.jpg"  },
            new Drug { ID = 2, Name = "Panadol" , Price = 95.70m ,ImagePath = "~/images/img2.jpeg" }
        };

        public IActionResult Index()
        {
            return View(Drugs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Drug drug)
        {

            if (ModelState.IsValid)
            {
                if (Drugs.Any(s => s.ID == drug.ID))
                {
                    ModelState.AddModelError("ID", "A drug with this ID already exists.");
                    return View(drug);
                }
                Drugs.Add(drug);
                return RedirectToAction("Index");
            }

            return View(drug);
        }





        [HttpGet]
        public IActionResult Edit(int id)
        {
            var drug = Drugs.FirstOrDefault(s => s.ID == id);

            return View(drug);
        }

        [HttpPost]
        public IActionResult Edit(Drug drug)
        {
            if (ModelState.IsValid)
            {
                var existingDrug = Drugs.FirstOrDefault(s => s.ID == drug.ID);

                existingDrug.Name = drug.Name;
                existingDrug.Price = drug.Price;
                existingDrug.ImagePath = drug.ImagePath;

                return RedirectToAction("Index");
            }

            return View(drug);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var drug = Drugs.FirstOrDefault(s => s.ID == id);

            return View(drug);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var drug = Drugs.FirstOrDefault(s => s.ID == id);

            Drugs.Remove(drug);


            return RedirectToAction("Index");
        }



    }
}
