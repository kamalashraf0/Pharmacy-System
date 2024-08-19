using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace MVC_Day_3.Repository.Helpers
{
    public static class HtmlHelper
    {
        public static IHtmlContent DisplayTable<T>(this IHtmlHelper htmlHelper, List<T> items)
        {
            var properties = typeof(T).GetProperties();
            var sb = new StringBuilder();

            sb.Append("<table class=\"table table-striped table-bordered\">");
            sb.Append("<thead class=\"thead-dark\"><tr>");


            foreach (var prop in properties)
            {
                sb.AppendFormat("<th scope=\"col\">{0}</th>", prop.Name);
            }
            sb.Append("</tr></thead><tbody>");

            foreach (var item in items)
            {
                sb.Append("<tr>");
                foreach (var prop in properties)
                {
                    sb.AppendFormat("<td>{0}</td>", prop.GetValue(item));
                }
                sb.Append("</tr>");
            }
            sb.Append("</tbody></table>");

            return new HtmlString(sb.ToString());
        }
    }
}
