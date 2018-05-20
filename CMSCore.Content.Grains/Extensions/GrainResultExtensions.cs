namespace CMSCore.Content.Grains.Extensions
{
    using System;
    using System.Threading.Tasks;
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
} //public static async Task<GrainOperationResult> ExecuteTask(this Task task)
//{
//    try
//    {
//        await task;
//        return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
//    }
//    catch (Exception ex)
//    {
//        return ex.ResultFromException();
//    }
//}

//public static async Task<GrainOperationResult> ExecuteTask<TTask>(this Task<TTask> task)
//{
//    try
//    {
//        var result = await task;
//        return new GrainOperationResult { Successful = true, Message = result?.ToString() };
//    }
//    catch (Exception ex)
//    {
//        return ex.ResultFromException();
//    }
//}