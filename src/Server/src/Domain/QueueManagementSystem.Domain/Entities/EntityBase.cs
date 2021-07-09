using QueueManagementSystem.Domain.Interfaces;
using System;

namespace QueueManagementSystem.Domain.Entities
{
    public abstract class EntityBase : IEntity
    {
        private Guid _id;

        public Guid Id
        {
            get
            {
                if (_id == Guid.Empty)
                    _id = Guid.NewGuid();

                return _id;
            }
            set { _id = value; }
        }

        public bool IsActive { get; set; }

        public string Title => ToString();

        public override string ToString() => "(No title)";
    }
}
