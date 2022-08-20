using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> cars;
        public FormulaOneCarRepository()
        {
            this.cars = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => cars;
        public void Add(IFormulaOneCar model) => cars.Add(model);
        public bool Remove(IFormulaOneCar model)
        {
            //if (this.cars.Contains(model))
            //{
            return cars.Remove(model);
            //    return true;
            //}
            //return false;
        }
        public IFormulaOneCar FindByName(string name)
        {
            //if (this.cars == null)
            //{
            //    return null;
            //}
            return this.cars.FirstOrDefault(m => m.Model == name);
        }
    }
}