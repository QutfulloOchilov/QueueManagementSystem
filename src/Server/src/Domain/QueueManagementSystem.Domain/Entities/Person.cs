using System;

namespace QueueManagementSystem.Domain.Entities
{
    public class Person : EntityBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CardId { get; set; }

        public override string ToString() => $"{LastName} {FirstName} {MiddleName}".Trim();
    }

    public enum Gender
    {
        Female = 0,
        Male = 1
    }
}