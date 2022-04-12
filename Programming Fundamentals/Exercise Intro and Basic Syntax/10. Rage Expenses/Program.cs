using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGame = int.Parse(Console.ReadLine());
            double headPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double brocenHead = Math.Floor(lostGame / 2);
            double brocenMouse = Math.Floor(lostGame / 3);
            double brocenKeyboard = 0;
            double brocenDisplay = 0;

            for (int i = 0; i < brocenHead; i += 2)
            {
                if (brocenHead >= 2 && brocenMouse >= 2)
                {
                    brocenKeyboard++;
                }
                if (brocenKeyboard % 2 == 0)
                {
                    brocenDisplay++;
                }
            }
            double amount = brocenHead * headPrice + brocenMouse * mousePrice + brocenKeyboard * keyboardPrice
                + brocenDisplay * displayPrice;
            Console.WriteLine($"Rage expenses: {amount:f2} lv.");
        }
    }
}
