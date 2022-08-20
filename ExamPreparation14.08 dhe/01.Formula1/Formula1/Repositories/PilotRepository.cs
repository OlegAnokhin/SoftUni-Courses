using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> pilots;
        public PilotRepository()
        {
            this.pilots = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => pilots;
        public void Add(IPilot model) => pilots.Add(model);
        public bool Remove(IPilot model)
        {
            //if (this.pilots.Contains(model))
            //{
            return pilots.Remove(model);
            //    return true;
            //}
            //return false;
        }
        public IPilot FindByName(string name)
        {
            //if (this.pilots == null)
            //{
            //    return null;
            //}
            return pilots.FirstOrDefault(m => m.FullName == name);
        }
    }
}