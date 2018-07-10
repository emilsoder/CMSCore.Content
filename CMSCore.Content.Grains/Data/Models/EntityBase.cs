namespace CMSCore.Content.Grains.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid().ToString();
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }
         
        [Key]
        public virtual string Id { get; set; }

        public virtual bool Hidden { get; set; }
        public virtual bool MarkedToDelete { get; set; }

        public virtual DateTime Modified { get; set; }
        public virtual DateTime Created { get; set; }

        public string UserId { get; set; }
    }
}