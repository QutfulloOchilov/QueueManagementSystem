using System;

namespace QueueManagementSystem.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
        {
            Key = key;
            Name = name;
        }

        public string Name { get; }
        public object Key { get; }
    }
}