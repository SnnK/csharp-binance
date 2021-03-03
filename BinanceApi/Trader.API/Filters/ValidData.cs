using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Newtonsoft.Json;
using Trader.BussinessProcess.Models;

namespace Trader.API.Filters
{
    public class ValidData : ActionFilterAttribute
    {
        public int[] Limit { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.FirstOrDefault().Value;
            string jsonError = string.Empty;
            var errorMessages = new ErrorModel();

            if (!context.ModelState.IsValid)
            {
                var modelStateValues = context.ModelState.Values;

                foreach (string error in modelStateValues.SelectMany(o => o.Errors.Select(o => o.ErrorMessage)))
                {
                    errorMessages.Errors.Add(error);
                }

                if (errorMessages.Errors.Any())
                {
                    jsonError = JsonConvert.SerializeObject(errorMessages);
                    context.Result = new BadRequestObjectResult(jsonError);
                }
            }
        }
    }
}
