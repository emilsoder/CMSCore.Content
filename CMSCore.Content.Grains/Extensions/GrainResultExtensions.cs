namespace CMSCore.Content.Grains.Extensions
{
    using System;
    using CMSCore.Content.ViewModels;

    public static class GrainResultExtensions
    {
        public static GrainOperationResult ResultFromException(this Exception ex)
        {
            return new GrainOperationResult
            {
                Successful = false,
                Message = ex.Message
            };
        }
    }
} 