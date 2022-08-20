using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> models;
        public VesselRepository()
        {
            this.models = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models => (IReadOnlyCollection<IVessel>)this.models;
        public void Add(IVessel model) => models.Add(model);
        public bool Remove(IVessel model) => models.Remove(model);
        public IVessel FindByName(string name) => models.FirstOrDefault(v => v.Name == name);
    }
}