using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Day_3.Repository.IRepository;

namespace MVC_Day_3.Controllers
{
    public class DrugController : Controller
    {

        private readonly IDrugRepository _drugRepository;
        private readonly ICompaniesRepository _companiesRepository;
        private readonly ImageHelper _imageHelper;

        public DrugController(IDrugRepository drugRepository, ICompaniesRepository companiesRepository, ImageHelper imageHelper)
        {
            _drugRepository = drugRepository;
            _imageHelper = imageHelper;
            _companiesRepository = companiesRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var Drugs = _drugRepository.GetAll(); ;
            return View(Drugs);
        }

        public IActionResult DrugDetails(int id)
        {
            var drug = _drugRepository.GetbyId(id);
            var company = _companiesRepository.GetbyId(drug.CompanyId);
            ViewBag.compName = company.Name;
            return PartialView(drug);
        }





        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Comps = new SelectList(_companiesRepository.GetAll(), "Id", "Name");
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


                _drugRepository.Add(drug);
                _drugRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Comps = new SelectList(_companiesRepository.GetAll(), "Id", "Name");
            return View(drug);
        }





        [HttpGet]
        public IActionResult Edit(int id)
        {

            var drug = _drugRepository.GetbyId(id);
            if (drug == null)
            {
                return NotFound();
            }
            ViewBag.Comps = new SelectList(_companiesRepository.GetAll(), "Id", "Name");
            return View(drug);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Drug drug, IFormFile? ImagePath)
        {
            if (ModelState.IsValid)
            {
                var existingDrug = _drugRepository.GetByIdAsNoTracking(drug.Id);
                if (existingDrug == null)
                {
                    NotFound();
                }
                if (ImagePath != null)
                {
                    drug.ImagePath = _imageHelper.UpdateImage(ImagePath, existingDrug.ImagePath);
                }
                else
                {
                    drug.ImagePath = existingDrug.ImagePath;
                }
                _drugRepository.Update(drug);
                _drugRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Comps = new SelectList(_companiesRepository.GetAll(), "Id", "Name");

            return View(drug);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                NotFound();
            }

            var drug = _drugRepository.GetbyId(id);

            return View(drug);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var drug = _drugRepository.GetbyId(id);

            if (drug == null)
            {
                NotFound();
            }

            _imageHelper.DeleteImage(drug.ImagePath);
            _drugRepository.Delete(id);
            _drugRepository.Save();


            return RedirectToAction("Index");
        }


        public IActionResult UniqueName(string name, int id)
        {
            var drug = _drugRepository.UniqueName(name, id);

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
