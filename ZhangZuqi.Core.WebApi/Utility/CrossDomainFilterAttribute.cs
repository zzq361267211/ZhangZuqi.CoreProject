using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZhangZuqi.Core.WebApi.Utility
{
    public class CrossDomainFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            #region 允许跨域
            context.HttpContext.Request.Headers.Add("Access-Control-Allow-Origin", "*");
            #endregion
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
