using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ZhangZuqi.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecondController : ControllerBase
    {
        private ILogger<SecondController> _Logger = null;
        public SecondController(ILogger<SecondController> logger)
        {
            this._Logger = logger;
            _Logger.LogInformation("SecondController 被构造。。。");
        }

        [Route("Get")]
        [HttpGet]
        public String Get()
        {
            _Logger.LogInformation("SecondController.Get()被调用");
            return "this is zzq002";
        }
    }
}
