namespace CMSCore.Content.Api.Extensions
{
    using System;
    using CMSCore.Content.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public static class ActionResultExtensions
    {
        public static JsonResult BadRequestFromException(this Exception ex)
        {
            return new JsonResult(new GrainOperationResult
            {
                Successful = false,
                Message = ex.Message
            });
        }
    }
}