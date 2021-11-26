using System;
using QueueManagementSystem.Domain.Interfaces;

namespace QueueManagementSystem.Domain.Entities
{
    public abstract class EntityBase : IEntity
    {
        private Guid _id;

        public bool IsActive { get; set; }

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

        public string Title => ToString();

        public override string ToString() => "(No title)";
    }
}