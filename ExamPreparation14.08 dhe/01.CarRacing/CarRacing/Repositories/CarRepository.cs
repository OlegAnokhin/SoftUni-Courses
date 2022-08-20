using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> models;
        public CarRepository()
        {
            this.models = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => (IReadOnlyCollection<ICar>)models;
        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidAddCarRepository);
            }
            models.Add(model);
        }
        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }
        public ICar FindBy(string property)
        {
            return Models.FirstOrDefault(v => v.VIN == property);
        }
    }
}