namespace _05.BirthdayCelebrations.Models
{
    using System;
    using _05.BirthdayCelebrations.Interfaces;
    public class Pet : IName, IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }
        public string Name { get; private set; }
        public DateTime Birthdate { get; private set; }
    }
}