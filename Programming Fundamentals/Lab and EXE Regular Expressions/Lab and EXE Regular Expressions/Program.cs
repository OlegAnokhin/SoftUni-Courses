using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab_and_EXE_Regular_Expressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string emailPattern = @"([A-Za-z0-9]+)@([A-Za-z]=\.[a-z]+)";
            string email = "oleg@anokhin.bg";
            Regex regex = new Regex(emailPattern);
            Match match = regex.Match(email);
            Console.WriteLine(match.Success);
            Console.WriteLine(match.Value);
            Console.WriteLine(match.Groups[1].Value);


            //  bool isMatch = regex.IsMatch(email);
            //    Console.WriteLine(isMatch);
        }
    }
}

//Cheatsheat
//[word]
//[A - Z]
//[a - z]
//[0 - 9]
 
//\w - [A - Z][a - z][0 - 9]_
//\W - opposite \w
//\s - " "
//\S - opposite \s
//\d - 0 - 9
//\D - opposite 0 - 9
 
//\+\d * -> + 359885976002 a + b-> + 35988597600 +
//\+\d + -> + 359885976002 a + b-> + 359885976002
//\+\d ? -> + 359885976002 a + b-> + 3 +
 
//\+\d
//{ 4} -> +4 digits
//\+\d
//{ 1,4} -> +between 1 and 4 digits
//\+\d
//{ 4,} -> +above(including) 4 digits

//d
//{2}
//-(\w
//{ 3})-\d
//{ 4} -> ()->creates group
//d
//{2}
//-(?:\w
//{ 3})-\d
//{ 4} -> (?:)->non capture group
//(?<day>\d{2})-(?< month >\w
//{ 3})-(?< year >\d
//{ 4}) -(?< name >) - group name
//(?< name >\d{ 2})-(\w
//{ 3})-\g < name > - \g < name > -reuse groups
//(:?http | https):\/\/ ([A - Za - z0 - 9] +)(\.com) - https://regex101.com -> will not count https or http as a group
//^[A - Z][a - z] +$ -> Stoyan->valid-> ^ should start / $ should end
//  <(\w+)[^>] *>.*?<\/\1 > - < b > Regular Expressions </ b > - \1 copy first group