namespace CMSCore.Content.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid().ToString();
            EntityId = Id;
            Version = 1;
            Date = DateTime.Now;
            IsActiveVersion = true;
        }

        public virtual DateTime Date { get; set; }

        public virtual string EntityId { get; set; }
        public virtual bool Hidden { get; set; }

        [Key]
        public virtual string Id { get; set; }

        public virtual bool IsActiveVersion { get; set; }

        public virtual bool MarkedToDelete { get; set; }
        public virtual DateTime Modified { get; set; }

        public string UserId { get; set; }

        public virtual int Version { get; set; }
    }
}