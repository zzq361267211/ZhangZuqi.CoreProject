using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZhangZuqi.Core.WebApi.Utility
{
    public class CustomIOCFilterFactoryAttribute : Attribute,IFilterFactory
    {
        private Type _FilterType = null;
        public CustomIOCFilterFactoryAttribute(Type type)
        {
            _FilterType = type;
        }
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
          return  (IFilterMetadata)serviceProvider.GetService(this._FilterType);
        }
    }
}
