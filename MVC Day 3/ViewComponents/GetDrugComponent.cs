using Microsoft.AspNetCore.Mvc;

namespace MVC_Day_3.ViewComponents
{
    public class GetDrugComponent : ViewComponent
    {

        static List<string> CompanyNames = new List<string>
        {
            "Egypt Pharma",
            "EVA Pharma",
            "AUG Pharma",
            "Pharco Pharma"
        };

        public IViewComponentResult Invoke()
        {
            return View(CompanyNames);
        }

    }
}
