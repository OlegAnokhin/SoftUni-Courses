using System;
using System.Text;

namespace EXE07._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine();
            int bombPower = 0;  
            StringBuilder outputText = new StringBuilder();

            for (int i = 0; i < inputStr.Length; i++)
            {
                char CurrCh = inputStr[i];
                if (CurrCh == '>')
                {
                    int currBombPower = GetIntValueOfCharacter(inputStr[i + 1]);
                    outputText.Append(CurrCh);
                    bombPower += currBombPower;
                }
                else
                {
                    if (bombPower > 0)
                    {
                        bombPower--;
                    }
                    else
                    {
                        outputText.Append(CurrCh);
                    }
                }
            }
            Console.WriteLine(outputText.ToString());
        }

        static int GetIntValueOfCharacter (char ch)
        {
            return (int)ch - 48;
        }
    }
}
 // solution whit REMOVE

//string field = Console.ReadLine();
//int bomb = 0;
//for (int i = 0; i < field.Length; i++)
//{
//    if (bomb > 0 && field[i] != '>')
//    {
//        field = field.Remove(i, 1); // Remove char on this index
//        bomb--; // One bomb is used
//        i--; // after remove next char is moved 1 position, so return counter i to this char, decreasing i by 1  
//    }
//    else if (field[i] == '>')
//    {
//        bomb += int.Parse(field[i + 1].ToString()); // takes the digit after '>' - bomb strength and add to bomb
//    }
//}
//Console.WriteLine(field);