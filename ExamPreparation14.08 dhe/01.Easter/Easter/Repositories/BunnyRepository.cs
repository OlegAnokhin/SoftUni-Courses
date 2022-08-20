using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private ICollection<IBunny> bunnies;
        public BunnyRepository()
        {
            bunnies = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => (IReadOnlyCollection<IBunny>)bunnies;
        public void Add(IBunny model)
        {
            bunnies.Add(model);
        }
        public bool Remove(IBunny model)
        {
            return bunnies.Remove(model);
        }
        public IBunny FindByName(string name)
        {
            return bunnies.FirstOrDefault(n => n.Name == name);
        }
    }
}