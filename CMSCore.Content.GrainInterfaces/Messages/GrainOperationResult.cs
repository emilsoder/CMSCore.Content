namespace CMSCore.Content.GrainInterfaces.Messages
{

    public class GrainOperationResult
    {
        public virtual string Message { get; set; }
        public virtual bool Successful { get; set; }
    }
}