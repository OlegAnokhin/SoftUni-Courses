using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private ICollection<IEgg> eggs;
        public EggRepository()
        {
            eggs = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => (IReadOnlyCollection<IEgg>)eggs;
        public void Add(IEgg model)
        {
            eggs.Add(model);
        }
        public bool Remove(IEgg model)
        {
            return eggs.Remove(model);
        }
        public IEgg FindByName(string name)
        {
            return eggs.FirstOrDefault(n => n.Name == name);
        }
    }
}