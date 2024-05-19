using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Game.Common;
using Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Game.Filter
{
    /// <summary>
    /// 异常过滤器，记录异常日志。
    /// </summary>
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        /// <summary>
        ///如果方法中处理了异常，则不会进入该方法。
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor descriptor = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
            string ActionName = descriptor.ActionName;
            string ActionParam = string.Join(",", descriptor.Parameters);

            LogHelper.Error($"ActionName({ActionName}),errorMsg:{context.Exception.Message}|ActionParam:{ActionParam}");
            var result = new MsgInfo<string>()
            {
                code = 500,
                msg = "Network Exception"
            };
            context.Result = new Microsoft.AspNetCore.Mvc.ContentResult
            {
               
                StatusCode = StatusCodes.Status200OK,
             
                ContentType = "application/json;charset=utf-8",
                
                Content = JsonConvert.SerializeObject( result)
            };


            //context.Result = new BadRequestObjectResult(
            //    new MsgInfo<string>()
            //{
            //    code = 500,
            //    msg = "Network Exception"
            //});
            context.ExceptionHandled = true;
        }
    }
}
