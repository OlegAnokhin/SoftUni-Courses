using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using CarRacing.Repositories.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly ICollection<IRacer> models;
        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => (IReadOnlyCollection<IRacer>)this.models;
        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidAddRacerRepository);
            }
            this.models.Add(model);
        }
        public bool Remove(IRacer model)
        {
            return this.models.Remove(model);
        }
        public IRacer FindBy(string property)
        {
            return this.Models.FirstOrDefault(u => u.Username == property);
        }
    }
}