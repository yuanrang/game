using log4net;
using Microsoft.AspNetCore.Mvc.Filters;
using Game.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Filter
{
    public class LogFilter : ActionFilterAttribute
    {

        /// <summary>
        /// 控制器中加了该属性的方法中代码执行之前该方法。
        /// 所以可以用做权限校验。
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            base.OnActionExecuting(context);
            var get_params = $"{context.HttpContext.Request.Method}|{context.HttpContext.Request.Path}...";
            if (context.HttpContext.Request.HasFormContentType)
            {
                foreach (var item in context.HttpContext.Request.Form)
                {
                    get_params += $"{item.Key.ToString().Trim()}={item.Value.ToString()}|";
                }
            }
            else
            {
                foreach (var item in context.ActionArguments)
                {
                    get_params += $"{item.Key.ToString().Trim()}={item.Value.ToString()}|";
                }
            }
            get_params = get_params.Trim('|');
            LogHelper.Info(get_params);
        }
        /// <summary>
        /// 控制器中加了该属性的方法执行完成后才会来执行该方法。
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
        /// <summary>
        /// 控制器中加了该属性的方法执行完成后才会来执行该方法。比OnActionExecuted()方法还晚执行。
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            return base.OnResultExecutionAsync(context, next);
        }
    }
}
