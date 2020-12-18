using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhangZuqi.Core.WebApi.Utility;

namespace ZhangZuqi.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(CustomActionFilterAttribute))] //控制器级别的注册
    public class FilterController : ControllerBase
    {
        public FilterController()
        {
            Console.WriteLine("FilterController被构造。。。");
        }

        [Route("Get")]
        [HttpGet]
        [CustomResourceFilter]
        public string Get()
        {
           
            return "this is zzq002";
        }

        [Route("GetInfo")]
        [HttpGet]
        [CustomResourceFilter]
        public string GetInfo()
        {

            return "this is zzq002 "+DateTime.Now.ToString();
        }

        [Route("GetInfoByParamter")]
        [HttpGet]
       // [CustomIActionFilter]  只能应用于无参数的
   //    [TypeFilter(typeof(CustomActionFilterAttribute))]  //不需要注册服务的
       [ServiceFilter(typeof(CustomActionFilterAttribute))] //需要注册服务的
     // [CustomIOCFilterFactoryAttribute(typeof(CustomActionFilterAttribute))] //需要注册服务
        public string GetInfoByParamter()
        {

            return "this is zzq002 " + DateTime.Now.ToString();
        }
    }
}
