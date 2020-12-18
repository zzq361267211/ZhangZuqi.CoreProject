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
    public class CrossDaminController : ControllerBase
    {
        [Route("GetCrossDaminData")]
        [HttpGet]
        [CrossDomainFilter]
        public string GetCrossDaminData()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(
                new
                {
                    id = 123,
                    Name = "zzq",
                    Description = "专门用于测试跨域问题。。"
                }
                );
        }
    }
}
