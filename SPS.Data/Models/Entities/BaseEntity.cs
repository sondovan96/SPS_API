using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Data.Models.Entities
{
    public interface IEntityBase
    {
        public Guid Id { set; get; }
    }

    public interface IAuditEntity
    {
        public DateTime CreatedDate { set; get; }
        public DateTime ModifiedDate { set; get; }
    }

    public interface IDeleteEntity
    {
        bool IsDeleted { get; set; }
    }
}
