namespace CMSCore.Content.Api.Extensions
{
    using System;
    using CMSCore.Content.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public static class ActionResultExtensions
    {
        public static BadRequestObjectResult BadRequestFromException(this Exception ex)
        {
            return new BadRequestObjectResult(new GrainOperationResult
            {
                Successful = false,
                Message = ex.Message
            });
        }
    }
}