using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;
        public RaceRepository()
        {
            this.races = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => races;
        public void Add(IRace model) => races.Add(model);
        public bool Remove(IRace model)
        {
            //if (this.races.Contains(model))
            //{
            return races.Remove(model);
            //    return true;
            //}
            //return false;
        }
        public IRace FindByName(string name)
        {
            //if (this.races == null)
            //{
            //    return null;
            //}
            return races.FirstOrDefault(m => m.RaceName == name);
        }
    }
}