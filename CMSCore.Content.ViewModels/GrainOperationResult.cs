namespace CMSCore.Content.ViewModels
{
    [Orleans.Concurrency.Immutable]
    public class GrainOperationResult
    {
        public virtual string Message { get; set; }
        public virtual bool Successful { get; set; }
    }
}