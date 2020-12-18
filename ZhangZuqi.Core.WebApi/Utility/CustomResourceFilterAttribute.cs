using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZhangZuqi.Core.WebApi.Utility
{
    public class CustomResourceFilterAttribute : Attribute, IResourceFilter
    {
        //做缓存
        private static Dictionary<string, object> dictionaryCache = new Dictionary<string, object>();

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string key = context.HttpContext.Request.Path.ToString();
            if (dictionaryCache.ContainsKey(key))
            {
                context.Result = dictionaryCache[key] as ObjectResult;  //Result短路器
            }

            Console.WriteLine(" 这是OnResourceExecuting");
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //把数据存储缓存
            //Key----path:
            string key = context.HttpContext.Request.Path.ToString();
            ObjectResult objectResult= context.Result as ObjectResult;
            dictionaryCache[key] = objectResult;

            Console.WriteLine(" 这是OnResourceExecuted");
        }


    }
}
