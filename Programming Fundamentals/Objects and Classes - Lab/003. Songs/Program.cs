using System;
using System.Collections.Generic;

namespace _003._Songs
{
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split("_", StringSplitOptions.RemoveEmptyEntries);
                string typeList = tokens[0];
                string name = tokens[1];
                string time = tokens[2];

                Song newSong = new Song()
                {
                    TypeList = typeList,
                    Name = name,
                    Time = time
                };
                songs.Add(newSong);
            }
            string typeListToSearch = Console.ReadLine();
            if (typeListToSearch == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach(Song song in songs)
                {
                    if (song.TypeList == typeListToSearch)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
}
