namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            //string result = ExportAlbumsInfo(context, 9); // ID 9

            string result = ExportSongsAboveDuration(context, 4); // duration 4

            Console.WriteLine(result);

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();
            var albumsInfo = context.Albums
                .Where(a => a.ProducerId.HasValue &&
                            a.ProducerId.Value == producerId)
                .ToArray()
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = s.Price.ToString("f2"),
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer)
                        .ToArray(),
                   AlbumPrice = a.Price.ToString("f2")
                })
            .ToArray();
            foreach ( var album in albumsInfo )
            {
                sb.AppendLine($"-AlbumName: {album.Name}")
                  .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                  .AppendLine($"-ProducerName: {album.ProducerName}")
                  .AppendLine($"-Songs:");

                int songNumber = 1;
                foreach(var song in album.Songs)
                {
                    sb.AppendLine($"---#{songNumber}")
                      .AppendLine($"---SongName: {song.SongName}")
                      .AppendLine($"---Price: {song.Price}")
                      .AppendLine($"---Writer: {song.Writer}");
                    songNumber++;
                }
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();
            var songsInfo = context.Songs
                .AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration) //durationSeconds
                .Select(s => new
                {
                    s.Name,
                    Performers = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .OrderBy(p => p)
                        .ToArray(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                    .ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ToArray();
            int songCounter = 1;
            foreach(var song in songsInfo) 
            {
                sb.AppendLine($"-Song #{songCounter}")
                  .AppendLine($"---SongName: {song.Name}")
                  .AppendLine($"---Writer: {song.WriterName}");
                foreach (var perf in song.Performers)
                {
                    sb.AppendLine($"---Performer: {perf}");
                }
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                  .AppendLine($"---Duration: {song.Duration}");
                songCounter++;
            }
            return sb.ToString().TrimEnd();
        }
    }
}
