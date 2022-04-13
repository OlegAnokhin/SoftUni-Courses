using System;

namespace P04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int passwordMinLength = 6;
            const int passwordMaxLength = 10;
            const int passwordDigitsMinCount = 2;

            string password = Console.ReadLine();

            bool isPasswodrValid = ValidatePassword(password
                , passwordMinLength
                , passwordMaxLength
                , passwordDigitsMinCount);

            if (isPasswodrValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool ValidatePassword(string password
            , int passwordMinLength
            , int passwordMaxLength
            , int passwordDigitsMinCount)
        {
            bool isPasswordValid = true;

            if (!ValidadePasswordLength(password
                , passwordMinLength
                , passwordMaxLength))
            {
                Console.WriteLine($"Password must be between {passwordMinLength} and {passwordMaxLength} characters");
                isPasswordValid = false;
            }
            if (!ValidatePasswordIsAlphaNum(password))
            {
                Console.WriteLine($"Password must consist only of letters and digits");
                isPasswordValid = false;
            }
            if (!ValidatePasswordDigitsMinCount(password, passwordDigitsMinCount))
            {
                Console.WriteLine($"Password must have at least {passwordDigitsMinCount} digits");
                isPasswordValid = false;
            }
            return isPasswordValid;
        }

        static bool ValidadePasswordLength(string password
            , int minLength
            , int maxLength)
        {
            if (password.Length >= minLength && password.Length <= maxLength)
            {
                return true;
            }
            return false;
        }
        static bool ValidatePasswordIsAlphaNum(string password)
        {
            foreach (char ch in password)
            {
                if (!Char.IsLetterOrDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
        static bool ValidatePasswordDigitsMinCount(string password, int minDigitsCount)
        {
            int digitsCount = 0;
            foreach (char ch in password)
            {
                if (Char.IsDigit(ch))
                {
                    digitsCount++;
                }
            }
            return digitsCount >= minDigitsCount;
        }
    }
}
