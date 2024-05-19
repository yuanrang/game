using Game.Common;
using Game.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Game.Filter
{
    public class CheCkMD5Filter: IAuthorizationFilter
    {
     
        public void OnAuthorization(AuthorizationFilterContext context)
        {   
            StringBuilder data = new StringBuilder();
            object sg = default; 
            if (context.HttpContext.Request.Method == "GET")
            {
                var request = context.HttpContext.Request.Query;
                foreach (var item in request)
                {
                    if (item.Key == "sg")
                        sg = item.Value;
                    else
                        data.Append(item.Value[0]);
                }
            }
            else
            {
                string body = "";
                using (var reader = new StreamReader(context.HttpContext.Request.Body))
                {
                    body = reader.ReadToEndAsync().Result;
                }
                var postdata = JsonConvert.DeserializeObject<Dictionary<string, object>>(body);
                foreach (var item in postdata)
                {
                    if (item.Key != "sg")
                    {
                        if (!string.IsNullOrWhiteSpace(item.Value.ToString()))
                            data.Append(item.Value);
                    }

                    else
                        sg = item.Value;
                }
              
            }
            if (data.EncryptString() != sg.ToString())
            {
                context.Result = new ObjectResult(new MsgInfo<string>() { code = 500, msg = "签名错误" });
            }
        }
    }
}
