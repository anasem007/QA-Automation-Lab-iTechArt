using System;

namespace ClassesObjectsMethods.Models
{
    public abstract class User
    {
        public Guid Id => Guid.NewGuid();
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Job Job { get; set; }

        public string FullName => FirstName + " " + LastName;
    }
}