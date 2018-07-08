namespace CMSCore.Content.Api.Attributes
{
     using GrainInterfaces.Messages;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = context.ModelState.AsGrainOperationResult();
            }
        }
    }

    public static class ModelStateExtensions
    {
        public static JsonResult AsGrainOperationResult(this ModelStateDictionary modelState)
        {
            try
            {
                var modelErrors = "";

                foreach (var state in modelState)
                {
                    var key = string.IsNullOrEmpty(state.Key) ? null : state.Key + ": ";

                    modelErrors += "\n" + key + state.Value;
                }

                return new JsonResult(new GrainOperationResult
                {
                    Successful = false,
                    Message = modelErrors
                });
            }
            catch (System.Exception)
            {
                return new JsonResult(new GrainOperationResult() { Message = "An error occured.", Successful = false });
            }
        }
    }
}