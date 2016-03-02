using Microsoft.AspNet.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Filters.OData
{
    public sealed class ODataFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var odataSettingsParameter = context.ActionArguments.Select(x => x.Value as IODataContext).Where(x => x != null).SingleOrDefault();

            try
            {
                if (odataSettingsParameter != null)
                {
                    odataSettingsParameter.ReadFromQueryString(context.HttpContext.Request);
                }
            } catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to read OData parameters from request query string.", ex);
            }
        }
    }
}
