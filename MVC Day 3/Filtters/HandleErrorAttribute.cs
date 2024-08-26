using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC_Day_3.Filtters
{
    public class HandleErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult viewResult = new ViewResult();

            viewResult.ViewName = "Error";

            context.Result = viewResult;
        }
    }
}
