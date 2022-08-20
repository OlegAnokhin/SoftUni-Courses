using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly ICollection<IEquipment> models;

        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models => (IReadOnlyCollection<IEquipment>)models;
        public void Add(IEquipment model)
        {
            models.Add(model);
        }
        public bool Remove(IEquipment model)
        {
            if (!models.Remove(model))
            {
                return false;
            }
            models.Remove(model);
            return true;
        }
        public IEquipment FindByType(string type)
        {
            return models.FirstOrDefault(t => t.GetType().Name == type);
        }
    }
}