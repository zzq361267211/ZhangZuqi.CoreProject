using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZhangZuqi.Core.WebApi.Utility
{
    public class CustomActionFilterAttribute : Attribute, IActionFilter
    {
        private ILogger<CustomActionFilterAttribute> _Logger = null;
        public CustomActionFilterAttribute(ILogger<CustomActionFilterAttribute> logger)
        {
            _Logger = logger;
        }

        /// <summary>
        /// 方法执行前
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionLog = DateTime.Now.ToString() + "  调用  " + context.RouteData.Values["action"] + " api;参数为：" + Newtonsoft.Json.JsonConvert.SerializeObject(context.ActionArguments);
            //Console.WriteLine("方法执行前");
            _Logger.LogInformation(actionLog);
        }
        /// <summary>
        /// 方法执行后
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            #region 编写日志
            var result = context.Result;
            ObjectResult objectResult = result as ObjectResult;
            var resultLog = DateTime.Now.ToString() + "  调用  " + context.RouteData.Values["action"] + " api;参数为：" + Newtonsoft.Json.JsonConvert.SerializeObject(objectResult.Value);
            //使用log4net写入日志
            // Console.WriteLine("方法执行后");
            _Logger.LogInformation(resultLog);
            #endregion

            
        }


    }
}
