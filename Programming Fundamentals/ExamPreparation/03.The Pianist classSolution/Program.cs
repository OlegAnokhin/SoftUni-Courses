using System;
using System.Collections.Generic;

namespace _03_The_Pianist_Class_Solution
{
    public class Piece
    {
        public string Composer { get; set; }
        public string Key { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] pieceInfo = Console.ReadLine().Split("|");
                string piece = pieceInfo[0];
                pieces.Add(piece, new Piece
                {
                    Composer = pieceInfo[1],
                    Key = pieceInfo[2]
                });
            }
            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] splitedCommand = command.Split("|");

                if (splitedCommand[0] == "Add")
                {
                    string piece = splitedCommand[1];
                    string composer = splitedCommand[2];
                    string key = splitedCommand[3];

                    if (pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                        continue;
                    }
                    pieces.Add(piece, new Piece
                    {
                        Composer = composer,
                        Key = key
                    });
                    Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");

                }
                else if (splitedCommand[0] == "Remove")
                {
                    string piece = splitedCommand[1];
                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (splitedCommand[0] == "ChangeKey")
                {
                    string piece = splitedCommand[1];
                    string newKey = splitedCommand[2];
                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece].Key = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }
            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
    }
}
