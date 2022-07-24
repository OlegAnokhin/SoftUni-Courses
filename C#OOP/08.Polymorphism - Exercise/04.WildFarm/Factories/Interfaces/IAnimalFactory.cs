namespace _04.WildFarm.Factories.Interfaces
{
    using _04.WildFarm.Models.Animals;
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string type, string name, double weight, string thirdParam, string fourthParam = null);
    }
}