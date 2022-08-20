using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly ICollection<IAstronaut> astronauts;
        public AstronautRepository()
        {
            astronauts = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => (IReadOnlyCollection<IAstronaut>)astronauts;

        public void Add(IAstronaut model)
        {
            astronauts.Add(model);
        }
        public bool Remove(IAstronaut model)
        {
            return astronauts.Remove(model);
        }
        public IAstronaut FindByName(string name)
        {
            return astronauts.FirstOrDefault(n => n.Name == name);
        }
    }
}