using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Day_3.Repository.IRepository;

namespace MVC_Day_3.Controllers
{
    public class CompaniesController : Controller
    {


        private readonly ICompaniesRepository _companiesRepository;
        private readonly IDrugRepository _drugRepository;

        public CompaniesController(ICompaniesRepository companiesRepository, IDrugRepository drugRepository) //Inject
        {
            _companiesRepository = companiesRepository;
            _drugRepository = drugRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(_companiesRepository.GetAll());
        }

        public IActionResult CompsDrugs()
        {

            return View(_companiesRepository.GetAll());
        }

        public IActionResult Drugslist(int compID)
        {
            List<Drug> druglist = _drugRepository.GetByCompID(compID);
            return Json(druglist);
        }



        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var company = _companiesRepository.GetbyId(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                _companiesRepository.Add(company);
                _companiesRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = _companiesRepository.GetbyId(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _companiesRepository.Update(company);
                    _companiesRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = _companiesRepository.GetbyId(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var company = _companiesRepository.GetbyId(id);
            if (company != null)
            {
                _companiesRepository.Delete(id);
            }

            _companiesRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _companiesRepository.Any(id);
        }

        public IActionResult UniqueName(string name, int id)
        {
            var company = _companiesRepository.First(name, id);

            if (company == null)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
