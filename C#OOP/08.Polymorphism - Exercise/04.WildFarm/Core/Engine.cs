namespace _04.WildFarm.Core
{
    using _04.WildFarm.Models.Animals;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;
        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
