namespace _04.PizzaCalories
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            try
            {
                CreatePizza(input);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);                
            }
        }

        private static void CreatePizza(string[] input)
        {
            Pizza pizza = new Pizza(input[1]);
            input = Console.ReadLine().Split();
            Dough pizzaDough = new Dough(input[1], input[2], double.Parse(input[3]));
            pizza.Dought = pizzaDough;
            input = Console.ReadLine().Split();
            while (input[0] != "END")
            {
                Topping pizzaTopping = new Topping(input[1], double.Parse(input[2]));
                pizza.AddTopping(pizzaTopping);
                input = Console.ReadLine().Split();
            }
            if (pizza.Toppings.Count > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            Console.WriteLine(pizza);
        }
    }
}

//Pizza Meatless
//Dough Wholegrain Crispy 100
//Topping Veggies 50
//Topping Cheese 50
//END